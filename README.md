# Pflichtenheft - Zeiterfassungssystem

**Version:** 1.1 | **Datum:** 18.11.2025 | **Entwickler:** Maximilian G. | **Auftraggeber:** ZIM

---

## 1. Projektbezug

**Auftraggeber:** ZIM 
**Entwickler:** Maximilian G. 
**Projektart:** Übungsprojekt für IHK-Abschlussprüfung (Fachinformatiker für Anwendungsentwicklung)

---

## 2. Ziel und Nutzen

Digitales Zeiterfassungssystem zur projektbezogenen Dokumentation von Arbeitszeiten. Zielgruppe: Technische Mitarbeiter

**Nutzen:** Transparente Zeitabrechnung, Budgetüberwachung pro Projekt, Ressourcenplanung

---

## 3. Funktionale Anforderungen

- **FA-01:** Projektverwaltung (Anlegen, Bearbeiten, Löschen von Projekten mit Zeitbudget in Stunden)
- **FA-02:** Start/Stop-Funktion mit Echtzeit-Timer zur Zeiterfassung
- **FA-03:** Manuelle Zeiteinträge (Start-, Endzeit, automatische Dauer-Berechnung)
- **FA-04:** Tabellarische Übersicht aller Zeiteinträge (Projekt, Start, End, Dauer)
- **FA-05:** Berechnung der Gesamtzeit pro Projekt
- **FA-06:** Visuelle Warnung (rote Zeile) bei Überschreitung von 90 % des Zeitbudgets
- **FA-08:** Optionale verschlüsselung von sensiblen Daten bzw. Projekten
- **FA-07:** Persistente Speicherung in SQLite-Datenbank

---

## 4. Datenbank (SQLite)

**Tabelle: Projekte**
```
ProjektID (INTEGER PRIMARY KEY AUTOINCREMENT)
Projektname (TEXT NOT NULL)
Zeitbudget (INTEGER NOT NULL, in Minuten)
```

**Tabelle: Zeiteinträge**
```
EintragID (INTEGER PRIMARY KEY AUTOINCREMENT)
ProjektID (INTEGER NOT NULL, FOREIGN KEY)
Startzeit (TEXT NOT NULL, ISO-8601)
Endzeit (TEXT NOT NULL, ISO-8601)
Dauer (INTEGER NOT NULL, in Minuten)
```

**Beziehung:** 1:n

---

## 5. Nicht-funktionale Anforderungen

| Anforderung        | Details                                                   |
|--------------------|-----------------------------------------------------------|
| **Technologie**    | C#, Windows Forms, .NET 10.0, SQLite (System.Data.SQLite) |
| **Betriebssystem** | Windows 10/11                                             |
| **UI**             | Intuitiv, klare Fehlermeldungen, konsistentes Design      |
| **Performance**    | Datenbankabfragen < 500ms                                 |
| **Sicherheit**     | Optionale verschlüsselung von Projektdaten                |

---

## 6. Zeitplan

| Phase           | Termine            | Aufgaben                                   |
|-----------------|--------------------|--------------------------------------------|
| Planung & Setup | 18.11.             | Projektsetup, Datenbankdesign              |
| Datenbank       | 24.-25.11.         | SQLite-Implementierung, CRUD               |
| GUI & Logik     | 25.11. - 01.12.    | Windows Forms, Timer, Berechnung           |
| Testing         | 02.12., 08.-09.12. | Funktionale Tests, Bugfixes, Dokumentation |

---

## 7. Qualitätssicherung & Abnahme

**Abnahmekriterien:**
- ✅ Alle funktionalen Anforderungen erfüllt
- ✅ Keine kritischen Fehler
- ✅ Daten persistent speicherbar
- ✅ Quellcode kommentiert und dokumentiert

**Lieferumfang:** .exe-Datei, SQLite-DB, Quellcode, dieses Pflichtenheft,

---
# Dokumentation
soon...