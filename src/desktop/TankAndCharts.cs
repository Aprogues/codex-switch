using System;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Automation;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;

namespace CodexAccountDesk;

internal sealed class TankSurface : Control
{
    private readonly DeskTheme _theme;
    private readonly double? _remaining;
    private readonly bool _active;
    private readonly Stopwatch _clock = Stopwatch.StartNew();
    private readonly DispatcherTimer _motion = new() { Interval = TimeSpan.FromMilliseconds(60) };
    public TankSurface(DeskTheme theme, double? remaining, bool active)
    {
        _theme = theme; _remaining = remaining; _active = active; IsHitTestVisible = false;
        _motion.Tick += (_, _) => { if (TopLevel.GetTopLevel(this) is Window { IsVisible: true, WindowState: not WindowState.Minimized }) InvalidateVisual(); };
        AttachedToVisualTree += (_, _) => { if (_active && _remaining is > 0 and < 100) _motion.Start(); };
        DetachedFromVisualTree += (_, _) => _motion.Stop();
    }
    public override void Render(DrawingContext context)
    {
        var rect = new Rect(Bounds.Size);
        context.DrawRectangle(_theme.Brush("surface"), null, rect, 8, 8);
        if (_remaining is not double remaining || remaining <= 0 || rect.Height <= 0) return;
        var color = _theme.Brush(remaining < 15 ? "warning" : "accent").Color;
        var fill = new SolidColorBrush(Color.FromArgb((byte)(_theme.Dark ? 45 : 24), color.R, color.G, color.B));
        var water = rect.Height * (1 - remaining / 100);
        var geometry = new StreamGeometry();
        using (var path = geometry.Open())
        {
            path.BeginFigure(new Point(0, rect.Height), true);
            path.LineTo(new Point(0, water));
            for (var i = 0; i <= 32; i++)
            {
                var x = rect.Width * i / 32;
                var wave = _active && remaining < 100 ? Math.Sin(i / 32.0 * Math.PI * 2 + _clock.Elapsed.TotalSeconds * 1.6) * 1.8 : 0;
                path.LineTo(new Point(x, water + wave));
            }
            path.LineTo(new Point(rect.Width, rect.Height)); path.EndFigure(true);
        }
        using (context.PushClip(new RoundedRect(rect, 8))) context.DrawGeometry(fill, null, geometry);
    }
}

internal sealed class PercentChart : Control
{
    public ResourceTrendPoint[] Points { get; set; } = Array.Empty<ResourceTrendPoint>();
    public required DeskTheme Palette { get; set; }
    public string ColorName { get; set; } = "accent";
    public override void Render(DrawingContext context)
    {
        var points = Points;
        if (points.Length == 0 || Bounds.Width <= 0 || Bounds.Height <= 0) return;
        var start = points[0].At; var span = Math.Max(1, (points[^1].At - start).TotalSeconds);
        var color = Palette.Brush(ColorName); var pen = new Pen(color, 1.2);
        Point Position(ResourceTrendPoint point) => new((point.At - start).TotalSeconds / span * Bounds.Width, (1 - point.Percent!.Value / 100) * Bounds.Height);
        foreach (var segment in ResourceTrend.Segments(points))
        {
            if (segment.Length == 1) { context.DrawEllipse(color, null, Position(segment[0]), 1.5, 1.5); continue; }
            var area = new StreamGeometry();
            using (var path = area.Open())
            {
                path.BeginFigure(new Point(Position(segment[0]).X, Bounds.Height), true);
                foreach (var point in segment) path.LineTo(Position(point));
                path.LineTo(new Point(Position(segment[^1]).X, Bounds.Height)); path.EndFigure(true);
            }
            var c = color.Color; context.DrawGeometry(new SolidColorBrush(Color.FromArgb(28, c.R, c.G, c.B)), null, area);
            for (var i = 1; i < segment.Length; i++) context.DrawLine(pen, Position(segment[i - 1]), Position(segment[i]));
        }
    }
}

internal sealed class HistoryChart : Control
{
    public UsageObservation[] Points { get; set; } = Array.Empty<UsageObservation>();
    public required DeskTheme Palette { get; set; }
    public int Hours { get; set; } = 24;
    private DateTimeOffset _now = DateTimeOffset.UtcNow;
    private Rect Plot => new(40, 34, Math.Max(0, Bounds.Width - 48), Math.Max(0, Bounds.Height - 60));
    internal static Point Project(UsageObservation point, Rect plot, DateTimeOffset start, DateTimeOffset end) => new(
        plot.Left + Math.Clamp((point.At - start).TotalSeconds / Math.Max(1, (end - start).TotalSeconds), 0, 1) * plot.Width,
        plot.Bottom - Math.Clamp(point.UsedPercent, 0, 100) / 100 * plot.Height);
    internal static bool Connects(UsageObservation previous, UsageObservation next) => previous.Segment == next.Segment &&
        next.At >= previous.At && next.At - previous.At <= TimeSpan.FromMinutes(20);
    public void Update(DateTimeOffset now)
    {
        var changedMinute = now.ToUnixTimeSeconds() / 60 != _now.ToUnixTimeSeconds() / 60;
        _now = now;
        if (changedMinute) InvalidateVisual();
    }
    public override void Render(DrawingContext context)
    {
        if (Bounds.Width < 100 || Bounds.Height < 90) return;
        var now = _now; var start = now.AddHours(-Math.Max(1, Hours));
        var points = Points.Where(p => p.At >= start && p.At <= now).OrderBy(p => p.At).ToArray();
        var plot = Plot; var left = plot.Left; var right = plot.Right; var top = plot.Top; var bottom = plot.Bottom;
        AutomationProperties.SetName(this, Loc.T("사용량 추이"));
        AutomationProperties.SetHelpText(this, points.Length == 0 ? Loc.T("조회 기록이 쌓이면 추이를 볼 수 있습니다.")
            : Loc.F("실측 · {0:MM/dd HH:mm:ss} (한국 시간)\n사용 {1:0.##}%", UsagePresentation.KoreanTime(points[^1].At), points[^1].UsedPercent));
        var pen = new Pen(Palette.Brush("accent"), 2);
        Text(Loc.T("사용량 추이"), 0, 0, "text", 12);
        Text(Loc.T("실측"), right, 0, "muted", 11, true);
        foreach (var value in new[] { 0, 25, 50, 75, 100 })
        {
            var y = bottom - value / 100.0 * (bottom - top);
            context.DrawLine(new Pen(Palette.Brush("divider"), 1), new Point(left, y), new Point(right, y));
            Text(value + "%", left - 9, y - 7, "muted", 11, true);
        }
        for (var i = 0; i <= 3; i++)
        {
            var at = start.AddTicks((now - start).Ticks * i / 3);
            var x = left + (right - left) * i / 3;
            var datesDiffer = UsagePresentation.KoreanTime(start).Date != UsagePresentation.KoreanTime(now).Date;
            var label = UsagePresentation.KoreanTime(at).ToString(Hours > 24 ? "MM'/'dd" : datesDiffer && i is 0 or 3 ? "MM'/'dd HH:mm" : "HH:mm", Loc.Culture);
            Text(label, x, bottom + 8, "muted", 11, i == 3, i is 1 or 2);
        }
        Point Position(UsageObservation point) => Project(point, plot, start, now);
        for (var i = 0; i < points.Length; i++)
        {
            if (i > 0 && Connects(points[i - 1], points[i]))
                context.DrawLine(pen, Position(points[i - 1]), Position(points[i]));
            else context.DrawEllipse(Palette.Brush("accent"), null, Position(points[i]), 2, 2);
        }
        if (points.Length > 0)
        {
            var last = Position(points[^1]);
            context.DrawEllipse(Palette.Brush("accent"), new Pen(Palette.Brush("canvas"), 2), last, 4, 4);
            Text(points[^1].UsedPercent.ToString("0.#", Loc.Culture) + "%", right, last.Y < top + 24 ? last.Y + 5 : last.Y - 21, "text", 11, true);
        }
        if (points.Length < 2)
            Text(Loc.T("조회 기록이 쌓이면 추이를 볼 수 있습니다."), (left + right) / 2, (top + bottom) / 2 - 7, "muted", 11, false, true);

        void Text(string value, double x, double y, string token, double size, bool alignRight = false, bool center = false)
        {
            var text = new FormattedText(value, Loc.Culture, FlowDirection.LeftToRight, new Typeface(Palette.Appearance.FontFamily), size, Palette.Brush(token));
            context.DrawText(text, new Point(alignRight ? x - text.Width : center ? x - text.Width / 2 : x, y));
        }
    }
    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
        var position = e.GetPosition(this); var start = _now.AddHours(-Math.Max(1, Hours));
        var points = Points.Where(p => p.At >= start && p.At <= _now).ToArray();
        var nearest = Plot.Contains(position) ? points.MinBy(p => Math.Abs(Project(p, Plot, start, _now).X - position.X)) : null;
        ToolTip.SetTip(this, nearest == null ? null : Loc.F("실측 · {0:MM/dd HH:mm:ss} (한국 시간)\n사용 {1:0.##}%",
            UsagePresentation.KoreanTime(nearest.At), nearest.UsedPercent));
    }
    protected override void OnPointerExited(PointerEventArgs e) { base.OnPointerExited(e); ToolTip.SetTip(this, null); }
}
