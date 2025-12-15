namespace zeiterfassung_anwendung;

partial class ProjektVerwaltung
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lstProjekte = new System.Windows.Forms.ListBox();
        this.txtName = new System.Windows.Forms.TextBox();
        this.numBudget = new System.Windows.Forms.NumericUpDown();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnNew = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.numBudget)).BeginInit();
        this.SuspendLayout();
        // 
        // lstProjekte
        // 
        this.lstProjekte.FormattingEnabled = true;
        this.lstProjekte.Location = new System.Drawing.Point(12, 12);
        this.lstProjekte.Name = "lstProjekte";
        this.lstProjekte.Size = new System.Drawing.Size(200, 238);
        this.lstProjekte.TabIndex = 0;
        this.lstProjekte.SelectedIndexChanged += new System.EventHandler(this.lstProjekte_SelectedIndexChanged);
        // 
        // txtName
        // 
        this.txtName.Location = new System.Drawing.Point(230, 30);
        this.txtName.Name = "txtName";
        this.txtName.Size = new System.Drawing.Size(150, 23);
        this.txtName.TabIndex = 1;
        // 
        // numBudget
        // 
        this.numBudget.Location = new System.Drawing.Point(230, 80);
        this.numBudget.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        this.numBudget.Name = "numBudget";
        this.numBudget.Size = new System.Drawing.Size(150, 23);
        this.numBudget.TabIndex = 2;
        // 
        // btnSave
        // 
        this.btnSave.Location = new System.Drawing.Point(230, 120);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(75, 23);
        this.btnSave.TabIndex = 3;
        this.btnSave.Text = "Speichern";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Location = new System.Drawing.Point(310, 120);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(75, 23);
        this.btnDelete.TabIndex = 4;
        this.btnDelete.Text = "Löschen";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnNew
        // 
        this.btnNew.Location = new System.Drawing.Point(230, 150);
        this.btnNew.Name = "btnNew";
        this.btnNew.Size = new System.Drawing.Size(155, 23);
        this.btnNew.TabIndex = 7;
        this.btnNew.Text = "Neu / Auswahl aufheben";
        this.btnNew.UseVisualStyleBackColor = true;
        this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(230, 12);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(78, 15);
        this.label1.TabIndex = 5;
        this.label1.Text = "Projektname:";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(230, 62);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(107, 15);
        this.label2.TabIndex = 6;
        this.label2.Text = "Zeitbudget (Min):";
        // 
        // ProjektVerwaltung
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 270);
        this.Controls.Add(this.btnNew);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.numBudget);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lstProjekte);
        this.Name = "ProjektVerwaltung";
        this.Text = "Projektverwaltung";
        ((System.ComponentModel.ISupportInitialize)(this.numBudget)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.ListBox lstProjekte;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.NumericUpDown numBudget;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
}
