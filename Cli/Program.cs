using System.CommandLine;
using Cli.CommandActions;
using Terminal.Gui.Configuration;

namespace Cli;

internal static class Program
{
    private static void Main(string[] args)
    {
        ConfigurationManager.RuntimeConfig = """{ "Theme": "Amber Phosphor" }""";
        ConfigurationManager.Enable(ConfigLocations.All);

        var rootCommand = BuildRootCommand();
        var parseResult = rootCommand.Parse(args);
        foreach (var error in parseResult.Errors){
            Console.Error.WriteLine($"Error during parsing:{error.Message}");
        }

        parseResult.Invoke();
    }

    private static RootCommand BuildRootCommand()
    {
        RootCommand rootCommand = new ("CLI and TUI file and directory back up tool");
        rootCommand.Subcommands.Add(LaunchOptions.BackupActionCommand);
        rootCommand.Subcommands.Add(LaunchOptions.TuiCommand);
        rootCommand.Subcommands.Add(LaunchOptions.BackupPathCommand);
        return rootCommand;
    }
}