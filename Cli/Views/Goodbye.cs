using Terminal.Gui;

namespace BackerUpperCli.Views;

public sealed class GoodbyeWindow : Window
{
    public GoodbyeWindow()
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
            Environment.Exit(0);
        };
    }
}
