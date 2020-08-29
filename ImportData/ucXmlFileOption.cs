using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml;
namespace ImportData
{
    public partial class ucXmlFileOption : UserControl
    {
        
        WizardData _objWizardData;
        XmlDocument _objInput;
        DataSet _objDSOutput;
        DataTable dttemp;
        private BackgroundWorker backgroundWorker1;
        WorkBook _objWorkBook;

        public ucXmlFileOption(WizardData objWizardData)
        {
            InitializeComponent();
            _objWizardData = objWizardData;
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        }
        public void Load()
        {
            try
            {
                rtxtData.Visible = true;
                tbBooks.TabPages.Clear();
                for (int i = 0; i < _objWizardData.SelectedFilePaths.Length; i++)
                {
                    tbBooks.TabPages.Add(Path.GetFileName(_objWizardData.SelectedFilePaths[i]), Path.GetFileName(_objWizardData.SelectedFilePaths[i]));                   
                }
                _objWizardData.WorkbookList = new List<WorkBook>();
                this.backgroundWorker1.RunWorkerAsync();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillDataGrid(String strTabName)
        {
            grdData.DataSource = _objDSOutput.Tables[strTabName];
        }
        private DataSet getData()
        {
            IEnumerable<XElement> nodeList;
            _objDSOutput = new DataSet();
            _objInput = new XmlDocument();
            DataTable objDT;
            try
            {
                Cursor = Cursors.WaitCursor;
                XDocument doc = XDocument.Load(_objWizardData.SelectedFilePaths[0]);

                var result = doc.Element("raml").Element("cmData").Elements("managedObject")
                                .Select(ele => (string)ele.Attribute("class"))
                                .Distinct()
                                .ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    nodeList = doc.Element("raml").Element("cmData").Elements("managedObject").Where(q => (string)q.Attribute("class") == result[i]);
                    objDT = ConvertXmlNodeListToDataTable(nodeList.ToList());
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    objDT.TableName = result[i];
                    _objDSOutput.Tables.Add(objDT);
                    

                    nodeList = null;
                    objDT = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }                
                GC.Collect();
                GC.WaitForPendingFinalizers();                
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message,"Import Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _objDSOutput;
        }        

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int intLineCount = 0;
            string filename = _objWizardData.SelectedFilePaths[tbBooks.SelectedIndex];
            rtxtData.Text = "";
            foreach (string line in File.ReadLines(filename))
            {
                intLineCount++;
                string text = line; // Prevent modified closure.
                rtxtData.AppendText(text + "\n");
                if (intLineCount > 2000)
                    break;
            }
        }
        public DataTable ConvertXmlNodeListToDataTable(IList<XElement> xnl)
        {
            DataRow dr;
            DataColumn dc;
            dttemp = new DataTable();
            int TempColumn = 0;


            string strDistName = xnl[0].Attribute("distName").Value;

            string[] strarr = strDistName.Split('/');

            for (int intCount = 1; intCount < strarr.Length; intCount++)
            {
                dc = new DataColumn(strarr[intCount].Split('-')[0].ToString().Trim(), System.Type.GetType("System.String"));
                dttemp.Columns.Add(dc);
            }
            DataColumn dcID = new DataColumn("id", System.Type.GetType("System.String"));
            dttemp.Columns.Add(dcID);
            foreach (XElement node in xnl[0].Elements().ToList())
            {
                TempColumn++;
                dc = new DataColumn(node.Attribute("name").Value.Trim(), System.Type.GetType("System.String"));
                dc.DefaultValue = "";
                if (dttemp.Columns.Contains(node.Attribute("name").Value.Trim()))
                {
                    dttemp.Columns.Add(dc.ColumnName = dc.ColumnName + TempColumn.ToString());
                }
                else
                {
                    dttemp.Columns.Add(dc);
                }
            }
            string strList = string.Empty;
            int ColumnsCount = dttemp.Columns.Count;

            for (int i = 0; i < xnl.Count; i++)
            {
                dr = dttemp.NewRow();
                strarr = xnl[i].Attribute("distName").Value.Split('/');
                for (int intCount = 1; intCount < strarr.Length; intCount++)
                {
                    dr[strarr[intCount].Split('-')[0]] = strarr[intCount].Split('-')[1].ToString();
                }
                dr["id"] = xnl[i].Attribute("id").Value;
                foreach (XElement node in xnl[i].Elements().ToList())
                {

                    if (!dttemp.Columns.Contains(node.Attribute("name").Value.Trim()))
                    {
                        dc = new DataColumn(node.Attribute("name").Value, System.Type.GetType("System.String"));
                        dc.DefaultValue = "";
                        dttemp.Columns.Add(dc);
                    }

                    if (node.Name.ToString().Trim() == "list")
                    {
                        foreach (XElement node1 in node.Elements().ToList())
                        {

                            strList = strList + node1.Value + ";";
                        }
                        dr[node.Attribute("name").Value] = strList.Substring(0, strList.Length - 1);
                        strList = "";
                    }
                    else
                        dr[node.Attribute("name").Value] = node.Value.ToString();
                }
                dttemp.Rows.Add(dr);
            }
            return dttemp;
        }
        private void tbSheets_Selected(object sender, TabControlEventArgs e)
        {
            if (tbSheets.TabPages.Count>0)
                FillDataGrid(e.TabPage.Text);
        }
        private void tbBooks_Selected(object sender, TabControlEventArgs e)
        {
            if (tbBooks.TabPages.Count > 0)
            {
                btnPreview.Text = "Preview";
                cmbSheets.Items.Clear();
                cmbSheets.Text = "";
                tbSheets.TabPages.Clear();
                rtxtData.Visible = true;
                grdData.Visible = false;
                this.backgroundWorker1.RunWorkerAsync();
            }                
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (btnPreview.Text == "Preview")
            {
                tbSheets.TabPages.Clear();
                cmbSheets.Items.Clear();
                getData();
                for (int i = 0; i < _objDSOutput.Tables.Count; i++)
                {
                    CCBoxItem item = new CCBoxItem(_objDSOutput.Tables[i].TableName, i);
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
                    tbSheets.TabPages.Add(_objDSOutput.Tables[i].TableName, _objDSOutput.Tables[i].TableName);
                }
                cmbSheets.MaxDropDownItems = 5;
                cmbSheets.DisplayMember = "Name";
                cmbSheets.ValueSeparator = ", ";
                if (tbSheets.TabPages.Count > 0)
                    FillDataGrid(tbSheets.TabPages[0].Text);
                rtxtData.Visible = false;
                grdData.Visible = true;
                Cursor = Cursors.Default;
                btnPreview.Text = "Back";
            }
            else
            {
                btnPreview.Text = "Preview";
                cmbSheets.Items.Clear();
                cmbSheets.Text = "";
                tbSheets.TabPages.Clear();
                rtxtData.Visible = true;
                grdData.Visible = false;
                this.backgroundWorker1.RunWorkerAsync();
            }
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

        private void ucXmlFileOption_Load(object sender, EventArgs e)
        {

        }       
    }
}
