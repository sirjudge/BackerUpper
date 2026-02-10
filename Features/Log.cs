public interface ILogger(){
    public void Debug(object obj);
    public void Info(object obj);
    public void Warn(object obj);
    public void Error(object obj);
}

public class ConsoleLogger : ILogger {
    public void Debug(object obj){
        Console.WriteLine($"[DEBUG]{DateTime.Now:hh:mm:ss}");
    }
    public void Info(object obj){
        Console.WriteLine($"[INFORMATION]{DateTime.Now:hh:mm:ss}: {obj}");
    }
    public void Warn(object obj){
        Console.WriteLine($"[WARNING]{DateTime.Now:hh:mm:ss}: {obj}");
    }

    public void Error(object obj)
    {
        Console.WriteLine($"[Error]{DateTime.Now:hh:mm:ss}: {obj}");
    }
}

public class FileLogger : ILogger
{
    private const string FileName = "log.txt";

    public FileLogger()
    {
        if (File.Exists(FileName))
        {
            return;
        }
    }

    public void Debug(object obj)
    {

    }

    public void Info(object obj)
    {

    }

    public void Warn(object obj)
    {

    }

    public void Error(object obj)
    {

    }
}
