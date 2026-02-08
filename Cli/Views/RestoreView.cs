using Terminal.Gui;

namespace BackerUpperCli.Views;

public class RestoreView : View {
    public RestoreView() {
        Title = "Restore";
        Border!.LineStyle = DefaultStyles.GetDefaultBorderLineStyle();
        Border!.Thickness = DefaultStyles.GetDefaultBorderThickness();
    }
}
