using System.CommandLine;
using System.CommandLine.Invocation;

namespace Cli.CommandActions;

public class RemovePathFromBackupCommand : AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked remove path from backup command");
        return Task.FromResult(1);
    }
}
