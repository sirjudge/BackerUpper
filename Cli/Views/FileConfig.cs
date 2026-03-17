using Terminal.Gui;
using Cli.Styles;

namespace Cli.Views;

public class FileConfigView : View {
    public FileConfigView(){
        Width = Dim.Percent(75);
        Height = Dim.Fill();
        Title = "File Configuration";
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
    }
}
