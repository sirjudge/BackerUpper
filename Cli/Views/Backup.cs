using Terminal.Gui;

namespace BackerUpperCli.Views;

public class BackupView : View {
    public BackupView() {
        Title = "Backup";
        Border!.LineStyle = DefaultStyles.GetDefaultBorderLineStyle();
        Border!.Thickness = DefaultStyles.GetDefaultBorderThickness();
    }
}
