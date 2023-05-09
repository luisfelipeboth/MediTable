using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;

namespace MediTable.Interface
{
    public partial class PatientSelectorGUI : Form
    {
        #region Attributes
        private string patientsListParameters = "PatientsList.xml";
        public bool flagRecorded = false;
        private bool flagError = false;
        public static string? patientSelected { get; set; }
        #endregion

        #region Constructor
        public PatientSelectorGUI()
        {
            InitializeComponent();
            loadInformations();
        }
        #endregion

        #region Methods
        private void loadInformations()
        {
            cmbPatientSelect.Items.Clear();
            if (File.Exists(patientsListParameters))
            {
                XElement xElement = XElement.Load(patientsListParameters);
                foreach (XElement item in xElement.Elements("cmbPatientList"))
                {
                    foreach (XElement itens in item.Elements("cmbPatientListItem"))
                    {
                        cmbPatientSelect.Items.Add(itens.Value);
                    }
                }
            }
            cmbPatientSelect.Items.Add("New Patient");
        }

        public void saveInformation()
        {
            XElement rootElement = new XElement(patientsListParameters);
            XElement cmbElementPatientList = new XElement("cmbPatientList");
            rootElement.Add(cmbElementPatientList);
            foreach (Object item in cmbPatientSelect.Items)
            {
                if (!item.ToString().Equals("New Patient"))
                {
                    XElement el = new XElement("cmbPatientListItem", item.ToString());
                    cmbElementPatientList.Add(el);
                }
            }
            try
            {
                rootElement.Save(patientsListParameters);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flagError = true;
            }
        }
        #endregion

        #region Event Handlers
        private void PatientSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            flagRecorded = true; //remove after
            saveInformation();
            if (!flagRecorded)
            {
                MessageBox.Show(
                    "Please record your data before closing the application!",
                    "Warning!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning // for Warning  
                                           //MessageBoxIcon.Error // for Error 
                                           //MessageBoxIcon.Information  // for Information
                                           //MessageBoxIcon.Question // for Question
                );
                this.Show();
                btnRecord.Visible = true;
                e.Cancel = true;
            }
            if (flagError) 
            {
                e.Cancel = true;
            }
        }

        private void btnSelectPatient_Click(object sender, EventArgs e)
        {
            if (cmbPatientSelect.SelectedItem != null)
            {
                patientSelected = cmbPatientSelect.SelectedItem.ToString();
                this.Hide();
                MediTableGUI mediTable = new MediTableGUI();
                mediTable.ShowDialog();
                this.Close();
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            flagRecorded = true; //Mudar aqui depois
        }
        #endregion
    }
}
