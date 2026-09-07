using System.CommandLine;
using Cli.CommandActions;

namespace Cli;

public static class LaunchOptions {

    public static Command BackupPathCommand = new ("path", "backup path management"){
        new Option<bool> ("--list", "-l"){
            Description = "list all currently saved backup paths",
            Action = new ListBackupPaths()
        },
        new Option<string?>("--add", "-a"){
            Description = "Flag to add a new path",
            Action = new AddPathToBackupCommand()
        },
        new Option<string?>("--remove", "-r"){
            Description = "path of what you'd like to remove from your list of backups",
            Action = new RemovePathFromBackupCommand()
        },
    };

    public static Command TuiCommand = new ("tui", "Terminal User Interface"){
        Action = new TuiActionCommand()
        // new Option<bool> ("--tui", "-t"){
        //     Description = "Launch application in TUI mode",
        //     Action = new TuiActionCommand()
        // },
    };

    public static Command BackupActionCommand = new ("backup", "run a backup"){
        new Option<string?>("--backupType", "-bt"){
            Description = "passes in a backup type for configuring multiple backup options for different devices or configurations",
        },
        new Option<string?>("--dryRun", "-dr"){
            Description = "operates as if it were backing up but skips any actual IO while still performing validation",
        },
    };
}