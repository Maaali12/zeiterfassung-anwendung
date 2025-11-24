namespace zeiterfassung_anwendung;

partial class Zeitsammlung
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.btnProjekte = new System.Windows.Forms.Button();
        this.cmbProjekte = new System.Windows.Forms.ComboBox();
        this.btnStartStop = new System.Windows.Forms.Button();
        this.lblTimer = new System.Windows.Forms.Label();
        this.listViewEntries = new System.Windows.Forms.ListView();
        this.colProjekt = new System.Windows.Forms.ColumnHeader();
        this.colStart = new System.Windows.Forms.ColumnHeader();
        this.colEnde = new System.Windows.Forms.ColumnHeader();
        this.colDauer = new System.Windows.Forms.ColumnHeader();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.grpManuell = new System.Windows.Forms.GroupBox();
        this.btnManualAdd = new System.Windows.Forms.Button();
        this.dtpEnd = new System.Windows.Forms.DateTimePicker();
        this.dtpStart = new System.Windows.Forms.DateTimePicker();
        this.lblTotal = new System.Windows.Forms.Label();
        this.grpManuell.SuspendLayout();
        this.SuspendLayout();
        // 
        // btnProjekte
        // 
        this.btnProjekte.Location = new System.Drawing.Point(347, 12);
        this.btnProjekte.Name = "btnProjekte";
        this.btnProjekte.Size = new System.Drawing.Size(125, 23);
        this.btnProjekte.TabIndex = 0;
        this.btnProjekte.Text = "Projekte verwalten";
        this.btnProjekte.UseVisualStyleBackColor = true;
        this.btnProjekte.Click += new System.EventHandler(this.btnProjekte_Click);
        // 
        // cmbProjekte
        // 
        this.cmbProjekte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbProjekte.FormattingEnabled = true;
        this.cmbProjekte.Location = new System.Drawing.Point(12, 12);
        this.cmbProjekte.Name = "cmbProjekte";
        this.cmbProjekte.Size = new System.Drawing.Size(200, 23);
        this.cmbProjekte.TabIndex = 1;
        this.cmbProjekte.SelectedIndexChanged += new System.EventHandler(this.cmbProjekte_SelectedIndexChanged);
        // 
        // btnStartStop
        // 
        this.btnStartStop.Location = new System.Drawing.Point(12, 50);
        this.btnStartStop.Name = "btnStartStop";
        this.btnStartStop.Size = new System.Drawing.Size(100, 40);
        this.btnStartStop.TabIndex = 2;
        this.btnStartStop.Text = "Start";
        this.btnStartStop.UseVisualStyleBackColor = true;
        this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
        // 
        // lblTimer
        // 
        this.lblTimer.AutoSize = true;
        this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.lblTimer.Location = new System.Drawing.Point(130, 52);
        this.lblTimer.Name = "lblTimer";
        this.lblTimer.Size = new System.Drawing.Size(110, 32);
        this.lblTimer.TabIndex = 3;
        this.lblTimer.Text = "00:00:00";
        // 
        // listViewEntries
        // 
        this.listViewEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProjekt,
            this.colStart,
            this.colEnde,
            this.colDauer});
        this.listViewEntries.FullRowSelect = true;
        this.listViewEntries.GridLines = true;
        this.listViewEntries.Location = new System.Drawing.Point(12, 200);
        this.listViewEntries.Name = "listViewEntries";
        this.listViewEntries.Size = new System.Drawing.Size(460, 220);
        this.listViewEntries.TabIndex = 4;
        this.listViewEntries.UseCompatibleStateImageBehavior = false;
        this.listViewEntries.View = System.Windows.Forms.View.Details;
        // 
        // colProjekt
        // 
        this.colProjekt.Text = "Projekt";
        this.colProjekt.Width = 120;
        // 
        // colStart
        // 
        this.colStart.Text = "Start";
        this.colStart.Width = 120;
        // 
        // colEnde
        // 
        this.colEnde.Text = "Ende";
        this.colEnde.Width = 120;
        // 
        // colDauer
        // 
        this.colDauer.Text = "Dauer";
        this.colDauer.Width = 80;
        // 
        // timer1
        // 
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        // 
        // grpManuell
        // 
        this.grpManuell.Controls.Add(this.btnManualAdd);
        this.grpManuell.Controls.Add(this.dtpEnd);
        this.grpManuell.Controls.Add(this.dtpStart);
        this.grpManuell.Location = new System.Drawing.Point(12, 110);
        this.grpManuell.Name = "grpManuell";
        this.grpManuell.Size = new System.Drawing.Size(460, 80);
        this.grpManuell.TabIndex = 5;
        this.grpManuell.TabStop = false;
        this.grpManuell.Text = "Manuelle Erfassung";
        // 
        // btnManualAdd
        // 
        this.btnManualAdd.Location = new System.Drawing.Point(340, 30);
        this.btnManualAdd.Name = "btnManualAdd";
        this.btnManualAdd.Size = new System.Drawing.Size(110, 25);
        this.btnManualAdd.TabIndex = 2;
        this.btnManualAdd.Text = "Hinzufügen";
        this.btnManualAdd.UseVisualStyleBackColor = true;
        this.btnManualAdd.Click += new System.EventHandler(this.btnManualAdd_Click);
        // 
        // dtpEnd
        // 
        this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        this.dtpEnd.Location = new System.Drawing.Point(170, 30);
        this.dtpEnd.Name = "dtpEnd";
        this.dtpEnd.Size = new System.Drawing.Size(150, 23);
        this.dtpEnd.TabIndex = 1;
        // 
        // dtpStart
        // 
        this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        this.dtpStart.Location = new System.Drawing.Point(10, 30);
        this.dtpStart.Name = "dtpStart";
        this.dtpStart.Size = new System.Drawing.Size(150, 23);
        this.dtpStart.TabIndex = 0;
        // 
        // lblTotal
        // 
        this.lblTotal.AutoSize = true;
        this.lblTotal.Location = new System.Drawing.Point(12, 430);
        this.lblTotal.Name = "lblTotal";
        this.lblTotal.Size = new System.Drawing.Size(126, 15);
        this.lblTotal.TabIndex = 6;
        this.lblTotal.Text = "Gesamtzeit Projekt: 0h";
        // 
        // Zeitsammlung
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(484, 461);
        this.Controls.Add(this.lblTotal);
        this.Controls.Add(this.grpManuell);
        this.Controls.Add(this.listViewEntries);
        this.Controls.Add(this.lblTimer);
        this.Controls.Add(this.btnStartStop);
        this.Controls.Add(this.cmbProjekte);
        this.Controls.Add(this.btnProjekte);
        this.Name = "Zeitsammlung";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Zeiterfassung";
        this.Load += new System.EventHandler(this.Zeitsammlung_Load);
        this.grpManuell.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button btnProjekte;
    private System.Windows.Forms.ComboBox cmbProjekte;
    private System.Windows.Forms.Button btnStartStop;
    private System.Windows.Forms.Label lblTimer;
    private System.Windows.Forms.ListView listViewEntries;
    private System.Windows.Forms.ColumnHeader colProjekt;
    private System.Windows.Forms.ColumnHeader colStart;
    private System.Windows.Forms.ColumnHeader colEnde;
    private System.Windows.Forms.ColumnHeader colDauer;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.GroupBox grpManuell;
    private System.Windows.Forms.Button btnManualAdd;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label lblTotal;

    #endregion
}