using Terminal.Gui;
using BackerUpperCli.Views;

namespace BackerUpperCli.Windows;

public enum UserAction {
    Configuration,
    Backup,
    Restore
}

public class ActionWindow : Window {
    public ActionWindow(UserAction userAction, IApplication app){
        switch (userAction) {
            case UserAction.Backup:
                Add(new BackupView());
                break;
            case UserAction.Configuration:
                Add(new FileConfig());
                break;
            case UserAction.Restore:
                Add(new RestoreView());
                break;

        }
    }
}
