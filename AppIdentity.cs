using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CodexAccountDesk;

internal static class AppIdentity
{
    private static readonly BitmapSource Mark = ReadMark();
    private static BitmapSource ReadMark()
    {
        using var stream = typeof(AppIdentity).Assembly.GetManifestResourceStream("CodexAccountDesk.Mark.png")!;
        var image = new BitmapImage(); image.BeginInit(); image.CacheOption = BitmapCacheOption.OnLoad;
        image.StreamSource = stream; image.EndInit(); image.Freeze(); return image;
    }
    public static FrameworkElement Glyph(Brush foreground, double size) => new Border
    {
        Width = size, Height = size, Background = foreground,
        OpacityMask = new ImageBrush(Mark) { Stretch = Stretch.Uniform }
    };
    public static ImageSource WindowIcon => Mark;
    public static System.Drawing.Icon TrayIcon()
    {
        using var stream = typeof(AppIdentity).Assembly.GetManifestResourceStream("CodexAccountDesk.AppIcon.ico")!;
        using var icon = new System.Drawing.Icon(stream, 32, 32);
        return (System.Drawing.Icon)icon.Clone();
    }
}
