using Cli.Windows;
using Terminal.Gui.App;
using Terminal.Gui.Configuration;

ConfigurationManager.RuntimeConfig = """{ "Theme": "Amber Phosphor" }""";
ConfigurationManager.Enable (ConfigLocations.All);

IApplication app = Application.Create ().Init ();

//TODO: Need to add toggle to launch in TUI or just parse command flags
//const launchOptions = new LaunchOptions(){
//
//}
var launchWindow = new MainWindow(app);
app.Run (launchWindow);
