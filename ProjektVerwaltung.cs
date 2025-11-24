using System;
using System.Windows.Forms;

namespace zeiterfassung_anwendung;

public partial class ProjektVerwaltung : Form
{
    private readonly SqLiteConnection _db = new SqLiteConnection();
    private Projekt _currentProjekt;

    public ProjektVerwaltung()
    {
        InitializeComponent();
        LoadProjekte();
    }

    private void LoadProjekte()
    {
        lstProjekte.DataSource = null;
        lstProjekte.DataSource = _db.GetProjekte();
    }

    private void lstProjekte_SelectedIndexChanged(object sender, EventArgs e)
    {
        _currentProjekt = lstProjekte.SelectedItem as Projekt;
        if (_currentProjekt != null)
        {
            txtName.Text = _currentProjekt.Projektname;
            numBudget.Value = _currentProjekt.Zeitbudget;
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Bitte einen Projektnamen eingeben.");
            return;
        }

        var p = _currentProjekt ?? new Projekt();
        p.Projektname = txtName.Text;
        p.Zeitbudget = (int)numBudget.Value;

        _db.SaveProjekt(p);
        _currentProjekt = null;
        txtName.Clear();
        numBudget.Value = 0;
        LoadProjekte();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_currentProjekt != null)
        {
            _db.DeleteProjekt(_currentProjekt.ProjektID);
            _currentProjekt = null;
            txtName.Clear();
            numBudget.Value = 0;
            LoadProjekte();
        }
    }
}
