using Terminal.Gui;
using BackerUpperCli.Styles;

namespace BackerUpperCli.Views;

public class LogView : View {
    public LogView(IApplication app){
        Title = "Logs";
        Width = Dim.Percent(25);
        Height = Dim.Fill();
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
    }
}
