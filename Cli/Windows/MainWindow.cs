using Terminal.Gui;
using BackerUpperCli.Views;
using BackerUpperCli.Styles;

namespace BackerUpperCli.Windows;

public class MainWindow : Window {
    public MainWindow(IApplication app) {
        Title = "BackerUpper";
        Border!.LineStyle = DefaultStyles.GetDefaultBorderLineStyle();
        Border!.Thickness = DefaultStyles.GetDefaultBorderThickness();
        Add (new MainMenuView());

        KeyDown += (_, e) =>
        {
            Window? windowToLaunch = null;
            switch (e.KeyCode)
            {
                case KeyCode.B:
                    windowToLaunch = new ActionWindow(UserAction.Backup, app);
                    break;
                case KeyCode.Q:
                    windowToLaunch = new GoodbyeWindow(app);
                    break;
                case KeyCode.R:
                    windowToLaunch = new ActionWindow(UserAction.Restore, app);
                    break;
                case KeyCode.C:
                    windowToLaunch = new ActionWindow(UserAction.Configuration, app);
                    break;
            }

            if (windowToLaunch is not null){
                app.Run(windowToLaunch);
            }

            e.Handled = true;
        };
    }
}
