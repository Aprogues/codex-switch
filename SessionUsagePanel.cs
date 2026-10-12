using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CodexAccountDesk;

internal sealed class SessionUsagePanel : Grid
{
    private readonly TextBlock[] _labels = new TextBlock[3], _values = new TextBlock[3];
    public string Text => string.Join("   ", _labels.Select((label, index) => label.Text + " " + _values[index].Text));
    public SessionUsagePanel()
    {
        Width = 118; Height = 34; HorizontalAlignment = HorizontalAlignment.Right; VerticalAlignment = VerticalAlignment.Center;
        RowDefinitions.Add(new() { Height = new GridLength(14) }); RowDefinitions.Add(new());
        for (var index = 0; index < 3; index++)
        {
            ColumnDefinitions.Add(new());
            _labels[index] = new() { FontSize = 10, LineHeight = 14, LineStackingStrategy = LineStackingStrategy.BlockLineHeight, HorizontalAlignment = HorizontalAlignment.Center };
            _values[index] = new() { FontSize = 17, LineHeight = 20, LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                FontWeight = FontWeights.SemiBold, HorizontalAlignment = HorizontalAlignment.Center };
            SetColumn(_labels[index], index); SetColumn(_values[index], index); SetRow(_values[index], 1);
            Children.Add(_labels[index]); Children.Add(_values[index]);
        }
    }
    public void Refresh(SessionActivity activity, Burn0Theme theme)
    {
        var labels = new[] { "실행", "큐", "목표" };
        var values = new int?[] { activity.Available ? activity.Running : null, activity.Available ? activity.Queued : null, activity.Available ? activity.Goals : null };
        for (var index = 0; index < 3; index++)
        {
            _labels[index].Text = Loc.T(labels[index]); _labels[index].FontFamily = theme.Font; _labels[index].Foreground = theme.Color("muted");
            _values[index].Text = values[index]?.ToString(Loc.Culture) ?? "—"; _values[index].FontFamily = theme.Font;
            _values[index].Foreground = theme.Color(values[index].HasValue ? "text" : "muted");
        }
    }
    public bool Fits() => _labels.Concat(_values).All(element => element.DesiredSize.Width <= ActualWidth / 3 + 0.5 &&
        element.ActualHeight <= (GetRow(element) == 0 ? 14.5 : 20.5));
}
