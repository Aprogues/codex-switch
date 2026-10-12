using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Automation;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;
using AButton = Avalonia.Controls.Button;

namespace CodexAccountDesk;

internal sealed class DeskTheme
{
    private readonly Dictionary<string, string> _tokens = new();
    public bool Dark { get; }
    public DeskTheme(bool dark)
    {
        Dark = dark;
        using var stream = typeof(DeskTheme).Assembly.GetManifestResourceStream("CodexAccountDesk.Burn0Tokens.css")!;
        using var reader = new StreamReader(stream); var css = reader.ReadToEnd();
        Load(Regex.Match(css, @":root\s*\{([\s\S]*?)\}").Groups[1].Value);
        if (dark) Load(Regex.Match(css, @":root\.dark\s*\{([\s\S]*?)\}").Groups[1].Value);
    }
    private void Load(string block) { foreach (Match token in Regex.Matches(block, @"--burn0-([a-z-]+)\s*:\s*([^;]+);")) _tokens[token.Groups[1].Value] = token.Groups[2].Value.Trim(); }
    public SolidColorBrush Brush(string name)
    {
        var value = _tokens[name];
        if (value.StartsWith("rgb(var(--burn0-", StringComparison.Ordinal))
        {
            var key = Regex.Match(value, @"var\(--burn0-([a-z-]+)\)").Groups[1].Value;
            var parts = _tokens[key].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return new(Color.FromRgb(byte.Parse(parts[0]), byte.Parse(parts[1]), byte.Parse(parts[2])));
        }
        return new(Color.Parse(value));
    }
    public void Apply(Window window)
    {
        window.Background = Brush("canvas"); window.Foreground = Brush("text"); window.FontFamily = new FontFamily("Helvetica Neue");
        window.RequestedThemeVariant = Dark ? ThemeVariant.Dark : ThemeVariant.Light;
        window.Styles.Clear();
        window.Styles.Add(new Style(selector => selector.OfType<Button>()) { Setters = {
            new Setter(AButton.BackgroundProperty, Brush("surface")), new Setter(AButton.ForegroundProperty, Brush("text")),
            new Setter(AButton.BorderThicknessProperty, new Thickness(0)), new Setter(AButton.CornerRadiusProperty, new CornerRadius(8)),
            new Setter(AButton.HorizontalContentAlignmentProperty, HorizontalAlignment.Center), new Setter(AButton.VerticalContentAlignmentProperty, VerticalAlignment.Center),
            new Setter(AButton.MinHeightProperty, 26.0), new Setter(AButton.PaddingProperty, new Thickness(8, 3)), new Setter(AButton.FontSizeProperty, 12.0) } });
        window.Styles.Add(new Style(selector => selector.OfType<AButton>().Class(":pointerover")) { Setters = { new Setter(AButton.BackgroundProperty, Brush("hover")) } });
        window.Styles.Add(new Style(selector => selector.OfType<AButton>().Class(":disabled")) { Setters = { new Setter(AButton.OpacityProperty, 0.5) } });
    }
    public TextBlock Text(string value, double size = 12, string color = "text") => new() { Text = value, FontSize = size, Foreground = Brush(color), TextTrimming = TextTrimming.CharacterEllipsis };
    public Button Button(string value, Action action) { var button = new Button { Content = value }; button.Click += (_, _) => action(); return button; }
    public Button IconButton(DeskButtonIconKind kind, string label, Action action)
    {
        var button = Button("", action); button.Content = new DeskButtonIcon(kind, Brush("text"));
        AutomationProperties.SetName(button, label); ToolTip.SetTip(button, label); return button;
    }
}
