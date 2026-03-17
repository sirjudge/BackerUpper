using Terminal.Gui;
using Cli.Windows;
using Terminal.Gui.App;

using IApplication app = Application.Create ();
app.Init ();

var launchWindow = new MainWindow(app);
app.Run (launchWindow);



