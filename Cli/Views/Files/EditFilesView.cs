using Terminal.Gui;
using Cli.Styles;

namespace Cli.Views.Files;

public class EditFilesView : View {
    public EditFilesView(){
        Width = Dim.Fill();
        Height = Dim.Fill();
        Title = "Edit Files";
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
    }
}

