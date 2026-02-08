using Terminal.Gui;
using BackerUpperCli.Styles;

namespace BackerUpperCli.Views;

public class BackupView : View {
    public BackupView() {
        Title = "Backup";
        Width = Dim.Percent(75);
        Height = Dim.Fill();
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
    }
}
