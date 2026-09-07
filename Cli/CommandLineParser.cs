using System.CommandLine.Parsing;
using System.CommandLine;

namespace Cli;


public static class LaunchOptions {

    public static readonly Option<bool> ListPaths = new ("--list"){
        Description = "list all currently saved backup paths"
    };

    public static readonly Option<bool> TuiMode = new ("--tui"){
        Description = "Launch application in TUI mode"
    };

    public static readonly Option<string> AddPathToBackup = new ("--add"){
        Description = "Flag to add a new path"
    };

    public static readonly Option<string?> RemovePathToBackup = new ("--remove"){
        Description = "Flag to remove a path from the backup list",
        DefaultValueFactory = null
    };
    public static readonly Option<string?> BackupType = new ("--remove"){
        Description = "Flag to remove a path from the backup list",
        DefaultValueFactory = null
    };
}


// TODO: change this to maybe a record or something
// it's just farrying data and we might not really need a whole class
public class RuntimeOptions {
    public bool Tui;
    public string? PathTOBackup;
    public string? PathToRemoveFromBackup;
    public bool ListBackupPaths;

    public bool RunBackup;

    //TODO: add support for this later
    public string? BackupType;
}

public static class CommandLineParser
{
    public static RuntimeOptions Parse(string[] args){
        RootCommand rootCommand = new ("CLI and TUI file and directory back up tool");
        rootCommand.Options.Add(LaunchOptions.ListPaths);
        rootCommand.Options.Add(LaunchOptions.TuiMode);
        rootCommand.Options.Add(LaunchOptions.AddPathToBackup);
        rootCommand.Options.Add(LaunchOptions.RemovePathToBackup);
        rootCommand.Options.Add(LaunchOptions.BackupType);
        //TODO: do something with parsed results
        var parseResult = rootCommand.Parse(args);
        var results = parseResult.Invoke();
        return new RuntimeOptions();
    }
}
