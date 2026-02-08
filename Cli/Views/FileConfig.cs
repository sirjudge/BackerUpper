using Terminal.Gui;

namespace BackerUpperCli.Views;

public class FileConfig : Window {
    public FileConfig(){
        Title = "File Configuration";
        Border!.LineStyle = DefaultStyles.GetDefaultBorderLineStyle();
        Border!.Thickness = DefaultStyles.GetDefaultBorderThickness();
    }
}
