using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fracton.mxCell.DBLayer;
using System.IO;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;
using Microsoft.VisualBasic.FileIO;
using ImportData;
using System.Data.OleDb;

namespace ImportData
{
    public partial class ucMapping : UserControl
    {
        WizardData _objWizardData;
        bzImport _objbzImport;
        public DataTable _objFinal;
        public Boolean blnbtnNextEnable = false;
        public ucMapping(WizardData objWizardData)
        {
            InitializeComponent();
            _objWizardData = objWizardData;
        }

        public void Load()
        {
            blnbtnNextEnable = false;
            /*if (WizardData.FileType.TextFile
               == _objWizardData.SelectedFileType || WizardData.FileType.CsvFile
               == _objWizardData.SelectedFileType)*/
            txtbxCreateNew.Visible = false;
            //lblCreateNew.Visible = false;
            //lblUseExisting.Visible = false;
            cbUseExisting.Visible = false;
            {
                //BindTxtFileGrid();
            }
            if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.MySQL)
            {
                MySqlConnection konek = new MySqlConnection();
                //for refreshing connection string whenever it will use the previous connection string
                //ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                //MySqlConnection connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = konek.CreateCommand();
                command.CommandText = "SHOW DATABASES;";
                MySqlDataReader Reader;
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    cbSelectDatabase.Visible = true;
                    cbSelectDatabase.Items.Clear();
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        string row = "";
                        for (int i = 0; i < Reader.FieldCount; i++)
                            row += Reader.GetValue(i).ToString() + ", ";
                        cbSelectDatabase.Items.Add(row);
                    }
                    konek.Close();
                }
            }
            if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.SQL)
            {
                SqlConnection konek = new SqlConnection();
                //for refreshing connection string whenever it will use the previous connection string
                ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                //MySqlConnection connection = new MySqlConnection(myConnectionString);
                SqlCommand command = konek.CreateCommand();
                command.CommandText = "SELECT name FROM sys.databases d WHERE d.database_id > 4;";
                SqlDataReader Reader;
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    cbSelectDatabase.Visible = true;
                    cbSelectDatabase.Items.Clear();
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        string row = "";
                        for (int i = 0; i < Reader.FieldCount; i++)
                            row += Reader.GetValue(i).ToString() + ", ";
                        cbSelectDatabase.Items.Add(row);
                    }
                    konek.Close();
                }
            }
        }

        private void BindTxtFileGrid()
        {
           /*_objbzImport = new bzImport(); 
           DataTable objFileDt;
           
          
           //_objFinal = _objbzImport.getFileDetails(1, "MRRSummary");
           //var defaultRow = _objFinal.NewRow();
           


           for (int i = 0; i < _objWizardData.SelectedFilePaths.Length; i++)
		   {
               objFileDt = new DataTable();
               objFileDt.Columns.Add(Path.GetFileName(_objWizardData.SelectedFilePaths[i]));
			   Array.ForEach(getFileColumn(_objWizardData.SelectedFilePaths[i], 
                    Convert.ToInt32(_objWizardData.FileProcessDetails[i,1])).
                    Split(Convert.ToChar(_objWizardData.FileProcessDetails[i,0])),
                    c=> objFileDt.Rows.Add()[0] = c );
              
               var defaultRowDT = objFileDt.NewRow();


               IEnumerable<DataRow[]> result = from dataRows1 in _objFinal.AsEnumerable()
                               join dataRows2 in objFileDt.AsEnumerable()
                               on dataRows1.Field<string>("Column") equals dataRows2.Field<string>(Path.GetFileName(_objWizardData.SelectedFilePaths[i])) into DataGroup
                               from row in DataGroup.DefaultIfEmpty<DataRow>(objFileDt.NewRow())
                               select new DataRow[]{ 
                                        dataRows1,row
                                    };

               toDataTable(result);
           }
           grdMapping.DataSource = _objFinal;

           if (grdMapping.Columns.Count>0)
               grdMapping.Columns[0].Visible = false;*/
        }
        private void toDataTable(IEnumerable<Object> result)
        {
            /*_objFinal = new DataTable();
            DataRow[] list;
            DataRow objRow;
            int intCount = 0;
            for (int i = 0; i < result.Count(); i++)
            {
                list =(DataRow[]) (result.ElementAt(i));
                for (int j = 0; j < list.Length; j++)
                {
                    for (int k = 0; k < list[j].ItemArray.Length; k++)
                    {
                        _objFinal.Columns.Add(list[j].Table.Columns[k].ColumnName, list[j].Table.Columns[k].DataType);    
                    }                    
                }
                break;
            }
            for (int i = 0; i < result.Count(); i++)
            {
                intCount = 0;
                objRow = _objFinal.NewRow();
                list = (DataRow[])(result.ElementAt(i));
                for (int j = 0; j < list.Length; j++)
                {
                    for (int k = 0; k < list[j].ItemArray.Length; k++)
                    {
                        objRow[intCount] = list[j].ItemArray.ElementAt(k);
                        intCount++;
                    }
                }
                _objFinal.Rows.Add(objRow);
            }
            _objFinal.AcceptChanges();*/
        }
        private string getFileColumn(string FileName, int HeaderRow)
        {
            //return File.ReadLines(FileName).Skip(HeaderRow-1).Take(1).First();
            return null;
        }

        private void grdMapping_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            /*DataGridViewCellStyle red = grdMapping.DefaultCellStyle.Clone();
            red.BackColor = Color.Red;
            foreach (DataGridViewRow r in grdMapping.Rows)
            {
                for (int i = 0; i < grdMapping.ColumnCount; i++)
			    {
			        if (r.Cells[i].Value.ToString()== "")
                    {
                        r.DefaultCellStyle = red;
                        blnbtnNextEnable = true;
                    }
			    }                
            }*/
        }


        private void rdbUseExisting_CheckedChanged(object sender, EventArgs e)
        {
            _objWizardData.SelectedTableType = WizardData.SelectTable.Existing;
            if(rdbUseExisting.Checked==true)
            {
                //lblUseExisting.Visible = true;
                cbUseExisting.Visible = true;
            }
            else
            {
                //lblUseExisting.Visible = false;
                cbUseExisting.Visible = false;
            }
            grdMapping.Rows.Clear();
            grdMapping.Columns.Clear();
            _objWizardData.tablename = "";
            if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.MySQL)
            {
                MySqlConnection konek = new MySqlConnection();
                ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                //MySqlConnection connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = konek.CreateCommand();
                command.CommandText = "SHOW TABLES;";
                MySqlDataReader Reader;
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    cbUseExisting.Items.Clear();
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        string row = "";
                        for (int i = 0; i < Reader.FieldCount; i++)
                            row += Reader.GetValue(i).ToString() + ", ";
                        cbUseExisting.Items.Add(row);
                    }
                    //lblMySqlDesp.Text = "Connection is Active.";
                    konek.Close();
                }
            }
            else
            {
                SqlConnection konek = new SqlConnection();
                ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                //MySqlConnection connection = new MySqlConnection(myConnectionString);
                SqlCommand command = konek.CreateCommand();
                command.CommandText = "SELECT name FROM SYSOBJECTS WHERE xtype = 'U';";
                SqlDataReader Reader;
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    cbUseExisting.Items.Clear();
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        string row = "";
                        for (int i = 0; i < Reader.FieldCount; i++)
                            row += Reader.GetValue(i).ToString() + ", ";
                        cbUseExisting.Items.Add(row);
                    }
                    //lblMySqlDesp.Text = "Connection is Active.";
                    konek.Close();
                }
            }

        }

        public void setData()
        {
            if (rdbCreateNew.Checked)
            {
                _objWizardData.tablename = txtbxCreateNew.Text;
                if (_objWizardData.tablename == "")
                {
                    MessageBox.Show("Enter Table Name.");
                }
                string[] SelectedHeaders = new string[grdMapping.Rows.Count];
                string[] ColumnType = new string[grdMapping.Rows.Count];
                for (int rows = 0; rows < grdMapping.Rows.Count; rows++)
                {
                    try
                    {
                        SelectedHeaders[rows] = grdMapping.Rows[rows].Cells[1].Value.ToString();
                        ColumnType[rows] = grdMapping.Rows[rows].Cells[2].Value.ToString();
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                    }
                }
                _objWizardData.SelectedHeaders = SelectedHeaders;
                _objWizardData.SelectedColumnTypes = ColumnType;
                //MessageBox.Show(_objWizardData.SelectedHeaders[1]);
                //MessageBox.Show(_objWizardData.SelectedColumnTypes[1]);
            }
            else
            {
                string selected = cbUseExisting.SelectedItem.ToString();
                var output = selected.Substring(0, selected.Length - 2);
                _objWizardData.tablename = null;
                _objWizardData.tablename = output;
                string[] ColumnName = new string[grdMapping.Rows.Count];
                for (int rows = 0; rows < grdMapping.Rows.Count; rows++)
                {
                    try
                    {
                        string str = grdMapping.Rows[rows].Cells[1].Value.ToString();
                        var cn = str.Substring(0, str.Length - 2);
                        //SelectedHeaders[rows] = grdMapping.Rows[rows].Cells[1].Value.ToString();
                        ColumnName[rows] = cn;
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                    }
                }
                _objWizardData.SelectedColumnNames = ColumnName;
                //MessageBox.Show(_objWizardData.SelectedColumnNames[1]);
            }
        }

        private void pnlConnStat_Paint(object sender, PaintEventArgs e)
        {
            //if(konek.)
        }

        private void cbSelectDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.SQL)
            {
                string selected = cbSelectDatabase.SelectedItem.ToString();
                var output = selected.Substring(0, selected.Length - 2);
                //MessageBox.Show(output);
                StringBuilder a = new StringBuilder(ConfigurationManager.ConnectionStrings["con"].ToString());
                a.Append("; Database = ");
                a.Append(output);
                a.Append(";");
                string strCon = a.ToString();
                updateConfigFile(strCon);
                //create mysql connection
                //SqlConnection konek = new SqlConnection();
                //for refreshing connection string whenever it will use the previous connection string
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            if(_objWizardData.SelectedConnectionType==WizardData.ConnectionTypes.MySQL)
            {
                string selected = cbSelectDatabase.SelectedItem.ToString();
                var output = selected.Substring(0, selected.Length - 2);
                //MessageBox.Show(output);
                StringBuilder a = new StringBuilder(ConfigurationManager.ConnectionStrings["con"].ToString());
                a.Append(";Initial Catalog = ");
                a.Append(output);
                a.Append(";");
                string strCon = a.ToString();
                updateConfigFile(strCon);
                //create mysql connection
                //SqlConnection konek = new SqlConnection();
                //for refreshing connection string whenever it will use the previous connection string
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        public void updateConfigFile(string con)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement xElement in xmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    xElement.FirstChild.Attributes[2].Value = con;

                }
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        private void cbUseExisting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_objWizardData.SelectedFileType==WizardData.FileType.TextFile || _objWizardData.SelectedFileType==WizardData.FileType.CsvFile)
            {
                Application.DoEvents();
                map_textfile_into_existing();
            }
            if(_objWizardData.SelectedFileType == WizardData.FileType.ExcelFile || _objWizardData.SelectedFileType == WizardData.FileType.Excel2007File)
            {
                Application.DoEvents();
                getSheets();
                map_excel_into_existing();
            }
        }

        private void rdbCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            if (_objWizardData.SelectedFileType == WizardData.FileType.TextFile || _objWizardData.SelectedFileType == WizardData.FileType.CsvFile)
            {
                Application.DoEvents();
                map_textfile_into_new();
            }
            if (_objWizardData.SelectedFileType == WizardData.FileType.ExcelFile || _objWizardData.SelectedFileType == WizardData.FileType.Excel2007File)
            {
                Application.DoEvents();
                getSheets();
                map_excel_into_new();
            }
        }

        private void map_textfile_into_existing()
        {
            grdMapping.Rows.Clear();
            grdMapping.Columns.Clear();
            string selected = cbUseExisting.SelectedItem.ToString();
            var output = selected.Substring(0, selected.Length - 2);
            _objWizardData.tablename = null;
            //_objWizardData.tablename = output;
            //MessageBox.Show(_objWizardData.tablename);
            grdMapping.Columns.Add("Headers", "Headers");
            //grdMapping.Columns.Add("Table Headers", "Table Headers");
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Items.Clear();
            combo.HeaderText = "Table Headers";

            string filepath = _objWizardData.SelectedFilePaths[0].ToString();
            var rows = File.ReadLines(filepath).Skip(0).Take(1).First();
            char separator = new char();
            if (_objWizardData.SelectedSeparator == WizardData.Separator.tab)
            {
                separator = '\t';
            }
            if (_objWizardData.SelectedSeparator == WizardData.Separator.space)
            {
                separator = ' ';
            }
            string[] arrRows = rows.Split(separator);
            grdMapping.Rows.Add(arrRows.Length);
            grdMapping.Columns.Add(combo);
            if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.MySQL)
            {
                MySqlConnection konek = new MySqlConnection();
                ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                //MySqlConnection connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = konek.CreateCommand();
                string showheaders = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME  = '" + output + "';".ToString();
                command.CommandText = showheaders;
                MySqlDataReader Reader;
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    combo.Items.Clear();
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        string row = "";
                        for (int i = 0; i < Reader.FieldCount; i++)
                            row += Reader.GetValue(i).ToString() + ", ";
                        combo.Items.Add(row);
                    }
                    //lblMySqlDesp.Text = "Connection is Active.";
                    konek.Close();
                }
            }
            else
            {
                SqlConnection konek = new SqlConnection();
                ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                //MySqlConnection connection = new MySqlConnection(myConnectionString);
                SqlCommand command = konek.CreateCommand();
                string showheaders = "SELECT COLUMN_NAME FROM information_schema.columns WHERE table_name='" + output + "';".ToString();
                command.CommandText = showheaders;
                SqlDataReader Reader;
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    combo.Items.Clear();
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        string row = "";
                        for (int i = 0; i < Reader.FieldCount; i++)
                            row += Reader.GetValue(i).ToString() + ", ";
                        combo.Items.Add(row);
                    }
                    //lblMySqlDesp.Text = "Connection is Active.";
                    konek.Close();
                }
            }
            for (int k = 0; k < arrRows.Length; k++)
            {
                if (Convert.ToString(arrRows[k]) == "") continue;
                grdMapping[0, k].Value = arrRows[k];
                Label l = new Label();
            }
            //grdMapping.ExportRows(Convert.ToString(_objWizardData.SelectedFilePaths));
        }

        private void map_excel_into_existing()
        {
            grdMapping.Rows.Clear();
            grdMapping.Columns.Clear();
            string selected = cbUseExisting.SelectedItem.ToString();
            var output = selected.Substring(0, selected.Length - 2);
            _objWizardData.tablename = null;
            //_objWizardData.tablename = output;
            //MessageBox.Show(_objWizardData.tablename);
            grdMapping.Columns.Add("Headers", "Headers");
            //grdMapping.Columns.Add("Table Headers", "Table Headers");
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Items.Clear();
            combo.HeaderText = "Table Headers";
            //grdMapping.Rows.Add(arrRows.Length);
            grdMapping.Columns.Add(combo);
            if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.MySQL)
            {
                MySqlConnection konek = new MySqlConnection();
                ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                //MySqlConnection connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = konek.CreateCommand();
                string showheaders = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME  = '" + output + "';".ToString();
                command.CommandText = showheaders;
                MySqlDataReader Reader;
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    combo.Items.Clear();
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        string row = "";
                        for (int i = 0; i < Reader.FieldCount; i++)
                            row += Reader.GetValue(i).ToString() + ", ";
                        combo.Items.Add(row);
                    }
                    //lblMySqlDesp.Text = "Connection is Active.";
                    konek.Close();
                }
            }
            else
            {
                SqlConnection konek = new SqlConnection();
                ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                //MySqlConnection connection = new MySqlConnection(myConnectionString);
                SqlCommand command = konek.CreateCommand();
                string showheaders = "SELECT COLUMN_NAME FROM information_schema.columns WHERE table_name='" + output + "';".ToString();
                command.CommandText = showheaders;
                SqlDataReader Reader;
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    combo.Items.Clear();
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        string row = "";
                        for (int i = 0; i < Reader.FieldCount; i++)
                            row += Reader.GetValue(i).ToString() + ", ";
                        combo.Items.Add(row);
                    }
                    //lblMySqlDesp.Text = "Connection is Active.";
                    konek.Close();
                }
            }
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _objWizardData.SelectedFilePaths[0] + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=Yes;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                DataTable dt = new DataTable();
                var sheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                for (int i = 0; i < sheets.Rows.Count; i++)
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT TOP 1 * FROM [" + sheets.Rows[i]["TABLE_NAME"].ToString() + "] ";
                        var adapter = new OleDbDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                int n = dt.Columns.Count;
                grdMapping.Rows.Add(n);
                //foreach (DataColumn column in dt.Columns)
                for (int k = 0; k < n; k++)
                {
                    grdMapping[0, k].Value = dt.Columns[k].ToString();
                   // grdMapping[1, k].Value = dt.Columns[k].ToString();

                }

                foreach (DataGridViewColumn dc in grdMapping.Columns)
                {
                    if (dc.Index.Equals(0))
                    {
                        dc.ReadOnly = true;
                    }
                }
                dt.Clear();
                conn.Close();
                conn.Dispose();
            }
            //grdMapping.ExportRows(Convert.ToString(_objWizardData.SelectedFilePaths));
        }

        private void map_textfile_into_new()
        {
            _objWizardData.SelectedTableType = WizardData.SelectTable.New;
            _objWizardData.tablename = "";
            if (rdbCreateNew.Checked == true)
            {
                //lblCreateNew.Visible = true;
                txtbxCreateNew.Visible = true;
            }
            else
            {
                //lblCreateNew.Visible = false;
                txtbxCreateNew.Visible = false;
            }
            cbUseExisting.SelectedIndex = -1;
            grdMapping.Rows.Clear();
            grdMapping.Columns.Clear();
            grdMapping.Columns.Add("File Headers", "File Headers");
            // grdMapping.Columns.Add("Table Headers", "Table Headers");
            DataGridViewTextBoxColumn dgTetBox = new DataGridViewTextBoxColumn();
            dgTetBox.Name = "Table Headers";
            grdMapping.Columns.Add(dgTetBox);
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Type";
            combo.Items.Add("INT");
            combo.Items.Add("VARCHAR");
            combo.Items.Add("TEXT");
            combo.Items.Add("DATE");
            string filepath = _objWizardData.SelectedFilePaths[0].ToString();
            var rows = File.ReadLines(filepath).Skip(0).Take(1).First();
            char separator = new char();
            if (_objWizardData.SelectedSeparator == WizardData.Separator.tab)
            {
                separator = '\t';
            }
            if (_objWizardData.SelectedSeparator == WizardData.Separator.space)
            {
                separator = ' ';
            }
            else
            {

            }
            string[] arrRows = rows.Split(separator);
            grdMapping.Rows.Add(arrRows.Length);
            grdMapping.Columns.Add(combo);
            for (int k = 0; k < arrRows.Length; k++)
            {
                if (Convert.ToString(arrRows[k]) == "") continue;
                grdMapping[0, k].Value = arrRows[k];
                grdMapping[1, k].Value = arrRows[k];

                Label l = new Label();
            }


            foreach (DataGridViewColumn dc in grdMapping.Columns)
            {
                if (dc.Index.Equals(0))
                {
                    dc.ReadOnly = true;
                }
            }
        }

        private void map_excel_into_new()
        {
            _objWizardData.SelectedTableType = WizardData.SelectTable.New;
            _objWizardData.tablename = "";
            if (rdbCreateNew.Checked == true)
            {
                //lblCreateNew.Visible = true;
                txtbxCreateNew.Visible = true;
            }
            else
            {
                //lblCreateNew.Visible = false;
                txtbxCreateNew.Visible = false;
            }
            cbUseExisting.SelectedIndex = -1;
            grdMapping.Rows.Clear();
            grdMapping.Columns.Clear();
            grdMapping.Columns.Add("File Headers", "File Headers");
            // grdMapping.Columns.Add("Table Headers", "Table Headers");
            DataGridViewTextBoxColumn dgTetBox = new DataGridViewTextBoxColumn();
            dgTetBox.Name = "Table Headers";
            grdMapping.Columns.Add(dgTetBox);
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Type";
            combo.Items.Add("INT");
            combo.Items.Add("VARCHAR");
            combo.Items.Add("TEXT");
            combo.Items.Add("DATE");
            grdMapping.Columns.Add(combo);
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _objWizardData.SelectedFilePaths[0] + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=Yes;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                //tbSheets.TabPages.Add(objDT.Rows[i]["TABLE_NAME"].ToString().Replace("$'", "").Replace("'", ""), objDT.Rows[i]["TABLE_NAME"].ToString().Replace("$'", "").Replace("'", ""));
                DataTable dt = new DataTable();
                var sheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                for (int i = 0; i < sheets.Rows.Count; i++)
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        //tbSheets.TabPages.Add(dt.Rows[i]["TABLE_NAME"].ToString().Replace("$'", "").Replace("'", ""), dt.Rows[i]["TABLE_NAME"].ToString().Replace("$'", "").Replace("'", ""));
                        cmd.CommandText = "SELECT TOP 1 * FROM [" + sheets.Rows[i]["TABLE_NAME"].ToString() + "] ";
                        var adapter = new OleDbDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                int n=dt.Columns.Count;
                grdMapping.Rows.Add(n);
                //foreach (DataColumn column in dt.Columns)
                for(int k=0;k<n;k++)
                {
                    grdMapping[0, k].Value = dt.Columns[k].ToString();
                    grdMapping[1, k].Value = dt.Columns[k].ToString();

                }

                foreach (DataGridViewColumn dc in grdMapping.Columns)
                {
                    if (dc.Index.Equals(0))
                    {
                        dc.ReadOnly = true;
                    }
                }
                dt.Clear();
                conn.Close();
                //conn.Dispose();
            }
        }

        private void getSheets()
        {
            tbSheets.TabPages.Clear();
            DataTable objDTSheets = new DataTable();
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _objWizardData.SelectedFilePaths[0] + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=Yes;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
            OleDbConnection objConn = new OleDbConnection(connectionString);
            objConn.Open();
            objDTSheets = objConn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
            for (int i=1;i<objDTSheets.Rows.Count;i++)
            {
                tbSheets.TabPages.Add(objDTSheets.Rows[i]["TABLE_NAME"].ToString().Replace("$", ""), objDTSheets.Rows[i]["TABLE_NAME"].ToString().Replace("$", ""));
            }
            objConn.Close();
            objConn.Dispose();
                    }
    }
}
