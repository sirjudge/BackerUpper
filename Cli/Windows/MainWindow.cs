using Cli.Views;
using Cli.Styles;
using Terminal.Gui.App;
using Terminal.Gui.Views;
using Terminal.Gui.Drivers;
using Terminal.Gui.Configuration;

namespace Cli.Windows;

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


    private void ApplyTheme(){
        string [] options = ThemeManager.GetThemeNames ().Select (option => "_" + option).ToArray ();
    }
}
