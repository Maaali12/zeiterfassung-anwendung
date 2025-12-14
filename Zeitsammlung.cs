using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace zeiterfassung_anwendung;

public partial class Zeitsammlung : Form
{
    private readonly SqLiteConnection _db = new SqLiteConnection();
    private DateTime _startTime;
    private bool _isRunning = false;
    private Projekt _selectedProjekt;
    private readonly Logging _logger = new Logging();

    public Zeitsammlung()
    {
        InitializeComponent();
        _db.CreateTables();
    }

    private void Zeitsammlung_Load(object sender, EventArgs e)
    {
        LoadProjekte();
        RefreshEntries();
    }

    private void LoadProjekte()
    {
        var projekte = _db.GetProjekte();
        cmbProjekte.DataSource = null;
        cmbProjekte.DataSource = projekte;
        if (projekte.Any())
        {
            _selectedProjekt = projekte.First();
        }
    }

    private void RefreshEntries()
    {
        listViewEntries.Items.Clear();
        var entries = _db.GetZeiteintraege().OrderByDescending(x => x.Startzeit).ToList();
        var projekte = _db.GetProjekte();

        foreach (var entry in entries)
        {
            var p = projekte.FirstOrDefault(x => x.ProjektID == entry.ProjektID);
            var item = new ListViewItem(p?.Projektname ?? "Unbekannt");
            item.SubItems.Add(entry.Startzeit.ToString("G"));
            item.SubItems.Add(entry.Endzeit.ToString("G"));
            item.SubItems.Add(entry.Dauer.ToString(@"hh\:mm\:ss"));
            
            if (p != null)
            {
                var gesamtMinuten = _db.GetZeiteintraege(p.ProjektID).Sum(x => x.Dauer.TotalMinutes);
                if (gesamtMinuten > p.Zeitbudget * 0.9)
                {
                    item.BackColor = Color.LightCoral;
                }
            }
            
            listViewEntries.Items.Add(item);
        }
        UpdateTotalTime();
    }

    private void UpdateTotalTime()
    {
        if (_selectedProjekt != null)
        {
            var entries = _db.GetZeiteintraege(_selectedProjekt.ProjektID);
            var total = entries.Aggregate(TimeSpan.Zero, (sum, next) => sum + next.Dauer);
            lblTotal.Text = $"Gesamtzeit {_selectedProjekt.Projektname}: {(int)total.TotalHours}h {total.Minutes}m";
            
            if (total.TotalMinutes > _selectedProjekt.Zeitbudget * 0.9)
            {
                lblTotal.ForeColor = Color.Red;
            }
            else
            {
                lblTotal.ForeColor = Color.Black;
            }
        }
    }

    private void btnStartStop_Click(object sender, EventArgs e)
    {
        if (_selectedProjekt == null)
        {
            MessageBox.Show("Bitte wählen Sie zuerst ein Projekt aus.");
            return;
        }

        if (!_isRunning)
        {
            _startTime = DateTime.Now;
            _isRunning = true;
            btnStartStop.Text = "Stop";
            btnStartStop.BackColor = Color.Tomato;
            timer1.Start();
            _logger.LogMessage($"Zeiterfassung gestartet für Projekt: {_selectedProjekt.Projektname}", 0);
        }
        else
        {
            _isRunning = false;
            timer1.Stop();
            btnStartStop.Text = "Start";
            btnStartStop.BackColor = SystemColors.Control;
            
            var entry = new Zeiteintrag
            {
                ProjektID = _selectedProjekt.ProjektID,
                Startzeit = _startTime,
                Endzeit = DateTime.Now
            };
            _db.AddZeiteintrag(entry);
            _logger.LogMessage($"Zeiterfassung gestoppt für Projekt: {_selectedProjekt.Projektname}. Dauer: {entry.Dauer}", 0);
            RefreshEntries();
            lblTimer.Text = "00:00:00";
        }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        var duration = DateTime.Now - _startTime;
        lblTimer.Text = duration.ToString(@"hh\:mm\:ss");
    }

    private void btnProjekte_Click(object sender, EventArgs e)
    {
        using (var diag = new ProjektVerwaltung())
        {
            diag.ShowDialog();
        }
        LoadProjekte();
    }

    private void cmbProjekte_SelectedIndexChanged(object sender, EventArgs e)
    {
        _selectedProjekt = cmbProjekte.SelectedItem as Projekt;
        UpdateTotalTime();
    }

    private void btnManualAdd_Click(object sender, EventArgs e)
    {
        if (_selectedProjekt == null) return;

        var start = dtpStart.Value;
        var end = dtpEnd.Value;

        if (end < start)
        {
            MessageBox.Show("Endzeit muss nach Startzeit liegen.");
            return;
        }

        var entry = new Zeiteintrag
        {
            ProjektID = _selectedProjekt.ProjektID,
            Startzeit = start,
            Endzeit = end
        };
        _db.AddZeiteintrag(entry);
        RefreshEntries();
    }

    private void Form1_Load(object sender, EventArgs e) { }
    private void button1_Click(object sender, EventArgs e) { }
    private void textBox1_TextChanged(object sender, EventArgs e) { }
}