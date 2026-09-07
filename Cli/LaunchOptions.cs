using System.CommandLine;
using Cli.CommandActions;

namespace Cli;

public static class LaunchOptions {

    public static readonly Option<bool> ListPaths = new ("--list", "-l"){
        Description = "list all currently saved backup paths",
        Action = new ListBackupPathsCommand()
    };

    public static readonly Option<bool> TuiMode = new("--tui", "-t")
    {
        Description = "Launch application in TUI mode",
        Action = new TuiActionCommand()
    };

    public static readonly Option<string?> AddPathToBackup = new ("--add", "-a"){
        Description = "Flag to add a new path",
        Action = new AddPathToBackupCommand()
    };

    public static readonly Option<string?> RemovePathToBackup = new ("--remove", "-r"){
        Description = "path of what you'd like to remove from your list of backups",
        Action = new RemovePathFromBackupCommand()
    };

    public static readonly Option<string?> BackupType = new ("--backupType", "-bt"){
        Description = "passes in a backup type for configuring multiple backup options for different devices or configurations",
    };

    public static readonly Option<string?> DryRun = new ("--dryRun", "-dr"){
        Description = "operates as if it were backing up but skips any actual IO while still performing validation",
    };
}