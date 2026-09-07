using System.CommandLine;
using System.CommandLine.Invocation;

namespace Cli.CommandActions;

public class RestoreCommand : AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked Restore command");
        return Task.FromResult(1);
    }
}
