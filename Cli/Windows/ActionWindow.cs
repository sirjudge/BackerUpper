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
                var backupView = new BackupView();
                backupView.X = 1;
                backupView.Y = 1;
                Add();
                break;
            case UserAction.Configuration:
                var fileConfig = new FileConfig();
                fileConfig.X = 1;
                fileConfig.Y = 1;
                Add(fileConfig);
                break;
            case UserAction.Restore:
                var restoreView = new RestoreView();
                restoreView.X = 1;
                restoreView.Y = 1;
                Add(restoreView);
                break;
        }

        Add(new LogView(app));

        KeyDown += (_, e) =>
        {
            switch (e.KeyCode)
            {
                case KeyCode.Q:
                    ClearViewport();
                    app.Run(new GoodbyeWindow(app));
                    break;
                case KeyCode.Esc:
                case KeyCode.M:
                    ClearViewport();
                    app.Run(new MainWindow(app));
                    break;
            }
            e.Handled = true;
        };
    }
}
