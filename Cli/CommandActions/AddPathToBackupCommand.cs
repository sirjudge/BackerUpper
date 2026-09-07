using System.CommandLine;
using System.CommandLine.Invocation;

namespace Cli.CommandActions;

public class AddPathToBackupCommand : AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked Add backup path to db");
        return Task.FromResult(1);
    }
}
