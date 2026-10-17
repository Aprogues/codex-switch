using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CodexAccountDesk;

internal sealed class AccountWarningButton : Button
{
    public AccountWarningButton(string details, Burn0Theme theme)
    {
        Name = "AccountWarningButton"; Width = 20; Height = 20; MinWidth = MinHeight = 0;
        Padding = new Thickness(2); Margin = new Thickness(0, 0, 4, 0); VerticalAlignment = VerticalAlignment.Center;
        Background = Brushes.Transparent; Cursor = Cursors.Hand;
        Content = new Path { Data = Geometry.Parse("M12 3L22 21H2Z M12 9V14 M12 17V17.1"),
            Stroke = theme.Color("warning"), StrokeThickness = 1.8, StrokeLineJoin = PenLineJoin.Round,
            StrokeStartLineCap = PenLineCap.Round, StrokeEndLineCap = PenLineCap.Round,
            Width = 14, Height = 14, Stretch = Stretch.Uniform, IsHitTestVisible = false };
        var tip = new ToolTip { Content = details, Style = ToolTipTheme.StyleFor(theme), PlacementTarget = this, Placement = PlacementMode.Bottom };
        ToolTip = tip; ToolTipService.SetInitialShowDelay(this, 200); ToolTipService.SetShowDuration(this, int.MaxValue);
        AutomationProperties.SetName(this, Loc.T("갱신 필요")); AutomationProperties.SetHelpText(this, details);
        Click += (_, _) => tip.IsOpen = true;
        PreviewKeyDown += (_, args) => { if (args.Key == Key.Escape) { tip.IsOpen = false; args.Handled = true; } };
        LostKeyboardFocus += (_, _) => tip.IsOpen = false;
        IsVisibleChanged += (_, _) => { if (!IsVisible) tip.IsOpen = false; };
        Window? owner = null;
        EventHandler deactivate = (_, _) => tip.IsOpen = false;
        Loaded += (_, _) => { owner = Window.GetWindow(this); if (owner != null) owner.Deactivated += deactivate; };
        Unloaded += (_, _) => { tip.IsOpen = false; if (owner != null) owner.Deactivated -= deactivate; owner = null; };
    }
}
