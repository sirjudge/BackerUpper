using System.CommandLine;
using System.CommandLine.Invocation;

namespace Cli.CommandActions;

public class ListBackupPaths: AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked list of backups");
        return Task.FromResult(1);
    }
}

public class AddPathToBackupCommand : AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked Add backup path to db");
        return Task.FromResult(1);
    }
}

public class RemovePathFromBackupCommand : AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked remove path from backup command");
        return Task.FromResult(1);
    }
}
