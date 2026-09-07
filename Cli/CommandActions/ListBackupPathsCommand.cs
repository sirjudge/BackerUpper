using System.CommandLine;
using System.CommandLine.Invocation;

namespace Cli.CommandActions;

public class ListBackupPathsCommand: AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked list of backups");
        return Task.FromResult(1);
    }
}
