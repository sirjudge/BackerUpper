using Terminal.Gui;
using Cli.Styles;

namespace Cli.Views;

public class RestoreView : View {
    public RestoreView() {
        Title = "Restore";
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
        Width = Dim.Percent(75);
        Height = Dim.Fill();
    }
}
