namespace Features.Files;

public static class FileAgent
{
    /// <summary>
    /// Copies the given File directory
    /// </summary>
    public static void CopyFile(CopyOptions option){
        if (!File.Exists(option.InputPath)){
            LogEvent("No work to be done, file does not exist");
            return;
        }
        
    }

    /// <summary>
    /// Copies the given directory
    /// </summary>
    public static void CopyFile(CopyOptions option){
        if(Directory.Exists(option.inputPath)){
            LogEvent("No work to be done, directory does not exist");
            return;
        }
    }


    /// <summary>
    /// Logs the directory or file copied along with some additional metadata
    /// </summary>
    public static LogEvent(string eventMessage){
        Console.WriteLine(eventMessage);
    }
}
