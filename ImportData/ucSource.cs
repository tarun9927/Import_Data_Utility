using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImportData
{
    public partial class ucSource : UserControl
    {
        string _strFileType = string.Empty;
        WizardData _objWizardData;
        public ucSource(WizardData objWizardData)
        {
            _objWizardData = objWizardData;
            InitializeComponent();            
        }       

        private void lblText_Click(object sender, EventArgs e)
        {
            txtFileName.Text = "";
            _objWizardData.SelectedFilePaths = null;
            this.lblText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.lblCsv.BackColor = System.Drawing.Color.White;
            this.lblExcel.BackColor = System.Drawing.Color.White;
            this.lblExcel2007.BackColor = System.Drawing.Color.White;
           // this.lblXmlFile.BackColor = System.Drawing.Color.White;
            lblDesc.Text = "Import from Text file"; 
            _strFileType = "Text files (*.txt)|*.txt";
            btnBrowse.Enabled = true;
            _objWizardData.SelectedFileType = WizardData.FileType.TextFile;
        }

        private void lblCsv_Click(object sender, EventArgs e)
        {
            txtFileName.Text = "";
            _objWizardData.SelectedFilePaths = null;
            this.lblCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.lblText.BackColor = System.Drawing.Color.White;
            this.lblExcel.BackColor = System.Drawing.Color.White;
            this.lblExcel2007.BackColor = System.Drawing.Color.White;
           // this.lblXmlFile.BackColor = System.Drawing.Color.White;
            lblDesc.Text = "Import from CSV file";
            _strFileType = "CSV files (*.CSV)|*.csv"; ;
            btnBrowse.Enabled = true;
            _objWizardData.SelectedFileType = WizardData.FileType.CsvFile;
        }

        private void lblExcel_Click(object sender, EventArgs e)
        {
            txtFileName.Text = "";
            _objWizardData.SelectedFilePaths = null;
            this.lblExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.lblCsv.BackColor = System.Drawing.Color.White;
            this.lblText.BackColor = System.Drawing.Color.White;
            this.lblExcel2007.BackColor = System.Drawing.Color.White;
           // this.lblXmlFile.BackColor = System.Drawing.Color.White;
            lblDesc.Text = "Import from Microsoft Excel file";
            _strFileType = "Excel files (*.xls)|*.xls";
            btnBrowse.Enabled = true;
            _objWizardData.SelectedFileType = WizardData.FileType.ExcelFile;
        }

        private void lblExcel2007_Click(object sender, EventArgs e)
        {
            txtFileName.Text = "";
            _objWizardData.SelectedFilePaths = null;
            this.lblExcel2007.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.lblCsv.BackColor = System.Drawing.Color.White;
            this.lblExcel.BackColor = System.Drawing.Color.White;
            this.lblText.BackColor = System.Drawing.Color.White;
            //this.lblXmlFile.BackColor = System.Drawing.Color.White;
            lblDesc.Text = "Import from Microsoft Excel 2007+ file";
            _strFileType = "Excel 2007+ files (*.xlsx)|*.xlsx";
            btnBrowse.Enabled = true;
            _objWizardData.SelectedFileType = WizardData.FileType.Excel2007File;
        }

        private void lblXmlFile_Click(object sender, EventArgs e)
        {
            txtFileName.Text = "";
            _objWizardData.SelectedFilePaths = null;
           // this.lblXmlFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.lblCsv.BackColor = System.Drawing.Color.White;
            this.lblExcel.BackColor = System.Drawing.Color.White;
            this.lblExcel2007.BackColor = System.Drawing.Color.White;
            this.lblText.BackColor = System.Drawing.Color.White;
            lblDesc.Text = "Import from Xml file";
            _strFileType = "XML files (*.xml)|*.xml";
            btnBrowse.Enabled = true;
            _objWizardData.SelectedFileType = WizardData.FileType.XmlFile;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog objFileDialog = new OpenFileDialog();
            objFileDialog.Filter = _strFileType;
            objFileDialog.Multiselect = true;
            DialogResult result = objFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string strAllFiles = string.Empty;

                for (int i = 0; i < objFileDialog.FileNames.Length; i++)
                {
                    strAllFiles = strAllFiles + objFileDialog.FileNames[i] + ";";
                }

                txtFileName.Text = strAllFiles.Replace(";","\r\n");
                _objWizardData.SelectedFilePaths = objFileDialog.FileNames;               
            }
        }
        private void ucSource_Load(object sender, EventArgs e)
        {
            btnBrowse.Enabled = false;
        }

        public void setFormState()
        {
            if (_objWizardData.SelectedFileType == WizardData.FileType.TextFile)
                lblText.Select();
            else if (_objWizardData.SelectedFileType == WizardData.FileType.CsvFile)
                lblCsv.Select();
            else if (_objWizardData.SelectedFileType == WizardData.FileType.ExcelFile)
                lblExcel.Select();
            else if (_objWizardData.SelectedFileType == WizardData.FileType.Excel2007File)
                lblExcel2007.Select();
           // else if (_objWizardData.SelectedFileType == WizardData.FileType.XmlFile)
             //   lblXmlFile.Select();

            txtFileName.Text = _objWizardData.SelectedFilePaths[0];
            btnBrowse.Enabled = true;
        }
    }
}
