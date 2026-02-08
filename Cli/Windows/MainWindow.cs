using Terminal.Gui;
using BackerUpperCli.Views;

namespace BackerUpperCli.Windows;

public class MainWindow : Window {
    public MainWindow(IApplication app) {
        Title = "BackerUpper";
        Border!.LineStyle = DefaultStyles.GetDefaultBorderLineStyle();
        Border!.Thickness = DefaultStyles.GetDefaultBorderThickness();
        Add (new MainMenuView());

        KeyDown += (_, e) =>
        {
            switch (e.KeyCode)
            {
                case KeyCode.B:
                    app.Run(new ActionWindow(UserAction.Backup, app));
                    break;
                case KeyCode.Q:
                    app.Run(new GoodbyeWindow());
                    break;
                case KeyCode.R:
                    app.Run(new ActionWindow(UserAction.Restore, app));
                    break;
                case KeyCode.C:
                    app.Run(new ActionWindow(UserAction.Configuration, app));
                    break;
            }
            e.Handled = true;
        };
    }
}
