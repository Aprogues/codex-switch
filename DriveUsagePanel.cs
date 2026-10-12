using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CodexAccountDesk;

internal sealed class DriveUsagePanel : Grid
{
    private readonly Action _settings;
    public DriveUsagePanel(Action settings) { _settings = settings; Height = 24; Margin = new Thickness(0, 0, 8, 0); }
    public void Refresh(DriveReading[] readings, Burn0Theme theme)
    {
        Children.Clear(); ColumnDefinitions.Clear();
        foreach (var reading in readings)
        {
            ColumnDefinitions.Add(new());
            var color = reading.FreePercent is double free ? free <= 15 ? "danger" : free <= 30 ? "warning" : "accent" : "muted";
            var cell = new Grid { Margin = new Thickness(0, 2, 4, 2) };
            var track = new Border { Background = theme.Color("surface"), CornerRadius = new CornerRadius(3) }; cell.Children.Add(track);
            var fillBrush = new SolidColorBrush(theme.Color(color).Color) { Opacity = 0.19 }; fillBrush.Freeze();
            var fill = new Border { Background = fillBrush, HorizontalAlignment = HorizontalAlignment.Left, CornerRadius = new CornerRadius(3) }; cell.Children.Add(fill);
            cell.SizeChanged += (_, _) => fill.Width = cell.ActualWidth * (reading.FreePercent ?? 0) / 100;
            var label = string.IsNullOrWhiteSpace(reading.Label) ? reading.Root[..2] : reading.Label;
            var text = new TextBlock { Text = label + " " + (reading.Free.HasValue ? (reading.Free.Value / 1073741824.0).ToString("0.#", Loc.Culture) + " GiB" : "—"),
                FontFamily = theme.Font, FontSize = 11, FontWeight = FontWeights.SemiBold, Foreground = theme.Color(color is "warning" or "danger" ? color : "text"),
                VerticalAlignment = VerticalAlignment.Center, TextTrimming = TextTrimming.CharacterEllipsis, Margin = new Thickness(5, 0, 4, 0) };
            cell.Children.Add(text);
            cell.ToolTip = label + " · " + reading.Root + "\n" + (reading.Free.HasValue ? Loc.F("남음 {0:0.##} / {1:0.##} GiB · {2:0.0}%", reading.Free.Value / 1073741824.0, reading.Total!.Value / 1073741824.0, reading.FreePercent) : Loc.T("드라이브 조회 불가"));
            Grid.SetColumn(cell, Children.Count); Children.Add(cell);
        }
        ColumnDefinitions.Add(new() { Width = GridLength.Auto });
        var button = new Button { Content = "···", Width = 22, MinHeight = 20, Height = 22, Padding = new Thickness(0), Foreground = theme.Color("muted"), Background = Brushes.Transparent, BorderThickness = new Thickness(0), ToolTip = Loc.T("드라이브 설정") };
        button.Click += (_, _) => _settings(); Grid.SetColumn(button, readings.Length); Children.Add(button);
    }
}
