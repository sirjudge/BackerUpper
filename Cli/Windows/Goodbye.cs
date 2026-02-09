using Terminal.Gui;
using Cli.Views;
using Cli.Styles;

namespace Cli.Windows;


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
