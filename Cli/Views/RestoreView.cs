using Terminal.Gui;
using BackerUpperCli.Styles;

namespace BackerUpperCli.Views;

public class RestoreView : View {
    public RestoreView() {
        Title = "Restore";
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
        Width = Dim.Percent(75);
        Height = Dim.Fill();
    }
}
