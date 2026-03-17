using Cli.Windows;
using Terminal.Gui.App;
using Terminal.Gui.Configuration;

ConfigurationManager.RuntimeConfig = """{ "Theme": "Amber Phosphor" }""";
ConfigurationManager.Enable (ConfigLocations.All);

IApplication app = Application.Create ().Init ();

var launchWindow = new MainWindow(app);
app.Run (launchWindow);
