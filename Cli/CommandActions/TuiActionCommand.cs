using System.CommandLine;
using System.CommandLine.Invocation;
using Cli.Windows;

using Terminal.Gui.App;
namespace Cli.CommandActions;

public class TuiActionCommand : AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked TUI launching");
        var app = Application.Create().Init();
        var launchWindow = new MainWindow(app);
        app.Run(launchWindow);
        return Task.FromResult(1);
    }
}