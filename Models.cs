namespace zeiterfassung_anwendung;

public class Projekt
{
    public int ProjektID { get; set; }
    public string Projektname { get; set; }
    public int Zeitbudget { get; set; }
    
    public override string ToString() => Projektname;
}

public class Zeiteintrag
{
    public int EintragID { get; set; }
    public int ProjektID { get; set; }
    public DateTime Startzeit { get; set; }
    public DateTime Endzeit { get; set; }
    
    public TimeSpan Dauer => Endzeit - Startzeit;
}
