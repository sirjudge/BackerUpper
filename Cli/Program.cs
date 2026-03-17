using Terminal.Gui;
using Cli.Windows;


ApplicationV2 app = new();
app.Init();

var launchWindow = new MainWindow(app);
app.Run (launchWindow);



