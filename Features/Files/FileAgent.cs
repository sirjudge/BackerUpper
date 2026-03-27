namespace Features.Files;

public class FileAgent
{
    public void Run(CopyOptions copyOptions) {
        switch (copyOptions.Action){
            case Action.Backup:
                BackUp(copyOptions);
                return;
            case Action.Restore:
                Restore(copyOptions);
                break;
        }
    }

    internal void BackUp(CopyOptions copyOptions){
        Console.WriteLine("Backng up");
        throw new NotImplementedException();
    }

    internal void Restore(CopyOptions copyOptions){
        throw new NotImplementedException();
    }

    /// <summary>
    /// Copies the given File directory
    /// </summary>
    internal void CopyFile(CopyOptions option){
        if (!File.Exists(option.InputPath)){
            LogEvent("No work to be done, file does not exist");
        }

        if (File.Exists(option.OutputPath) )
        {
            if (!option.Overwrite){
                LogEvent($"File: {option.OutputPath} already exists and overwrite flag is set to false");
                return;
            }
            File.Delete(option.OutputPath);
        }

        File.Copy(option.InputPath, option.OutputPath);
    }

    /// <summary>
    /// Copies the given directory
    /// </summary>
    internal static void CopyDirectory(CopyOptions option){
        if(Directory.Exists(option.InputPath)){
            LogEvent("No work to be done, directory does not exist");
            return;
        }

        if (!Directory.Exists(option.OutputPath)){
            Directory.CreateDirectory(option.OutputPath);
        }

        foreach (var filePath in Directory.GetFiles(option.InputPath)){
            var file = File.Open(filePath, FileMode.Open);
            var fileName = file.Name;

            if (!file.CanRead){
                throw new UnauthorizedAccessException("File canRead attribute is set to false:{fileName}");
            }

            var outputCopyPath = Path.Combine(option.OutputPath, filePath);
            File.Copy(filePath, outputCopyPath);
            //TODO: Need to hook up db stuff here plus backup audit
        }
    }

    /// <summary>
    /// Logs the directory or file copied along with some additional metadata
    /// </summary>
    internal static void LogEvent(string eventMessage){
        Console.WriteLine(eventMessage);
    }
}
