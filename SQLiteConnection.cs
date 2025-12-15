using Microsoft.Data.Sqlite;
using System.IO;
using System.Collections.Generic;
using System;

namespace zeiterfassung_anwendung;

public sealed class SqLiteConnection
{
    private string GetConnectionString()
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "zeiterfassung.db");
        return $"Data Source={dbPath}";
    }

    public void CreateTables()
    {
        using var connection = new SqliteConnection(GetConnectionString());
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

    public List<Projekt> GetProjekte()
    {
        var list = new List<Projekt>();
        using var connection = new SqliteConnection(GetConnectionString());
        connection.Open();
        using var cmd = new SqliteCommand("SELECT * FROM Projekte", connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Projekt
            {
                ProjektID = reader.GetInt32(0),
                Projektname = reader.GetString(1),
                Zeitbudget = reader.GetInt32(2)
            });
        }
        return list;
    }

    public void SaveProjekt(Projekt p)
    {
        using var connection = new SqliteConnection(GetConnectionString());
        connection.Open();
        if (p.ProjektID == 0)
        {
            using var cmd = new SqliteCommand("INSERT INTO Projekte (Projektname, Zeitbudget) VALUES (@name, @budget)", connection);
            cmd.Parameters.AddWithValue("@name", p.Projektname);
            cmd.Parameters.AddWithValue("@budget", p.Zeitbudget);
            cmd.ExecuteNonQuery();
        }
        else
        {
            using var cmd = new SqliteCommand("UPDATE Projekte SET Projektname = @name, Zeitbudget = @budget WHERE ProjektID = @id", connection);
            cmd.Parameters.AddWithValue("@name", p.Projektname);
            cmd.Parameters.AddWithValue("@budget", p.Zeitbudget);
            cmd.Parameters.AddWithValue("@id", p.ProjektID);
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteProjekt(int id)
    {
        using var connection = new SqliteConnection(GetConnectionString());
        connection.Open();
        using var cmd = new SqliteCommand("DELETE FROM Projekte WHERE ProjektID = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public List<Zeiteintrag> GetZeiteintraege(int? projektId = null)
    {
        var list = new List<Zeiteintrag>();
        using var connection = new SqliteConnection(GetConnectionString());
        connection.Open();
        string sql = "SELECT * FROM Zeiteintraege";
        if (projektId.HasValue) sql += " WHERE ProjektID = @pid";
        
        using var cmd = new SqliteCommand(sql, connection);
        if (projektId.HasValue) cmd.Parameters.AddWithValue("@pid", projektId.Value);
        
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Zeiteintrag
            {
                EintragID = reader.GetInt32(0),
                ProjektID = reader.GetInt32(1),
                Startzeit = DateTime.Parse(reader.GetString(2), System.Globalization.CultureInfo.InvariantCulture),
                Endzeit = DateTime.Parse(reader.GetString(3), System.Globalization.CultureInfo.InvariantCulture)
            });
        }
        return list;
    }

    public void AddZeiteintrag(Zeiteintrag e)
    {
        using var connection = new SqliteConnection(GetConnectionString());
        connection.Open();
        using var cmd = new SqliteCommand("INSERT INTO Zeiteintraege (ProjektID, Startzeit, Endzeit) VALUES (@pid, @start, @end)", connection);
        cmd.Parameters.AddWithValue("@pid", e.ProjektID);
        cmd.Parameters.AddWithValue("@start", e.Startzeit.ToString("o"));
        cmd.Parameters.AddWithValue("@end", e.Endzeit.ToString("o"));
        cmd.ExecuteNonQuery();
    }
}