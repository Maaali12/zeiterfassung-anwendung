using Microsoft.Data.Sqlite;
using System.IO;

namespace zeiterfassung_anwendung;

public sealed class SqLiteConnection
{
    public void CreateTables()
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "zeiterfassung.db");
        using var connection = new SqliteConnection($"Data Source={dbPath}");
        connection.Open();
        const string createProjekte = @"
        CREATE TABLE IF NOT EXISTS Projekte (
            ProjektID INTEGER PRIMARY KEY AUTOINCREMENT,
            Projektname TEXT NOT NULL,
            Zeitbudget INTEGER NOT NULL
        );";

        const string createZeiteintraege = @"
        CREATE TABLE IF NOT EXISTS Zeiteintraege (
            EintragID INTEGER PRIMARY KEY AUTOINCREMENT,
            ProjektID INTEGER NOT NULL,
            Startzeit TEXT NOT NULL,
            Endzeit TEXT NOT NULL,
            FOREIGN KEY(ProjektID) REFERENCES Projekte(ProjektID) ON DELETE CASCADE
        );";

        using var cmd1 = new SqliteCommand(createProjekte, connection);
        cmd1.ExecuteNonQuery();

        using var cmd2 = new SqliteCommand(createZeiteintraege, connection);
        cmd2.ExecuteNonQuery();
    }
}