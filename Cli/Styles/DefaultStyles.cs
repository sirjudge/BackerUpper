using Terminal.Gui;

namespace Cli.Styles;

public static class DefaultStyles
{
    public static LineStyle GetDefaultBorderLineStyle() =>
        LineStyle.Rounded;

    public static Thickness GetDefaultBorderThickness()
        => new(1);
}
