namespace MediTable.Interface
{
    partial class PatientSelectorGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientSelectorGUI));
            MainPanelPatientSelectorGUI = new Panel();
            btnRecord = new Button();
            lblSelect = new Label();
            btnSelectPatient = new Button();
            cmbPatientSelect = new ComboBox();
            lblDeveloper = new Label();
            MainPanelPatientSelectorGUI.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanelPatientSelectorGUI
            // 
            MainPanelPatientSelectorGUI.Controls.Add(btnRecord);
            MainPanelPatientSelectorGUI.Controls.Add(lblSelect);
            MainPanelPatientSelectorGUI.Controls.Add(btnSelectPatient);
            MainPanelPatientSelectorGUI.Controls.Add(cmbPatientSelect);
            MainPanelPatientSelectorGUI.Location = new Point(12, 12);
            MainPanelPatientSelectorGUI.Name = "MainPanelPatientSelectorGUI";
            MainPanelPatientSelectorGUI.Size = new Size(560, 227);
            MainPanelPatientSelectorGUI.TabIndex = 0;
            // 
            // btnRecord
            // 
            btnRecord.Location = new Point(35, 180);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(75, 23);
            btnRecord.TabIndex = 2;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Visible = false;
            btnRecord.Click += btnRecord_Click;
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblSelect.Location = new Point(170, 40);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(220, 25);
            lblSelect.TabIndex = 3;
            lblSelect.Text = "Please select the patient!";
            // 
            // btnSelectPatient
            // 
            btnSelectPatient.Location = new Point(450, 180);
            btnSelectPatient.Name = "btnSelectPatient";
            btnSelectPatient.Size = new Size(75, 23);
            btnSelectPatient.TabIndex = 1;
            btnSelectPatient.Text = "Select";
            btnSelectPatient.UseVisualStyleBackColor = true;
            btnSelectPatient.Click += btnSelectPatient_Click;
            // 
            // cmbPatientSelect
            // 
            cmbPatientSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPatientSelect.FormattingEnabled = true;
            cmbPatientSelect.Location = new Point(116, 102);
            cmbPatientSelect.Name = "cmbPatientSelect";
            cmbPatientSelect.Size = new Size(328, 23);
            cmbPatientSelect.TabIndex = 0;
            // 
            // lblDeveloper
            // 
            lblDeveloper.AutoSize = true;
            lblDeveloper.Location = new Point(426, 242);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(158, 15);
            lblDeveloper.TabIndex = 0;
            lblDeveloper.Text = "Powered by: Luis Felipe Both";
            // 
            // PatientSelectorGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 261);
            Controls.Add(lblDeveloper);
            Controls.Add(MainPanelPatientSelectorGUI);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(600, 300);
            MinimumSize = new Size(600, 300);
            Name = "PatientSelectorGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PatientSelector";
            FormClosing += PatientSelector_FormClosing;
            MainPanelPatientSelectorGUI.ResumeLayout(false);
            MainPanelPatientSelectorGUI.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel MainPanelPatientSelectorGUI;
        private Label lblDeveloper;
        private Button btnSelectPatient;
        private ComboBox cmbPatientSelect;
        private Label lblSelect;
        private Button btnRecord;
    }
}