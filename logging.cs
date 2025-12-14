namespace zeiterfassung_anwendung;

public class Logging
{
    public void LogMessage(string message, int level)
    {
        Console.WriteLine($"[{DateTime.Now}] Level {level}: {message}");
    }
}