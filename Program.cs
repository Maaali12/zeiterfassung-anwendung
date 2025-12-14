namespace zeiterfassung_anwendung;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Zeitsammlung());
    }
}