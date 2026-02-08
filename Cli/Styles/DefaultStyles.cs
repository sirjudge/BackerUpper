using Terminal.Gui;

namespace BackerUpperCli.Styles;

public static class DefaultStyles
{
    public static LineStyle GetDefaultBorderLineStyle() =>
        LineStyle.Rounded;

    public static Thickness GetDefaultBorderThickness() =>
        new Thickness(1);
}
