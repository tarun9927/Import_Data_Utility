using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImportData
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }
        WizardData _objWizardData = new WizardData();
        ucSource _objucSource;
        ucTextFileOption _objucTextFileOption;
        ucExcelFileOption _objucExcelFileOption;
        ucXmlFileOption _objucXmlFileOption;
        ucMapping _objucMapping;
        ucImport _objucImport;
        ucConnection _objucConnection;
        //ucMySQL _objucMySQL;
        //ucSQL _objucSQL;
        private void frmImport_Load(object sender, EventArgs e)
        {
            btnback.Enabled = false;
            _objucSource = new ucSource(_objWizardData);
            _objucConnection = new ucConnection(_objWizardData);
            _objucTextFileOption = new ucTextFileOption(_objWizardData);
            _objucExcelFileOption = new ucExcelFileOption(_objWizardData);
            _objucXmlFileOption = new ucXmlFileOption(_objWizardData);
            _objucMapping = new ucMapping(_objWizardData);
            _objucImport = new ucImport(_objWizardData);

            _objucSource.Size = pnlContainer.Size;
            _objWizardData.FormToShow = WizardData.wizardForms.Source;
            this._objucSource.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(_objucSource);
            lblHeading.Text = "Source File";
            lblDescription.Text = "Select file to import and specify file format.";
            pnlSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));            
        }


        private void btnNext_Click(object sender, EventArgs e)
        {            
            if (WizardData.wizardForms.Source == _objWizardData.FormToShow)
            {
                /*if(_objWizardData.SelectedFilePaths == null || File.Exists("@" + _objWizardData.SelectedFilePaths[0]))
                {
                    MessageBox.Show("File Not Found.", "Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
                pnlContainer.Controls.Clear();

                _objWizardData.FormToShow = WizardData.wizardForms.Connection;
                _objucConnection = new ucConnection(_objWizardData);
                _objucConnection.Size = pnlContainer.Size;
                this._objucConnection.Dock = DockStyle.Fill;
                pnlConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                pnlSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(222)))));
                _objucConnection.Visible = true;
                _objucConnection.Load();
                pnlContainer.Controls.Add(_objucConnection);


            }
            else if(WizardData.wizardForms.Connection == _objWizardData.FormToShow)
            {
                /*if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.NULL)
                {
                    MessageBox.Show("Please Select One.", "Connection Wizard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
                /*if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.NULL)
                {
                    btnNext.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                }*/
                pnlContainer.Controls.Clear();
                _objWizardData.FormToShow = WizardData.wizardForms.Options;
                pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                pnlConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(222)))));
                if (WizardData.FileType.TextFile == _objWizardData.SelectedFileType || WizardData.FileType.CsvFile == _objWizardData.SelectedFileType)
                {
                    pnlContainer.Controls.Clear();
                    _objucTextFileOption.Size = pnlContainer.Size;
                    this._objucTextFileOption.Dock = DockStyle.Fill;
                    _objucTextFileOption.Load();
                    pnlContainer.Controls.Add(_objucTextFileOption);
                }
                else if (WizardData.FileType.ExcelFile == _objWizardData.SelectedFileType || WizardData.FileType.Excel2007File == _objWizardData.SelectedFileType)
                {
                    pnlContainer.Controls.Clear();
                    _objucExcelFileOption.Size = pnlContainer.Size;
                    this._objucExcelFileOption.Dock = DockStyle.Fill;
                    _objucExcelFileOption.Load();
                    pnlContainer.Controls.Add(_objucExcelFileOption);
                }

                else if (WizardData.FileType.XmlFile == _objWizardData.SelectedFileType)
                {
                    pnlContainer.Controls.Clear();
                    _objucXmlFileOption.Size = pnlContainer.Size;
                    this._objucXmlFileOption.Dock = DockStyle.Fill;
                    _objucXmlFileOption.Load();
                    pnlContainer.Controls.Add(_objucXmlFileOption);
                }
            }
            else if (WizardData.wizardForms.Options == _objWizardData.FormToShow)
            {
                btnNext.Enabled = true;
                ValidateFiles();
                _objWizardData.FormToShow = WizardData.wizardForms.Mapping;
                _objucMapping.Size = pnlContainer.Size;
                this._objucMapping.Dock = DockStyle.Fill;
                _objucMapping.Load();
                pnlContainer.Controls.Clear();
                pnlMapping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(222)))));
                pnlContainer.Controls.Add(_objucMapping);
            }
            else if (WizardData.wizardForms.Mapping == _objWizardData.FormToShow)
            {
                _objucMapping.setData();
                ValidateFiles();
                _objucImport.Size = pnlContainer.Size;
                _objWizardData.FormToShow = WizardData.wizardForms.Import;
                _objWizardData.MappingTable = _objucMapping._objFinal;
                this._objucImport.Dock = DockStyle.Fill;               
                pnlContainer.Controls.Clear();
                pnlImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                pnlMapping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(222)))));
                //MessageBox.Show(_objWizardData.tablename);
                btnNext.Text = "Import";
                pnlContainer.Controls.Add(_objucImport);
                _objucImport.Load();

            }

            else if (btnNext.Text == "Import")
            {
                _objucImport.Start();
                btnNext.Text = "Finish";
            }

            else if (btnNext.Text == "Finish")
            {
                //DialogResult dialogResult = MessageBox.Show("Are you sure, you want to close wizard?", "Import Wizard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dialogResult == DialogResult.Yes)
                this.Close();
            }
            btnback.Enabled = true;
        }

        

        private void btnback_Click(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();
            btnNext.Enabled = true;
            if (WizardData.wizardForms.Connection == _objWizardData.FormToShow)
            {
                pnlContainer.Controls.Clear();
                _objWizardData.FormToShow = WizardData.wizardForms.Source;
                _objucTextFileOption = new ucTextFileOption(_objWizardData);
                _objucExcelFileOption = new ucExcelFileOption(_objWizardData);
                _objucXmlFileOption = new ucXmlFileOption(_objWizardData);
                _objucMapping = new ucMapping(_objWizardData);
                _objucImport = new ucImport(_objWizardData);
                _objucConnection = new ucConnection(_objucConnection);
                pnlSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                pnlConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(222)))));
                pnlContainer.Controls.Add(_objucSource);
                btnback.Enabled = false;
            }
            else if (WizardData.wizardForms.Options == _objWizardData.FormToShow)
            {
                pnlContainer.Controls.Clear();
                _objWizardData.FormToShow = WizardData.wizardForms.Connection;
                pnlConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(222)))));  
                pnlContainer.Controls.Add(_objucConnection);
            }
            else if (WizardData.wizardForms.Mapping == _objWizardData.FormToShow)
            {
                _objWizardData.FormToShow = WizardData.wizardForms.Options;
                pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                pnlMapping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(222)))));
                if (WizardData.FileType.TextFile == _objWizardData.SelectedFileType || WizardData.FileType.CsvFile == _objWizardData.SelectedFileType)
                    pnlContainer.Controls.Add(_objucTextFileOption);
                else if (WizardData.FileType.ExcelFile == _objWizardData.SelectedFileType || WizardData.FileType.Excel2007File == _objWizardData.SelectedFileType)
                    pnlContainer.Controls.Add(_objucExcelFileOption);
                else if (WizardData.FileType.XmlFile == _objWizardData.SelectedFileType)
                    pnlContainer.Controls.Add(_objucXmlFileOption);                
            }
            else if (WizardData.wizardForms.Import == _objWizardData.FormToShow)
            {
                _objWizardData.FormToShow = WizardData.wizardForms.Mapping;
                pnlMapping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                pnlImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(222)))));
                pnlContainer.Controls.Add(_objucMapping);
                btnNext.Text = "Next";
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure, you want to close wizad?", "Import Wizard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }
        private Boolean ValidateFiles()
        {
            if (WizardData.FileType.TextFile
                == _objWizardData.SelectedFileType || WizardData.FileType.CsvFile
                == _objWizardData.SelectedFileType)
            {
                for (int intCount = 0; intCount < _objWizardData.SelectedFilePaths.Length; intCount++)
                {
                    if (_objWizardData.FileProcessDetails[intCount, 0] == "")
                    {
                        MessageBox.Show("Please select valid column Spiliter for file name " + _objWizardData.SelectedFilePaths[intCount], "Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (_objWizardData.FileProcessDetails[intCount, 1] == "")
                    {
                        MessageBox.Show("Please select valid header " + _objWizardData.SelectedFilePaths[intCount], "Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            if (WizardData.FileType.XmlFile
                == _objWizardData.SelectedFileType)
            {
                for (int intCount = 0; intCount < _objWizardData.WorkbookList.Count; intCount++)
                {
                    if (_objWizardData.WorkbookList[intCount].WorkbookName == "")
                    {
                        MessageBox.Show("File not a valid XML.", "Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (_objWizardData.WorkbookList[intCount].WorkbookName == "")
                    {
                        MessageBox.Show("File not a valid XML.", "Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                }
            }

            if (WizardData.FileType.ExcelFile == _objWizardData.SelectedFileType || WizardData.FileType.Excel2007File == _objWizardData.SelectedFileType)
            {
                for (int intCount = 0; intCount < _objWizardData.WorkbookList.Count; intCount++)
                {
                    if (_objWizardData.WorkbookList[intCount].WorkbookName == "")
                    {
                        MessageBox.Show("File not a valid XML.", "Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (_objWizardData.WorkbookList[intCount].WorkSheetName == "")
                    {
                        MessageBox.Show("File not a valid XML.", "Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    if (_objWizardData.WorkbookList[intCount].AutoDetect)
                        break;
                    else
                    {
                        if (_objWizardData.WorkbookList[intCount].AutoDetectRange)
                            continue;
                        else
                        {
                            if (_objWizardData.WorkbookList[intCount].CellStartRange == "" && _objWizardData.WorkbookList[intCount].CellEndRange == "")
                            {
                                MessageBox.Show("Please select valid column range for file name " + _objWizardData.WorkbookList[intCount].WorkbookName + " and worksheet name "
                                    + _objWizardData.WorkbookList[intCount].WorkSheetName, "Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                        if (_objWizardData.WorkbookList[intCount].RowHeader == 0)
                        {
                            MessageBox.Show("Please select valid row header for file name " + _objWizardData.WorkbookList[intCount].WorkbookName + " and worksheet name "
                                    + _objWizardData.WorkbookList[intCount].WorkSheetName, "Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlConnectionType_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
