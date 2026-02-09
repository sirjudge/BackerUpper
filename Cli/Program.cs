using Terminal.Gui;
using Cli.Windows;

IApplication app = new ApplicationV2();
app.Init();

Window launchWindow = new MainWindow(app);
app.Run (launchWindow);



