using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Threading;

namespace CodexAccountDesk;

internal sealed class DeskWindow : Window
{
    private readonly CancellationTokenSource _stop = new();
    private readonly DesktopSessionMonitor _sessions = new(Program.CodexHome);
    private readonly MacResourceMonitor _resources = new();
    private readonly DriveMonitor _drives = new();
    private readonly DispatcherTimer _clock = new() { Interval = TimeSpan.FromSeconds(1) };
    private readonly Dictionary<string, string> _quotas = new();
    private readonly List<MacAccountCard> _cards = new();
    private readonly ResourcePressure[] _pressure = new ResourcePressure[4];
    private readonly List<Task> _operations = new();
    private AccountService? _service;
    private DeskTheme _theme = new(true);
    private Grid _accounts = new(), _hardware = new();
    private ScrollViewer _accountScroll = new();
    private StackPanel _sessionValues = new(), _volumes = new();
    private TextBlock _status = new();
    private Button _add = new(), _cancel = new(), _refresh = new(), _settingsButton = new();
    private MacMenuBar? _tray;
    private readonly Dictionary<string, NativeMenuItem> _nativeItems = new();
    private CancellationTokenSource? _login, _switch;
    private string? _switchTarget;
    private SwitchPhase _phase;
    private bool _ready;
    private bool _initializing;
    private string _statusMessage = "";
    private AccountProfile[]? _preview;
    private int _ticks;
    public bool Exiting { get; private set; }
    public DeskWindow(AccountProfile[]? preview = null)
    {
        _preview = preview;
        Title = "Codex Switch"; Icon = new WindowIcon(Avalonia.Platform.AssetLoader.Open(new Uri("avares://CodexSwitch/Assets/app-icon.png"))); Width = 600; Height = 420; MinWidth = 500; MinHeight = 360;
        ExtendClientAreaToDecorationsHint = true; ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.PreferSystemChrome;
        ExtendClientAreaTitleBarHeightHint = 34; WindowStartupLocation = WindowStartupLocation.CenterScreen;
        Build(); UpdateTray();
        Opened += async (_, _) =>
        {
            if (Program.WindowProbePath != null) MacDiagnostics.StartWindowProbe(this, Program.WindowProbePath);
            else if (_preview == null) await RunAsync(InitializeAsync);
            else await MacDiagnostics.RenderAsync(this, Program.PreviewDirectory!);
        };
        Closing += (_, args) => { if (!Exiting) { args.Cancel = true; Hide(); } };
        KeyDown += async (_, args) =>
        {
            if (args.Key == Key.F5 || args.Key == Key.R && args.KeyModifiers == KeyModifiers.Meta)
            { args.Handled = true; await RefreshAsync(); }
            else if (args.Key == Key.W && args.KeyModifiers == KeyModifiers.Meta) { args.Handled = true; Hide(); }
        };
        SizeChanged += (_, _) => { ResizeAccounts(); RenderVolumes(); };
        _sessions.Changed += _ => OnUi(RenderSessions);
        _resources.Changed += () => OnUi(RenderHardware);
        _drives.Changed += () => OnUi(RenderVolumes);
        _clock.Tick += async (_, _) =>
        {
            if (Exiting) return;
            foreach (var card in _cards) card.Update(DateTimeOffset.UtcNow);
            if (++_ticks % 60 == 0 && _ready && _service!.Vault.Data.AutoRefresh) await RunAsync(token => _service.RefreshAllAsync(null, token));
        };
    }
    private void OnUi(Action action) => Dispatcher.UIThread.Post(() => { if (!Exiting) action(); });
    private async Task InitializeAsync(CancellationToken token)
    {
        if (_initializing || _ready) return;
        _initializing = true;
        try
        {
            if (_service == null)
            {
                var vault = await Task.Run(() => { var result = new AccountVault(Program.DataDirectory); result.Save(); return result; }, token);
                _service = new(vault, Program.CodexHome); _service.Changed += () => OnUi(RenderAccounts);
                Loc.SetLanguage(vault.Data.Language); _theme = new(vault.Data.Theme == "dark"); Build();
            }
            await _service.InitializeAsync(token); _ready = true;
            _sessions.Start(); _resources.Start(); _drives.Configure(_service.Vault.Data.Drives.ToArray()); _drives.Start(); _clock.Start();
            UpdateTray(); RenderAccounts();
            await _service.RefreshAllAsync(null, token);
        }
        finally { _initializing = false; }
    }
    private Task RefreshAsync() => RunAsync(_ready ? token => _service!.RefreshAllAsync(null, token) : InitializeAsync);
    private void Build()
    {
        _theme.Apply(this);
        var shell = new Grid { RowDefinitions = new RowDefinitions("34,36,*,28") };
        var titlebar = new Grid { Background = _theme.Brush("chrome"), ColumnDefinitions = new ColumnDefinitions("*,Auto,Auto,Auto"), Margin = new Thickness(0) };
        var caption = _theme.Text("Codex Switch", 12); caption.VerticalAlignment = VerticalAlignment.Center;
        var mark = new BrandMark { Width = 18, Height = 18, Ink = _theme.Brush("text") };
        var captionContent = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 8, VerticalAlignment = VerticalAlignment.Center };
        captionContent.Children.Add(mark); captionContent.Children.Add(caption);
        var dragRegion = new Border { Background = Brushes.Transparent, Margin = new Thickness(84, 0, 0, 0), Child = captionContent };
        dragRegion.PointerPressed += (_, args) =>
        {
            if (!args.GetCurrentPoint(dragRegion).Properties.IsLeftButtonPressed) return;
            BeginMoveDrag(args); args.Handled = true;
        };
        titlebar.Children.Add(dragRegion);
        var language = _theme.Button(Loc.LanguageName, () =>
        {
            _ = RunAsync(_ =>
            {
                var next = Loc.Language == "ko" ? "en" : "ko";
                if (_service != null) { lock (_service.Vault.SyncRoot) { _service.Vault.Data.Language = next; _service.Vault.Save(); } }
                Loc.SetLanguage(next); Build(); UpdateTray(); return Task.CompletedTask;
            });
        }); Grid.SetColumn(language, 1); titlebar.Children.Add(language);
        var theme = _theme.Button(Loc.T(_theme.Dark ? "라이트" : "다크"), () =>
        {
            _ = RunAsync(_ =>
            {
                var next = new DeskTheme(!_theme.Dark);
                if (_service != null) { lock (_service.Vault.SyncRoot) { _service.Vault.Data.Theme = next.Dark ? "dark" : "light"; _service.Vault.Save(); } }
                _theme = next; Build(); return Task.CompletedTask;
            });
        }); Grid.SetColumn(theme, 2); titlebar.Children.Add(theme);
        _settingsButton = _theme.IconButton(DeskButtonIconKind.More, Loc.T("설정"), OpenSettings); _settingsButton.Width = 28; _settingsButton.Padding = new Thickness(0);
        Grid.SetColumn(_settingsButton, 3); titlebar.Children.Add(_settingsButton); shell.Children.Add(titlebar);
        var toolbar = new Grid { ColumnDefinitions = new ColumnDefinitions("Auto,Auto,Auto,*,118,174"), Margin = new Thickness(8, 1) };
        _add = _theme.Button(Loc.T("계정 추가"), () => _ = AddAccountAsync()); toolbar.Children.Add(_add);
        _cancel = _theme.Button(Loc.T("취소"), () => { _login?.Cancel(); _switch?.Cancel(); }); _cancel.IsVisible = _login != null || _switch != null;
        Grid.SetColumn(_cancel, 1); toolbar.Children.Add(_cancel);
        _refresh = _theme.IconButton(DeskButtonIconKind.Refresh, Loc.T("새로 고침"), () => _ = RefreshAsync()); _refresh.Width = 28; _refresh.Padding = new Thickness(0);
        ToolTip.SetTip(_refresh, Loc.T("새로 고침") + " (⌘R / F5)"); Grid.SetColumn(_refresh, 2); toolbar.Children.Add(_refresh);
        _sessionValues = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
        Grid.SetColumn(_sessionValues, 4); toolbar.Children.Add(_sessionValues);
        _hardware = new Grid { Margin = new Thickness(6, 0, 0, 0) }; Grid.SetColumn(_hardware, 5); toolbar.Children.Add(_hardware); Grid.SetRow(toolbar, 1); shell.Children.Add(toolbar);
        _accounts = new Grid { Margin = new Thickness(4, 2) };
        _accountScroll = new ScrollViewer { Content = _accounts, HorizontalScrollBarVisibility = Avalonia.Controls.Primitives.ScrollBarVisibility.Disabled };
        _accountScroll.SizeChanged += (_, _) => ResizeAccounts(); Grid.SetRow(_accountScroll, 2); shell.Children.Add(_accountScroll);
        var footer = new Grid { ColumnDefinitions = new ColumnDefinitions("*,Auto"), Margin = new Thickness(8, 2) };
        _volumes = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 6 }; footer.Children.Add(_volumes);
        _status = _theme.Text(_statusMessage, 10, "muted"); ToolTip.SetTip(_status, _statusMessage); _status.MaxWidth = 150; _status.VerticalAlignment = VerticalAlignment.Center;
        Grid.SetColumn(_status, 1); footer.Children.Add(_status); Grid.SetRow(footer, 3); shell.Children.Add(footer); Content = shell;
        RenderAccounts(); RenderSessions(); RenderHardware(); RenderVolumes();
    }
    private void RenderAccounts()
    {
        _accounts.Children.Clear(); _accounts.ColumnDefinitions.Clear(); _accounts.RowDefinitions.Clear(); _cards.Clear();
        if (_tray != null) UpdateTray();
        _add.IsEnabled = _ready && _login == null; _cancel.IsVisible = _login != null || _switch != null;
        _refresh.IsEnabled = !_initializing && _preview == null;
        var profiles = (_preview ?? _service?.Accounts ?? Array.Empty<AccountProfile>()).OrderByDescending(p => p.IsCurrent).ThenBy(p => p.DisplayName, StringComparer.CurrentCulture).ToArray();
        if (profiles.Length == 0)
        {
            var message = _theme.Text(Loc.T("현재 계정을 가져오거나 다른 계정으로 로그인하세요."), 13, "muted");
            message.HorizontalAlignment = HorizontalAlignment.Center; message.VerticalAlignment = VerticalAlignment.Center;
            message.TextWrapping = TextWrapping.Wrap; message.Margin = new Thickness(24); _accounts.Children.Add(message); ResizeAccounts(); return;
        }
        var columns = profiles.Length == 1 ? 1 : 2;
        for (var i = 0; i < columns; i++) _accounts.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        for (var i = 0; i < (profiles.Length + columns - 1) / columns; i++) _accounts.RowDefinitions.Add(new RowDefinition(GridLength.Star) { MinHeight = 126 });
        for (var i = 0; i < profiles.Length; i++)
        {
            var profile = profiles[i]; var pending = _service?.Vault.Data.PendingSwitch;
            var resume = pending?.TargetAccountKey == profile.Key && profile.IsCurrent;
            var activeSwitch = _switchTarget == profile.Key && _switch != null;
            var text = activeSwitch ? _phase == SwitchPhase.BackingUp ? "백업 중" : _phase == SwitchPhase.Resuming ? "재개 중" : "전환 중" :
                resume ? "채팅 재개" : profile.RequiresApply ? "로그인 적용" : profile.IsCurrent ? "사용 중" : "전환";
            var button = _theme.Button(Loc.T(text), () => _ = SwitchAsync(profile));
            button.IsEnabled = _ready && _switch == null && (!profile.IsCurrent || profile.RequiresApply || resume);
            button.FontSize = 10; button.Padding = new Thickness(5, 2);
            var more = _theme.IconButton(DeskButtonIconKind.More, Loc.T("계정 메뉴"), () => { }); more.Width = 25; more.Padding = new Thickness(3, 2);
            more.Click += (_, _) => AccountMenu(more, profile);
            var card = new MacAccountCard(profile, MacAccountCard.Select(profile, _quotas.GetValueOrDefault(profile.Key)), _theme, button, more,
                choice => { _quotas[profile.Key] = choice; RenderAccounts(); });
            Grid.SetColumn(card, i % columns); Grid.SetRow(card, i / columns); _accounts.Children.Add(card); _cards.Add(card);
        }
        ResizeAccounts();
    }
    private void ResizeAccounts() => _accounts.Height = Math.Max(Math.Max(0, _accountScroll.Bounds.Height - 4), _accounts.RowDefinitions.Count * 126);
    internal void Preview(string language, bool dark, AccountProfile[] profiles)
    { Loc.SetLanguage(language); _theme = new(dark); _preview = profiles; Build(); UpdateTray(); }
    internal IReadOnlyList<MacAccountCard> Cards => _cards;
    internal ScrollViewer AccountScroll => _accountScroll;
    private async Task RunAsync(Func<CancellationToken, Task> action)
    {
        if (Exiting) return;
        var completion = new TaskCompletionSource(); _operations.Add(completion.Task);
        _statusMessage = ""; _status.Text = ""; ToolTip.SetTip(_status, null);
        try { await action(_stop.Token); }
        catch (OperationCanceledException) { _statusMessage = Loc.T("취소"); }
        catch (Exception error) { _statusMessage = Loc.Error(UserErrors.Describe(error)); }
        finally
        {
            _status.Text = _statusMessage; ToolTip.SetTip(_status, _statusMessage);
            _operations.Remove(completion.Task); completion.SetResult(); if (!Exiting) RenderAccounts();
        }
    }
    private async Task AddAccountAsync()
    {
        if (!_ready || _login != null) return;
        _login = CancellationTokenSource.CreateLinkedTokenSource(_stop.Token); RenderAccounts();
        try
        {
            await RunAsync(async _ =>
            {
                var registration = await _service!.AddAccountAsync(uri => Process.Start(new ProcessStartInfo(uri.AbsoluteUri) { UseShellExecute = true })?.Dispose(), _login.Token);
                await registration.ImmediateRefresh;
            });
        }
        finally { _login.Dispose(); _login = null; if (!Exiting) RenderAccounts(); }
    }
    private async Task SwitchAsync(AccountProfile profile)
    {
        if (!_ready || _switch != null) return;
        _switch = CancellationTokenSource.CreateLinkedTokenSource(_stop.Token); _switchTarget = profile.Key; _phase = SwitchPhase.BackingUp; RenderAccounts();
        try
        {
            await RunAsync(async _ =>
            {
                _service!.CheckCredentialBackend(profile);
                await using var backend = new DesktopSwitchBackend(_service, _sessions);
                var coordinator = new AccountSwitchCoordinator(backend,
                    plan => { lock (_service.Vault.SyncRoot) { _service.Vault.Data.PendingSwitch = plan; _service.Vault.Save(); } },
                    plan => OnUi(() => { _phase = plan.Phase; RenderAccounts(); }));
                var pending = _service.Vault.Data.PendingSwitch;
                if (pending != null && pending.TargetAccountKey != profile.Key) throw new InvalidOperationException(Loc.T("남은 채팅 재개 작업을 먼저 처리해 주세요."));
                var plan = pending ?? await coordinator.PrepareAsync(profile.Key, DateTimeOffset.UtcNow, _switch.Token);
                await coordinator.RunAsync(plan, _switch.Token);
                await _service.RefreshAccountAsync(profile.Key, _stop.Token, true);
            });
        }
        finally { _switch.Dispose(); _switch = null; _switchTarget = null; if (!Exiting) RenderAccounts(); }
    }
    private void AccountMenu(Button target, AccountProfile profile)
    {
        MenuItem Item(string text, Action action) { var item = new MenuItem { Header = text }; item.Click += (_, _) => action(); return item; }
        var menu = new ContextMenu { ItemsSource = new[] {
            Item("History", () => new HistoryWindow(_service!, profile.Key, _theme).Show(this)),
            Item(Loc.T("이 계정 즉시 새로 고침"), () => _ = RunAsync(token => _service!.RefreshAccountAsync(profile.Key, token, true))),
            Item(Loc.T("이름 변경"), async () => { var value = await DeskDialogs.Prompt(this, _theme, Loc.T("이름 변경"), profile.Alias); if (value != null) await RunAsync(_ => { _service!.Rename(profile.Key, value); return Task.CompletedTask; }); }),
            Item(Loc.T("삭제"), async () => { if (_switch != null) return; if (await DeskDialogs.Confirm(this, _theme, Loc.T("삭제"), profile.DisplayName)) await RunAsync(_ => _service!.RemoveAsync(profile.Key)); }) } };
        menu.Open(target);
    }
    private void RenderSessions()
    {
        _sessionValues.Children.Clear(); var current = _sessions.Current;
        var numbers = new int?[] { current.Available ? current.Running : null, current.Available ? current.Queued : null, current.Available ? current.Goals : null };
        var labels = new[] { "실행", "큐", "목표" };
        for (var i = 0; i < 3; i++)
        {
            var cell = new StackPanel { Width = 39 }; var label = _theme.Text(Loc.T(labels[i]), 10, "muted"); label.HorizontalAlignment = HorizontalAlignment.Center;
            var value = _theme.Text(numbers[i]?.ToString(Loc.Culture) ?? "—", 16); value.HorizontalAlignment = HorizontalAlignment.Center; value.FontWeight = FontWeight.SemiBold;
            cell.Children.Add(label); cell.Children.Add(value); _sessionValues.Children.Add(cell);
        }
        ToolTip.SetTip(_sessionValues, current.Available ? Loc.F("승인/입력 대기 {0}", current.Waiting) + "\n" +
            (current.Queued.HasValue ? Loc.F("큐는 예약 메시지 수\n보류된 큐 {0}", current.PausedQueued) : Loc.Error(current.QueueProblem ?? "큐 상태 확인 중…")) + "\n" + Loc.F("목표는 진행 중인 Goal 수\n멈춘 목표 {0}", current.PausedGoals) : Loc.Error(current.Problem ?? "채팅 상태 확인 중…"));
    }
    private void RenderHardware()
    {
        _hardware.Children.Clear(); _hardware.ColumnDefinitions.Clear(); var usage = _resources.Current;
        var readings = new[] { usage.Cpu, usage.Memory, usage.Gpu, usage.Vram }; var labels = new[] { "CPU", "MEM", "GPU", "VRAM" };
        for (var i = 0; i < 4; i++)
        {
            var index = i; _hardware.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star)); var reading = readings[i]; _pressure[i] = HardwareMath.Pressure(reading.Percent, _pressure[i]);
            var color = _pressure[i] switch { ResourcePressure.Warning => "warning", ResourcePressure.Critical => "danger", ResourcePressure.Unknown => "muted", _ => "accent" };
            var cell = new Grid { ClipToBounds = true, Margin = new Thickness(1) };
            var chart = new PercentChart { Palette = _theme, ColorName = color, Points = (usage.History ?? Array.Empty<HardwareObservation>()).Select(p =>
                new ResourceTrendPoint(p.At, index switch { 0 => p.Cpu, 1 => p.Memory, 2 => p.Gpu, _ => p.Vram })).ToArray() }; cell.Children.Add(chart);
            var text = new StackPanel { VerticalAlignment = VerticalAlignment.Center }; var label = _theme.Text(labels[i], 9, "muted"); label.HorizontalAlignment = HorizontalAlignment.Center;
            var value = _theme.Text(reading.Percent is double actual ? actual.ToString("0", Loc.Culture) + "%" : "—", 12, _pressure[i] is ResourcePressure.Warning or ResourcePressure.Critical ? color : "text"); value.HorizontalAlignment = HorizontalAlignment.Center;
            text.Children.Add(label); text.Children.Add(value); cell.Children.Add(text);
            ToolTip.SetTip(cell, (reading.Device ?? labels[i]) + "\n" + (reading.Problem == null ? "70% warning / 85% critical" : Loc.Error(reading.Problem)) +
                (reading.UsedBytes.HasValue && reading.TotalBytes.HasValue ? "\n" + (reading.UsedBytes.Value / 1073741824.0).ToString("0.##") + " / " + (reading.TotalBytes.Value / 1073741824.0).ToString("0.##") + " GiB" : ""));
            Grid.SetColumn(cell, i); _hardware.Children.Add(cell);
        }
    }
    private void RenderVolumes()
    {
        _volumes.Children.Clear();
        var readings = _drives.Current;
        var visibleCount = Math.Min(readings.Length, Math.Max(1, (int)((Bounds.Width - 170) / 91)));
        foreach (var drive in readings.Take(visibleCount))
        {
            var width = Math.Min(160, Math.Max(85, (Bounds.Width - 170) / visibleCount - 6));
            var cell = new Grid { Width = width, Height = 22, ClipToBounds = true };
            cell.Children.Add(new Border { Background = _theme.Brush("surface"), CornerRadius = new CornerRadius(6) });
            if (drive.FreePercent is double value) cell.Children.Add(new Border { Width = width * value / 100, HorizontalAlignment = HorizontalAlignment.Left, Background = _theme.Brush(value <= 15 ? "danger" : value <= 30 ? "warning" : "selected"), CornerRadius = new CornerRadius(6) });
            var text = _theme.Text(drive.Label + " " + (drive.Free.HasValue ? (drive.Free.Value / 1073741824.0).ToString("0.#", Loc.Culture) + " GiB" : "—"), 10);
            text.Margin = new Thickness(5, 2); cell.Children.Add(text);
            ToolTip.SetTip(cell, drive.Root + (drive.Total.HasValue ? "\n" + (drive.Free!.Value / 1073741824.0).ToString("0.##", Loc.Culture) + " / " +
                (drive.Total.Value / 1073741824.0).ToString("0.##", Loc.Culture) + " GiB" : "\n—")); _volumes.Children.Add(cell);
        }
        ToolTip.SetTip(_volumes, string.Join("\n", readings.Select(d => d.Label + " · " + d.Root + " · " +
            (d.Free.HasValue ? (d.Free.Value / 1073741824.0).ToString("0.##", Loc.Culture) + " GiB" : "—"))));
    }
    private void OpenSettings()
    {
        if (_service == null) return;
        var menu = new ContextMenu();
        var auto = new MenuItem { Header = Loc.T("자동 갱신"), ToggleType = MenuItemToggleType.CheckBox, IsChecked = _service.Vault.Data.AutoRefresh };
        auto.Click += (_, _) => _ = RunAsync(_ => { lock (_service.Vault.SyncRoot) { _service.Vault.Data.AutoRefresh = auto.IsChecked; _service.Vault.Save(); } return Task.CompletedTask; });
        var drives = new MenuItem { Header = Loc.T("드라이브 설정") }; drives.Click += async (_, _) =>
        {
            var selection = await DeskDialogs.Volumes(this, _theme, _service.Vault.Data.Drives.ToArray());
            if (selection != null) await RunAsync(_ => { lock (_service.Vault.SyncRoot) { _service.Vault.Data.Drives = selection.ToList(); _service.Vault.Save(); } _drives.Configure(selection); return Task.CompletedTask; });
        };
        var current = new MenuItem { Header = Loc.T("현재 계정 가져오기") }; current.Click += async (_, _) => await RefreshAsync();
        var quit = new MenuItem { Header = Loc.T("종료") }; quit.Click += async (_, _) => await ExitAsync();
        menu.ItemsSource = new[] { auto, drives, current, quit }; menu.Open(_settingsButton);
    }
    private void UpdateTray()
    {
        if (_tray == null)
        {
            _tray = new MacMenuBar();
            NativeMenuItem Item(string key, string text, Action action, KeyGesture? gesture = null)
            {
                var item = new NativeMenuItem(Loc.T(text)) { Gesture = gesture };
                item.Click += (_, _) => action(); _nativeItems.Add(key, item); return item;
            }
            void OpenWindow() { Show(); Activate(); }
            void Add() { OpenWindow(); _ = AddAccountAsync(); }
            _tray.Add("show", Loc.T("열기"), OpenWindow); _tray.Add("add", Loc.T("계정 추가"), Add);
            _tray.Add("refresh", Loc.T("새로 고침"), () => _ = RefreshAsync());
            _tray.Add("cancel", Loc.T("취소"), () => { _login?.Cancel(); _switch?.Cancel(); });
            _tray.Separator(); _tray.Add("quit", Loc.T("종료"), () => _ = ExitAsync());
            var actions = new NativeMenu();
            actions.Add(Item("open", "열기", OpenWindow, new KeyGesture(Key.O, KeyModifiers.Meta)));
            actions.Add(Item("accounts", "계정 추가", Add, new KeyGesture(Key.N, KeyModifiers.Meta)));
            actions.Add(Item("update", "새로 고침", () => _ = RefreshAsync(), new KeyGesture(Key.R, KeyModifiers.Meta)));
            actions.Add(new NativeMenuItemSeparator()); actions.Add(Item("close", "닫기", Hide, new KeyGesture(Key.W, KeyModifiers.Meta)));
            var appMenu = new NativeMenu(); var root = new NativeMenuItem(Loc.T("Codex 계정")) { Menu = actions };
            _nativeItems.Add("root", root); appMenu.Add(root); NativeMenu.SetMenu(Application.Current!, appMenu);
        }
        foreach (var (key, text) in new[] { ("open", "열기"), ("accounts", "계정 추가"), ("update", "새로 고침"), ("close", "닫기"), ("root", "Codex 계정") }) _nativeItems[key].Header = Loc.T(text);
        _nativeItems["accounts"].IsEnabled = _ready && _login == null;
        _nativeItems["update"].IsEnabled = !_initializing && _preview == null;
        _tray.SetItem("show", Loc.T("열기"), true); _tray.SetItem("quit", Loc.T("종료"), true);
        _tray.SetItem("add", Loc.T("계정 추가"), _ready && _login == null);
        _tray.SetItem("refresh", Loc.T("새로 고침"), !_initializing && _preview == null);
        _tray.SetItem("cancel", Loc.T("취소"), _login != null || _switch != null);
        var profile = (_preview ?? _service?.Accounts)?.FirstOrDefault(p => p.IsCurrent);
        var quota = profile == null ? null : MacAccountCard.Select(profile, _quotas.GetValueOrDefault(profile.Key));
        var value = quota == null ? "—" : quota.Window.Remaining.ToString("0.#", Loc.Culture) + "%";
        var tooltip = "Codex Switch\n" + Loc.T("잔여량") + " " + value + (quota == null ? "" : " · " + quota.Window.PeriodLabel);
        if (profile?.Error != null) tooltip += "\n" + Loc.Error(profile.Error);
        _tray.Update(value, tooltip);
    }
    internal MenuBarState? MenuBarProbe => _tray?.Probe();
    public async Task ExitAsync()
    {
        if (Exiting) return; Exiting = true; _clock.Stop(); _stop.Cancel(); _login?.Cancel(); _switch?.Cancel();
        if (_service != null) await _service.StopAsync();
        await Task.WhenAll(_operations.ToArray());
        await _sessions.DisposeAsync(); await _resources.DisposeAsync(); await _drives.DisposeAsync(); _tray?.Dispose();
        Close(); (Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.Shutdown(Program.DiagnosticExitCode);
    }
}
