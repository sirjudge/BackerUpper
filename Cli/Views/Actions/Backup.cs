using Terminal.Gui;
using Cli.Styles;

namespace Cli.Views.Actions;

public class BackupView : View {
    public BackupView() {
        Title = "Backup";
        Width = Dim.Percent(75);
        Height = Dim.Fill();
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
    }
}
