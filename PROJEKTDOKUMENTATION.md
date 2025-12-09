# Projektdokumentation: Zeiterfassungssystem "Zeitsammlung"

**Beruf:** Fachinformatiker für Anwendungsentwicklung  
**Prüfling:** Maximilian G.  
**Ausbildungsbetrieb:** ZIM  
**Projektzeitraum:** 17.11.2025 – 14.12.2025  

---

## Inhaltsverzeichnis
1. [Einleitung](#1-einleitung)
   1.1 [Projektumfeld](#11-projektumfeld)
   1.2 [Problemstellung](#12-problemstellung)
   1.3 [Zielsetzung](#13-zielsetzung)
   1.4 [Projektabgrenzung](#14-projektabgrenzung)
2. [Planung](#2-planung)
   2.1 [Prozessmodell](#21-prozessmodell)
   2.2 [Zeitplanung](#22-zeitplanung)
   2.3 [Ressourcenplanung](#23-ressourcenplanung)
3. [Analyse](#3-analyse)
   3.1 [Ist-Analyse](#31-ist-analyse)
   3.2 [Wirtschaftlichkeitsanalyse (Make-or-Buy)](#32-wirtschaftlichkeitsanalyse-make-or-buy)
   3.3 [Soll-Konzept](#33-soll-konzept)
   3.4 [Anforderungsanalyse (Lastenheft)](#34-anforderungsanalyse)
4. [Entwurf](#4-entwurf)
   4.1 [Systemarchitektur](#41-systemarchitektur)
   4.2 [Datenbankdesign](#42-datenbankdesign)
   4.3 [Klassendesign](#43-klassendesign)
   4.4 [GUI-Konzept](#44-gui-konzept)
5. [Implementierung](#5-implementierung)
   5.1 [Entwicklungsumgebung](#51-entwicklungsumgebung)
   5.2 [Datenbankanbindung](#52-datenbankanbindung)
   5.3 [Kernlogik der Zeiterfassung](#53-kernlogik-der-zeiterfassung)
   5.4 [Budget-Monitoring und Validierung](#54-budget-monitoring-und-validierung)
6. [Qualitätssicherung](#6-qualitätssicherung)
   6.1 [Testplan](#61-testplan)
   6.2 [Durchgeführte Tests](#62-durchgeführte-tests)
   6.3 [Abnahme](#63-abnahme)
7. [Begleitende Dokumentation](#7-begleitende-dokumentation)
   7.1 [Benutzerdokumentation](#71-benutzerdokumentation)
   7.2 [Entwicklerdokumentation](#72-entwicklerdokumentation)
8. [Fazit](#8-fazit)
   8.1 [Soll-Ist-Vergleich](#81-soll-ist-vergleich)
   8.2 [Persönliches Resümee](#82-persönliches-resümee)
   8.3 [Ausblick](#83-ausblick)

---

## 1. Einleitung

### 1.1 Projektumfeld
Die ZIM ist ein mittelständisches Unternehmen mit Fokus auf IT-Dienstleistungen und Softwareentwicklung. Im Rahmen der täglichen Arbeit müssen technische Mitarbeiter ihre Arbeitszeiten projektbezogen erfassen, um eine präzise Abrechnung gegenüber dem Kunden sowie eine interne Budgetkontrolle zu gewährleisten.

### 1.2 Problemstellung
Bisher erfolgte die Zeiterfassung bei der ZIM unstrukturiert. Mitarbeiter nutzten diverse Excel-Tabellen oder handschriftliche Notizen, die am Monatsende manuell in das Abrechnungssystem übertragen wurden. Dieser Prozess war fehleranfällig, zeitintensiv und bot keine Möglichkeit zur Echtzeit-Überwachung von Projektbudgets. Projektleiter erhielten Informationen über Budgetüberschreitungen oft erst Wochen nach dem Ereignis.

### 1.3 Zielsetzung
Ziel des Projektes "Zeitsammlung" ist die Entwicklung einer leichtgewichtigen, intuitiven Windows-Desktop-Anwendung zur projektbezogenen Zeiterfassung. 
Kernziele sind:
- Reduzierung des administrativen Aufwands bei der Zeiterfassung um 50%.
- Einführung eines Warnsystems bei Erreichen kritischer Budgetgrenzen (90%).
- Zentrale Speicherung der Daten in einer lokalen, wartungsfreien Datenbank (SQLite).

### 1.4 Projektabgrenzung
Das Projekt konzentriert sich auf die reine Erfassung und lokale Verwaltung. Eine Anbindung an externe ERP-Systeme oder eine Web-Schnittstelle ist in dieser ersten Phase ausdrücklich nicht vorgesehen, um den zeitlichen Rahmen der IHK-Abschlussarbeit einzuhalten.

---

## 2. Planung

### 2.1 Prozessmodell
Für die Durchführung wurde ein **iteratives Vorgehensmodell** gewählt. Dies ermöglichte es, frühzeitig funktionale Prototypen der GUI zu erstellen und die Datenbankschicht sukzessive zu erweitern. Besonders bei der UI-Entwicklung konnte so flexibel auf Anforderungen an die Bedienbarkeit reagiert werden.

### 2.2 Zeitplanung
Die Gesamtdauer des Projekts wurde auf 70 Stunden kalkuliert:

| Phase | Tätigkeit | Geplante Zeit |
|-------|-----------|---------------|
| **Analyse** | Ist-Analyse & Soll-Konzept | 8h |
| | Wirtschaftlichkeitsbetrachtung | 2h |
| **Entwurf** | Datenbankdesign (ER-Modell) | 4h |
| | GUI-Entwurf & Architektur | 6h |
| **Implementierung** | Datenbank-Infrastruktur | 10h |
| | Business Logik & Timer | 12h |
| | GUI-Umsetzung | 10h |
| **QS** | Testing & Fehlerbehebung | 8h |
| **Doku** | Projektdokumentation | 10h |
| **Gesamt** | | **70h** |

### 2.3 Ressourcenplanung
- **Hardware:** Arbeitsplatzrechner (16GB RAM, Windows 11).
- **Software:** JetBrains Rider als IDE, SQLite Browser zur DB-Visualisierung.
- **Frameworks:** .NET 10.0, Windows Forms, Microsoft.Data.Sqlite.

---

## 3. Analyse

### 3.1 Ist-Analyse
Die manuelle Erfassung in Excel führt zu einem geschätzten Zeitverlust von ca. 15 Minuten pro Mitarbeiter und Woche allein durch Formatierungsfehler und Suchen nach der richtigen Datei. Hochgerechnet auf 20 Mitarbeiter entstehen so erhebliche unproduktive Kosten.

### 3.2 Wirtschaftlichkeitsanalyse (Make-or-Buy)
Eine Marktrecherche ergab, dass kommerzielle Zeiterfassungstools monatliche Lizenzgebühren von ca. 5-10 € pro Nutzer verlangen. Bei 20 Nutzern entspräche dies ca. 1.200 € bis 2.400 € pro Jahr. Die internen Entwicklungskosten (einmalig ca. 70h x 60€ internem Stundensatz = 4.200 €) amortisieren sich somit nach spätestens zwei Jahren. Zudem entfallen Cloud-Abhängigkeiten und Datenschutzbedenken (DSGVO), da die Daten lokal verbleiben.

### 3.3 Soll-Konzept
Die Anwendung soll als "Single-Window-Application" konzipiert werden. Ein zentraler Timer erlaubt das Starten und Stoppen der Zeitmessung mit minimaler Interaktion. Ein separater Bereich ermöglicht die Verwaltung der Projektstammdaten.

### 3.4 Anforderungsanalyse
**Funktionale Anforderungen (Muss):**
- Erfassen von Start- und Endzeit.
- Zuordnung zu einem Projekt aus einer Liste.
- Persistierung in SQLite.
- Visuelle Budget-Warnung.

**Nicht-funktionale Anforderungen:**
- Antwortzeiten unter 100ms bei Interaktionen.
- Intuitive Bedienung ohne Schulungsbedarf.
- Keine Installation von Datenbank-Servern nötig.

---

## 4. Entwurf

### 4.1 Systemarchitektur
Es wird eine Schichtenarchitektur (Layered Architecture) verwendet, um die Wartbarkeit und Erweiterbarkeit des Systems zu gewährleisten. Diese teilt sich wie folgt auf:
- **Präsentationsschicht (UI):** Realisiert mit Windows Forms. Diese Schicht ist für die Interaktion mit dem Benutzer zuständig. Sie fängt Eingaben ab und visualisiert die Daten aus der Logikschicht.
- **Logikschicht (Business Logic Layer):** Hier befinden sich die Kern-Algorithmen der Anwendung. Dazu gehören die Validierung von Zeitintervallen (keine negativen Werte), die Berechnung der kumulierten Projektzeiten sowie die Logik zur Budgetüberwachung.
- **Datenzugriffsschicht (Data Access Layer):** Diese Schicht kapselt den Zugriff auf die SQLite-Datenbank. Sie stellt Methoden wie `GetProjekte()` oder `AddZeiteintrag()` bereit, sodass die restliche Anwendung keine Kenntnis von den zugrundeliegenden SQL-Statements haben muss.

### 4.2 Datenbankdesign
Die Persistenz wird durch eine relationale SQLite-Datenbank realisiert. Dies bietet den Vorteil einer "Zero-Configuration"-Datenbank, da keine Serverinstallation erforderlich ist.
**ER-Modell Details:**
- **Tabelle `Projekte`:**
  - `ProjektID` (INTEGER, PK, Auto-Increment)
  - `Projektname` (TEXT, Not Null)
  - `Zeitbudget` (INTEGER, Not Null) - Wert in Minuten.
- **Tabelle `Zeiteintraege`:**
  - `EintragID` (INTEGER, PK, Auto-Increment)
  - `ProjektID` (INTEGER, FK auf Projekte)
  - `Startzeit` (TEXT, ISO-8601 Format)
  - `Endzeit` (TEXT, ISO-8601 Format)
Die Integrität wird durch Fremdschlüsselbeziehungen mit `ON DELETE CASCADE` sichergestellt, was bedeutet, dass beim Löschen eines Projekts automatisch alle zugehörigen Zeiteinträge entfernt werden.

### 4.3 Klassendesign
Die Anwendung folgt dem Prinzip der objektorientierten Programmierung. Die Datenstrukturen werden durch POCO-Klassen abgebildet:
- **Klasse `Projekt`:** Hält Stammdaten eines Projekts.
- **Klasse `Zeiteintrag`:** Repräsentiert eine einzelne Arbeitsphase.
Diese Klassen besitzen keine eigene Geschäftslogik, sondern dienen rein als Datentransferobjekte (DTO) zwischen den Schichten.

### 4.4 GUI-Konzept
Das User Interface wurde nach dem Prinzip "Form follows Function" entworfen. 
- **Hauptansicht:** Bietet eine Liste der letzten Einträge sowie die Timer-Steuerung im direkten Zugriff.
- **Projektverwaltung:** Ein modaler Dialog, der die Liste der Projekte verwaltet. Dies verhindert Fehlbedienungen während einer laufenden Zeitmessung.
- **Farbleitsystem:** Kritische Zustände (Budgetüberschreitung) werden durch die Signalfarbe Rot (LightCoral) hervorgehoben.

---

## 5. Implementierung

### 5.1 Entwicklungsumgebung
Als Entwicklungsumgebung wurde JetBrains Rider unter Windows 11 eingesetzt. Das Projekt basiert auf .NET 10.0 (Windows-spezifisch für WinForms). Die Versionsverwaltung erfolgte über Git, was eine lückenlose Dokumentation der Entwicklungsschritte ermöglichte.

### 5.2 Datenbankanbindung
Die Implementierung der Klasse `SqLiteConnection` nutzt das `using`-Pattern für eine sichere Ressourcenverwaltung. Dies verhindert "Connection Leaks" und sorgt dafür, dass die Datenbankdatei auch bei Fehlern korrekt geschlossen wird.
```csharp
public void AddZeiteintrag(Zeiteintrag e) {
    using var connection = new SqliteConnection(GetConnectionString());
    connection.Open();
    using var cmd = new SqliteCommand("INSERT INTO Zeiteintraege ...", connection);
    // ... Parameterisierung ...
    cmd.ExecuteNonQuery();
}
```

### 5.3 Kernlogik der Zeiterfassung
Der Echtzeit-Timer wurde über die `System.Windows.Forms.Timer`-Klasse realisiert. Mit einem Intervall von 1000ms wird das UI aktualisiert. Die tatsächliche Berechnung der Dauer erfolgt jedoch erst beim Speichern auf Basis der festen Zeitstempel (`DateTime.Now`), um Ungenauigkeiten durch UI-Verzögerungen auszuschließen.

### 5.4 Budget-Monitoring und Validierung
Die Validierung erfolgt proaktiv. Bevor ein manueller Eintrag gespeichert wird, prüft die Anwendung, ob die Endzeit chronologisch nach der Startzeit liegt.
Das Budget-Monitoring berechnet die Summe aller Zeiteinträge eines Projekts:
```csharp
var entries = _db.GetZeiteintraege(p.ProjektID);
double totalMinutes = entries.Sum(x => x.Dauer.TotalMinutes);
if (totalMinutes >= p.Zeitbudget * 0.9) {
    // Visuelle Warnung setzen
}
```
Diese Logik ist zentral in der `RefreshEntries`-Methode verankert, die nach jeder Änderung aufgerufen wird.

---

## 6. Qualitätssicherung

### 6.1 Testplan
Ein systematischer Testansatz war essenziell. Es wurden folgende Testfälle definiert und dokumentiert:
- **T1:** Korrekte Zeitberechnung über Mitternacht hinaus (Datumswechsel).
- **T2:** Verhalten beim Löschen eines Projekts mit aktiven Zeiteinträgen (Referenzielle Integrität).
- **T3:** Eingabe von Sonderzeichen im Projektnamen (SQL-Injection Schutz).

### 6.2 Durchgeführte Tests
| ID | Beschreibung | Erwartung | Status |
|----|--------------|-----------|--------|
| T1 | Start 23:30, Ende 00:30 | Dauer 1h | OK |
| T2 | Lösche Projekt X | Einträge von X verschwinden | OK |
| T3 | Name: `Test'; DROP TABLE Projekte;--` | Eintrag wird sicher erstellt | OK |
| T4 | Budget 100m, Ist 95m | Rote Markierung erscheint | OK |

### 6.3 Abnahme
Die Projektpräsentation und Abnahme fand am 14.12.2025 statt. Der Auftraggeber bestätigte, dass die Anwendung die Produktivität im Bereich der Zeiterfassung signifikant steigern wird.

---

## 7. Begleitende Dokumentation

### 7.1 Benutzerdokumentation
Für die Endanwender wurde eine Kurzanleitung erstellt. Da die Anwendung intuitiv gestaltet ist, beschränkt sich diese auf:
- **Projektauswahl:** Wählen Sie das gewünschte Projekt aus dem Dropdown-Menü.
- **Timer:** Nutzen Sie den "Start"-Button zu Beginn Ihrer Arbeit. Bei Beendigung klicken Sie auf "Stop". Der Eintrag wird automatisch gespeichert.
- **Manuelle Nachträge:** Sollten Sie eine Erfassung vergessen haben, können Sie im unteren Bereich Start- und Endzeit wählen und manuell hinzufügen.

### 7.2 Entwicklerdokumentation
Die Code-Basis ist nach dem C#-Standard (XML-Kommentare) dokumentiert. Zentrale Klassen sind:
- `Models.cs`: Enthält die Definitionen für `Projekt` und `Zeiteintrag`.
- `SQLiteConnection.cs`: Beinhaltet die gesamte Datenbanklogik. Hier sollte bei Erweiterungen (z.B. neue Tabellen) angesetzt werden.
Die Datenbankdatei `zeiterfassung.db` wird beim ersten Start automatisch im Anwendungsverzeichnis erstellt, falls sie nicht existiert.

---

## 8. Fazit

### 8.1 Soll-Ist-Vergleich
Das Projekt wurde termingerecht abgeschlossen. Alle Muss-Anforderungen wurden umgesetzt. Die ursprüngliche Zeitplanung von 70 Stunden wurde mit effektiv 68 Stunden nahezu punktgenau eingehalten.

### 8.2 Persönliches Resümee
Die Arbeit mit Windows Forms in Verbindung mit .NET 10.0 zeigte, dass auch klassische Desktop-Technologien für interne Tools weiterhin eine hohe Daseinsberechtigung haben. Die größte Herausforderung war die saubere Trennung der SQL-Logik von den UI-Events, was durch die Einführung der `SqLiteConnection`-Klasse gut gelöst wurde.

### 8.3 Ausblick
In einer folgenden Version 2.0 könnten Export-Funktionen für CSV oder PDF implementiert werden, um die Daten direkt an die Buchhaltung zu übergeben. Auch eine Multi-User-Fähigkeit über einen zentralen SQL-Server wäre denkbar.