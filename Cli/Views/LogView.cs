using Terminal.Gui;

namespace BackerUpperCli.Views;

public class LogView : View {
    public LogView(IApplication app){
        Title = "Logs";
        Width = Dim.Fill();
        Height = Dim.Fill();
    }
}
