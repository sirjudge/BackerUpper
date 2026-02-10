using Terminal.Gui;
using Cli.Styles;
using Cli.Views.Files;

namespace Cli.Windows;

public class FilesWindow : Window {
    public FilesWindow(IApplication app, bool edit){
        Title = "Manage Configuration Files";
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();
        Border!.Thickness = DefaultStyles.GetDefaultBorderThickness();
        Add(edit ? new EditFilesView() : new ViewFilesView());


        KeyDown += (_, e) =>
        {
            switch (e.KeyCode)
            {
                case KeyCode.Q:
                    app.Run(new GoodbyeWindow(app));
                    break;
                case KeyCode.E:
                    ClearViewport();
                    Add(new EditFilesView());
                    break;
                case KeyCode.V:
                    ClearViewport();
                    Add(new ViewFilesView());
                    break;
            }
            e.Handled = true;
        };
    }
}
