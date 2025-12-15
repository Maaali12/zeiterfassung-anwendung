namespace zeiterfassung_anwendung;

public class Logging
{
    public void LogMessage(string message, int level)
    {
        // Einfache Implementierung für den Moment
        Console.WriteLine($"[{DateTime.Now}] Level {level}: {message}");
    }
}