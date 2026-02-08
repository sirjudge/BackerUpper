using Terminal.Gui;
using BackerUpperCli.Views;

namespace BackerUpperCli.Windows;

public enum UserAction {
    Configuration,
    Backup,
    Restore
}

public class ActionWindow : Window {

    private bool IsRunning { get; set; }

    public ActionWindow(UserAction userAction, IApplication app){
        switch (userAction) {
            case UserAction.Backup:
                IsRunning = true;
                Add(new BackupView());
                break;
            case UserAction.Configuration:
                Add(new FileConfig());
                break;
            case UserAction.Restore:
                Add(new RestoreView());
                IsRunning = true;
                break;
        }

        KeyDown += (_, e) =>
        {
            switch (e.KeyCode)
            {
                //TODO: Should add some kind of extra key or something, too easy
                //to hit Q mid run
                case KeyCode.Q:
                    app.Run(new GoodbyeWindow(app));
                    break;
                case KeyCode.Esc:
                    ClearViewport();
                    app.Run(new MainWindow(app));
                    break;
            }
            e.Handled = true;
        };
    }
}
