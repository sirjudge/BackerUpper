using System.CommandLine;
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
        rootCommand.Options.Add(LaunchOptions.ListPaths);
        rootCommand.Options.Add(LaunchOptions.TuiMode);
        rootCommand.Options.Add(LaunchOptions.AddPathToBackup);
        rootCommand.Options.Add(LaunchOptions.RemovePathToBackup);
        rootCommand.Options.Add(LaunchOptions.BackupType);
        return rootCommand;
    }
}