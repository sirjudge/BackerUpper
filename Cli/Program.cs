using Terminal.Gui;
using BackerUpperCli.Windows;


IApplication app = new ApplicationV2();
app.Init();

var launchWindow = new MainWindow(app);
app.Run (launchWindow);



