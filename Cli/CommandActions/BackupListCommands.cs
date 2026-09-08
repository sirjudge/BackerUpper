using System.CommandLine;
using System.CommandLine.Invocation;
using Features.Files;

namespace Cli.CommandActions;

public class ListBackupPaths: AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked list of backups");
        var fileDb = new BackupFileDbHandler();
        foreach (var file in fileDb.GetBackupFiles())
            Console.WriteLine($"{file.FilePath}: {file.FileName}");
        return Task.FromResult(1);
    }
}

public class AddPathToBackupCommand : AsynchronousCommandLineAction
{
    public override Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine("Invoked Add backup path to db");
        //TODO: need better way to get this, for now just assume it'll be ./cli path -a "path" so path is always the 
        // third token
        var path = parseResult.Tokens[2].Value;
        FileAgent.AddPathToBackup(path);
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
