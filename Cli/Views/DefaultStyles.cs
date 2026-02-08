using Terminal.Gui;

namespace BackerUpperCli.Views;

public static class DefaultStyles
{
    public static LineStyle GetDefaultBorderLineStyle() =>
        LineStyle.Rounded;

    public static Thickness GetDefaultBorderThickness() =>
        new Thickness(1);
}
