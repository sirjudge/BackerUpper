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
    };

    public static Command BackupActionCommand = new ("backup", "run a backup"){
        Action = new BackupCommand(),
        //TODO: need to figure out how to get these to work as additional options for this command
        // new Option<string?>("--backupType", "-bt"){
        //     Description = "passes in a backup type for configuring multiple backup options for different devices or configurations",
        // },
        // //TODO: this should really be a global command tbh
        // new Option<string?>("--dryRun", "-dr"){
        //     Description = "operates as if it were backing up but skips any actual IO while still performing validation",
        // },
    };

    public static Command RestoreActionCommand = new ("restore", "Run a restore"){
        Action = new RestoreCommand(),
        //TODO: need to figure out how to get these to work as additional options for this command
        // new Option<string?>("--backupType", "-bt"){
        //     Description = "passes in a backup type for configuring multiple backup options for different devices or configurations",
        // },
        // //TODO: this should really be a global command tbh
        // new Option<string?>("--dryRun", "-dr"){
        //     Description = "operates as if it were backing up but skips any actual IO while still performing validation",
        // },
    };
}