using Terminal.Gui;
using BackerUpperCli.Styles;

namespace BackerUpperCli.Views;

public class FileConfigView : View {
    public FileConfigView(){
        Width = Dim.Percent(75);
        Height = Dim.Fill();
        Title = "File Configuration";
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
    }
}
