using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace ImportData
{
    public partial class ucExcelFileOption : UserControl
    {
        WizardData _objWizardData;
        string _compConStr = string.Empty;
        Boolean _blnStartCell = false;
        Boolean _blnEndCell = false;
        Boolean _blnStartRow = false;
        WorkBook _objWorkBook;
       

        public ucExcelFileOption(WizardData objWizardData)
        {
            InitializeComponent();
            _objWizardData = objWizardData;
        }
        public void Load()
        {
            Cursor = Cursors.WaitCursor;
            tbBooks.TabPages.Clear();           
            for (int i = 0; i < _objWizardData.SelectedFilePaths.Length; i++)
            {
                tbBooks.TabPages.Add(Path.GetFileName(_objWizardData.SelectedFilePaths[i]), Path.GetFileName(_objWizardData.SelectedFilePaths[i]));               
            }
            FillWorkSheets(_objWizardData.SelectedFilePaths[0]);
            _objWizardData.WorkbookList = new List<WorkBook>();
            Cursor = Cursors.Default;
        }

        private void FillWorkSheets(string strFile)
        {
            Cursor = Cursors.WaitCursor;
            DataTable objDT = getWorkSheets(strFile);
            tbSheets.TabPages.Clear();
            cmbSheets.Items.Clear();
            cmbSheets.Text = "";
            for (int i = 0; i < objDT.Rows.Count; i++)
            {
                if (objDT.Rows[i]["TABLE_NAME"].ToString().EndsWith("$"))
                {
                    tbSheets.TabPages.Add(objDT.Rows[i]["TABLE_NAME"].ToString().Replace("$", ""), objDT.Rows[i]["TABLE_NAME"].ToString().Replace("$", ""));
                    
                    CCBoxItem item = new CCBoxItem(objDT.Rows[i]["TABLE_NAME"].ToString().Replace("$", ""), i);
                    cmbSheets.Items.Add(item);

                    if (_objWizardData.WorkbookList != null)
                    {
                        var sheet = _objWizardData.WorkbookList.Where(p => p.WorkbookName == tbBooks.TabPages[tbBooks.SelectedIndex].Text
                                                                                    && p.WorkSheetName == item.Name).ToList();

                        if (sheet != null && sheet.Count > 0)
                        {
                            cmbSheets.SetItemChecked(cmbSheets.Items.IndexOf(item), true);
                        }
                    }

                }
                else if (objDT.Rows[i]["TABLE_NAME"].ToString().EndsWith("$'"))
                {
                    tbSheets.TabPages.Add(objDT.Rows[i]["TABLE_NAME"].ToString().Replace("$'", "").Replace("'", ""), objDT.Rows[i]["TABLE_NAME"].ToString().Replace("$'", "").Replace("'", ""));
                    
                    CCBoxItem item = new CCBoxItem(objDT.Rows[i]["TABLE_NAME"].ToString().Replace("$'", "").Replace("'", ""), i);
                    cmbSheets.Items.Add(item);
                    if (_objWizardData.WorkbookList != null)
                    {
                        var sheet = _objWizardData.WorkbookList.Where(p => p.WorkbookName == tbBooks.TabPages[tbBooks.SelectedIndex].Text
                                                                                    && p.WorkSheetName == item.Name).ToList();
                        if (sheet != null && sheet.Count > 0)
                        {
                            cmbSheets.SetItemChecked(cmbSheets.Items.IndexOf(item), true);
                        }
                    }
                }
            }
            cmbSheets.MaxDropDownItems = 5;
            cmbSheets.DisplayMember = "Name";
            cmbSheets.ValueSeparator = ", ";
            if (tbSheets.TabPages.Count > 0)
                FillDataGrid(tbSheets.TabPages[0].Text);

            if (chkRange.Checked)
            {
                txtStartCell.Enabled = false;
                txtEndCell.Enabled = false;
                btnStart.Enabled = false;
                btnEnd.Enabled = false;
            }
            Cursor = Cursors.Default;
        }
        private DataTable getWorkSheets(String strFile)
        {
            DataTable objDTSheets = new DataTable();
            _compConStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"", strFile);
            OleDbConnection objConn = new OleDbConnection(_compConStr);
            objConn.Open();
            objDTSheets = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            objConn.Close();
            return objDTSheets;
        }
        private void FillDataGrid(String strTabName)
        {
            DataTable objDTSheets = new DataTable();
            OleDbDataAdapter adpComm = new OleDbDataAdapter("SELECT * FROM [" + strTabName + "$] ", _compConStr);
            adpComm.Fill(objDTSheets);
            adpComm.Dispose();

            grdData.DataSource = objDTSheets;
        }
     

        private void cmbSheets_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            CCBoxItem item = cmbSheets.Items[e.Index] as CCBoxItem;
            if (_objWizardData.WorkbookList != null)
            {
                var sheet = _objWizardData.WorkbookList.Where(p => p.WorkbookName == tbBooks.TabPages[tbBooks.SelectedIndex].Text
                                                                            && p.WorkSheetName == item.Name).ToList();
                if (e.NewValue == CheckState.Checked)
                {
                    if (sheet != null && sheet.Count == 0)
                    {
                        _objWorkBook = new WorkBook();
                        _objWorkBook.WorkbookName = tbBooks.TabPages[tbBooks.SelectedIndex].Text;
                        _objWorkBook.WorkSheetName = tbSheets.TabPages[item.Name].Text;
                        if (chkAutoMode.Checked)
                            _objWorkBook.AutoDetect = true;
                        _objWizardData.WorkbookList.Add(_objWorkBook);
                    }
                }
                else
                {
                    _objWorkBook = _objWizardData.WorkbookList.FirstOrDefault(p => p.WorkbookName == tbBooks.TabPages[tbBooks.SelectedIndex].Text
                                                                                    && p.WorkSheetName == tbSheets.TabPages[item.Name].Text);
                    _objWizardData.WorkbookList.Remove(_objWorkBook);
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            _blnStartCell = true;
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            _blnEndCell = true;
        }
        private void btnStartRow_Click(object sender, EventArgs e)
        {
            _blnStartRow = true;
        }
        private void chkRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRange.Checked)
            {
                txtStartCell.Enabled = false;
                txtEndCell.Enabled = false;
                btnStart.Enabled = false;
                btnEnd.Enabled = false;
            }
            else
            {
                txtStartCell.Enabled = true;
                txtEndCell.Enabled = true;
                btnStart.Enabled = true;
                btnEnd.Enabled = true;
            }
        }
        private void grdData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_blnStartCell)
            {
                txtStartCell.Text = grdData.Columns[e.ColumnIndex].Name + "-" + e.RowIndex;
                _blnStartCell = false;
            }
            if (_blnEndCell)
            {
                txtEndCell.Text = grdData.Columns[e.ColumnIndex].Name + "-" + e.RowIndex;
                _blnEndCell = false;
            }
            if (_blnStartRow)
            {
                txtStartRowIndex.Text = e.RowIndex.ToString();
                _blnStartRow = false;
            }

        }
        private void tbBooks_Selected(object sender, TabControlEventArgs e)
        {
            if (tbBooks.TabPages.Count > 0)
            {
                FillWorkSheets(_objWizardData.SelectedFilePaths[tbBooks.SelectedIndex]);
            }
        }
        private void tbSheets_Selected(object sender, TabControlEventArgs e)
        {
            if (tbSheets.TabPages.Count > 0)
            {
                FillDataGrid(e.TabPage.Text);
            }
        }
        private void tbSheets_Deselected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null)
            {
                _objWorkBook = _objWizardData.WorkbookList.FirstOrDefault(p => p.WorkbookName == tbBooks.TabPages[tbBooks.SelectedIndex].Text
                                                                                    && p.WorkSheetName == e.TabPage.Text);
                if (!chkAutoMode.Checked && _objWorkBook != null)
                {
                    _objWorkBook.AutoDetect = false;
                    if (chkRange.Checked)
                        _objWorkBook.AutoDetectRange = true;
                    else
                    {
                        _objWorkBook.CellStartRange = txtStartCell.Text;
                        _objWorkBook.CellEndRange = txtEndCell.Text;
                    }
                    if (rbFirstRow.Checked)
                        _objWorkBook.RowHeader = 1;
                    else
                    {
                        if (Convert.ToInt32(txtStartRowIndex.Text) > 0)
                            _objWorkBook.RowHeader = Convert.ToInt32(txtStartRowIndex.Text);
                        else
                            MessageBox.Show("Please select a valid row header", "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void chkAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            var Book = _objWizardData.WorkbookList.Where(p => p.WorkbookName == tbBooks.TabPages[tbBooks.SelectedIndex].Text).ToList();
            for (int i = 0; i < Book.Count(); i++)
            {
                ((WorkBook)Book[i]).AutoDetect = chkAutoMode.Checked;
            }
        }  
    }
}

