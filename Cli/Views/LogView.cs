using Terminal.Gui;
using Terminal.Gui.ViewBase;
using Cli.Styles;
using Terminal.Gui.App;

namespace Cli.Views;

public class LogView : View {
    public LogView(IApplication app){
        Title = "Logs";
        Width = Dim.Percent(25);
        Height = Dim.Fill();
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
    }
}
