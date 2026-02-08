using Terminal.Gui;
using BackerUpperCli.Views;
using BackerUpperCli.Styles;

namespace BackerUpperCli.Windows;


public sealed class GoodbyeWindow : Window
{
    public GoodbyeWindow(IApplication app)
    {
        Border!.LineStyle = DefaultStyles.GetDefaultBorderLineStyle();
        Border!.Thickness = DefaultStyles.GetDefaultBorderThickness();
        var mainText = new Label()
        {
            Text = "Exiting. . . Press any key to continue",
            Y = Pos.Center(),
            X = Pos.Center(),
        };
        Add(mainText);

        KeyDown += (_, e) =>
        {
            e.Handled = true;
            app.Shutdown();
        };
    }
}
