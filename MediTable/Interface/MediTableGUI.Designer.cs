namespace MediTable
{
    partial class MediTableGUI
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediTableGUI));
            MainPanelMediTableGUI = new Panel();
            SuspendLayout();
            // 
            // MainPanelMediTableGUI
            // 
            MainPanelMediTableGUI.Location = new Point(12, 12);
            MainPanelMediTableGUI.Name = "MainPanelMediTableGUI";
            MainPanelMediTableGUI.Size = new Size(1240, 647);
            MainPanelMediTableGUI.TabIndex = 0;
            // 
            // MediTableGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(MainPanelMediTableGUI);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MediTableGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MediTable";
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanelMediTableGUI;
    }
}