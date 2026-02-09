using Terminal.Gui;
using Cli.Styles;

namespace Cli.Views;

public class LogView : View {
    public LogView(IApplication app){
        Title = "Logs";
        Width = Dim.Percent(25);
        Height = Dim.Fill();
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
    }
}
