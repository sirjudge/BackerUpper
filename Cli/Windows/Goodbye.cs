using Terminal.Gui.Views;
using Terminal.Gui.App;
using Cli.Styles;
using Terminal.Gui.ViewBase;

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
            app.RequestStop();
            app.ClearScreenNextIteration = true;
            Environment.Exit(1);
        };
    }
}
