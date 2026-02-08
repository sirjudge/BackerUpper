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
    private View CurrentView { get; set; }

    public ActionWindow(UserAction userAction, IApplication app){
        Title = "Action Window";
        switch (userAction) {
            case UserAction.Backup:
                var backupView = new BackupView();
                CurrentView = backupView;
                Add(backupView);
                break;
            case UserAction.Configuration:
                var fileView = new FileConfigView();
                CurrentView = fileView;
                Add(fileView);
                break;
            case UserAction.Restore:
                var restoreView = new RestoreView();
                CurrentView = restoreView;
                Add(restoreView);
                break;
        }

        var logView = new LogView(app);
        logView.X = Pos.Right(
            CurrentView??
            throw new InvalidDataException("Current View has not been initialized when Log view is added")
        );
        Add(logView);

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
