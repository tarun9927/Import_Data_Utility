using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Fracton.mxCell.DBLayer;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
//using Fracton.MaxRAN.DBLayer;

namespace ImportData
{
    public partial class ucImport : UserControl
    {
       WizardData _objWizardData;
       bzImport _objbzImport;
       DataTable _objFileDt;
       DBFunctions _dbf = null;

       string folderPath;
       public ucImport(WizardData objWizardData)
       {
           InitializeComponent();
           _objWizardData = objWizardData;
           _objbzImport = new bzImport();
       }

       public void Load()
       {
            bindGrid();
            lblProcessing.Visible = false;
            progressBar1.Visible = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            grdStatus.Rows.Clear();
            grdStatus.Columns.Clear();
            grdStatus.Columns.Add("Process", "Process");
            grdStatus.Columns.Add("Status", "Status");
            grdStatus.Columns.Add("Message", "Message");
            grdStatus.Rows.Add(4);
            grdStatus[0, 0].Value = "Validate Data";
            grdStatus[0, 1].Value = "Filtering Data";
            grdStatus[0, 2].Value = "Creating Table";
            grdStatus[0, 3].Value = "Importing";
            //grdStatus.Rows.Add("Validate Data");
            //grdStatus.Rows.Add("Validate Data");
            //grdStatus.Rows.Add("Validate Data");
        }
       public void Start()
       {           
            lblProcessing.Visible = true;
            progressBar1.Visible = true;
            BackgroundWorker bw = new BackgroundWorker();
            bw.RunWorkerCompleted += (bwSender, bwArg) =>
            {
                lblProcessing.Visible = false;
                progressBar1.Visible = false;
            };
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();

        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_objWizardData.SelectedFileType == WizardData.FileType.TextFile || _objWizardData.SelectedFileType == WizardData.FileType.CsvFile)
            {
                if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.MySQL)
                {
                    if (_objWizardData.SelectedTableType == WizardData.SelectTable.New)
                    {
                        Application.DoEvents();
                        create_new_MySQL();
                    }
                    else
                    {
                        Application.DoEvents();
                        enter_into_existing_MySQL();
                    }
                }
                else
                {
                    if (_objWizardData.SelectedTableType == WizardData.SelectTable.New)
                    {
                        Application.DoEvents();
                        create_new_SQL();
                    }
                    else
                    {
                        Application.DoEvents();
                        enter_into_existing_SQL();
                    }
                }
            }

            if(_objWizardData.SelectedFileType==WizardData.FileType.ExcelFile || _objWizardData.SelectedFileType == WizardData.FileType.Excel2007File)
            {
                Application.DoEvents();
                ConvertExcel();
                if (_objWizardData.SelectedConnectionType == WizardData.ConnectionTypes.MySQL)
                {
                    if (_objWizardData.SelectedTableType == WizardData.SelectTable.New)
                    {
                        Application.DoEvents();
                        create_new_MySQL();
                    }
                    else
                    {
                        Application.DoEvents();
                        enter_into_existing_MySQL();
                    }
                }
                else
                {
                    if (_objWizardData.SelectedTableType == WizardData.SelectTable.New)
                    {
                        Application.DoEvents();
                        create_new_SQL();
                    }
                    else
                    {
                        Application.DoEvents();
                        enter_into_existing_SQL();
                    }
                }
            }

            lblProcessing.Visible = false;
            progressBar1.Visible = false;
            //Application.DoEvents();
            //Validate();
            /*Application.DoEvents();
            PrepareData();
            Application.DoEvents();
            CreateTable();
            Application.DoEvents();
            Execute();
            Application.DoEvents();
            PostExecute();
            Application.DoEvents();
            */
            throw new NotImplementedException();
        }

        private void bindGrid()
       {
           _objbzImport = new bzImport();           
          // _objFileDt = _objbzImport.getImportAction();
           grdStatus.DataSource = _objFileDt;           
       }

       public void ConvertExcel()
        {
            using (OleDbConnection cn = new OleDbConnection())
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _objWizardData.SelectedFilePaths[0] + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=Yes;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
                    using (OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM[SHEET 1$] ",cn.ConnectionString))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        //string str = "";
                        //string tab
                        /*string tab = @" ""t ";
                        StringBuilder a = new StringBuilder();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            a.Append("row["+i+"]");
                            if (i != dt.Columns.Count - 1)
                            {
                                a.Append(" + ");
                                //a.Append(""");
                                a.Append(tab);
                                a.Append(" + ");
                            }
                        }
                        string str = a.ToString();*/
                        using (StreamWriter wr = new StreamWriter(@"C:\Users\Tarun Sharma\Desktop\New folder\file.txt"))
                        {
                            
                            foreach (DataRow row in dt.Rows)
                            {
                                for(int i =0;i<dt.Columns.Count;i++)
                                {
                                    wr.Write(row[i]);
                                    //wr.Write("\t");
                                    if(i!=dt.Columns.Count-1)
                                    {
                                        wr.Write("\t");
                                        //a.Append("\t");
                                    }
                                }
                                wr.Write("\n");
                               // str=a.ToString();*/
                                //wr.WriteLine(str);
                                //wr.WriteLine(row[0] + "\t" + row[1] + "\t" +row[2]+ "\t" + row[3] + "\t" + row[4] + "\t" + row[5] + "\t" + row[6] + "\t" + row[7] + "\t" + row[8] + "\t" + row[9] + "\t" + row[10]);
                            }
                        }
                        adp.Dispose();
                    }

                    cn.Close();
                }
            }
            _objWizardData.addr = @"C:\Users\Tarun Sharma\Desktop\New folder\file.txt";
            //string addr = @"C:\Users\Tarun Sharma\Desktop\New folder\file.txt";
        }
       
       private void create_new_SQL()
       {
            try
            {
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Validating Data...."; }));
                string query = "";
                
                SqlConnection konek = new SqlConnection();
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                konek.Open();
                //_dbf = new DBFunctions();
                /*if (!validation())
                    return;*/
                int count = 0;
                //foreach (string strPath in Directory.GetFiles(txtFolderPath.Text, "*.txt").Select(Path.GetFullPath))
                //{
                string strColumn = "(";
                string strDetailColumn = string.Empty;
                string strNullReplacableQuery = string.Empty;

                string filePath = "";

                //string strTableName = "queryMRR16jan2018";
                string strTableName = "rxlevel0";
                if (count == 0 && true)
                    strTableName = _objWizardData.tablename;
                else if (count == 1 && true)
                    strTableName = _objWizardData.tablename;
                else if (count == 2 && true)
                    strTableName = _objWizardData.tablename;

                //strTableName = Path.GetFileNameWithoutExtension(strPath);   // rw["file_name"].ToString().Trim();
                //filePath = strPath;// +"\\" + rw["file_name"].ToString().Trim() + ".txt";
                //string strPath = txtFolderPath.Text;
                if (_objWizardData.SelectedFileType == WizardData.FileType.TextFile || _objWizardData.SelectedFileType == WizardData.FileType.CsvFile)
                    filePath = _objWizardData.SelectedFilePaths[0];
                else
                    filePath = _objWizardData.addr;

                var Column = File.ReadLines(filePath).Skip(0).Take(1).First();
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 0].Value = "Success"; }));
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Preparing Data...."; }));
                string[] arrCoulmns = Column.Split('\t');

                for (int k = 0; k < _objWizardData.SelectedHeaders.Length; k++)
                {
                    if (Convert.ToString(_objWizardData.SelectedHeaders[k]) == "") continue;
                    strDetailColumn +=  Convert.ToString(_objWizardData.SelectedHeaders[k]) + ",";
                    strNullReplacableQuery += "`" + Convert.ToString(_objWizardData.SelectedHeaders[k]) + " = NULLIF(" + Convert.ToString(_objWizardData.SelectedHeaders[k]) + ",),";
                    if (_objWizardData.SelectedHeaders[k].ToString().Contains(":"))
                    {
                        strColumn += "" + Convert.ToString(_objWizardData.SelectedHeaders[k].Split(':')[0]).Replace("\"", "") + " " + Convert.ToString(_objWizardData.SelectedColumnTypes[k]) + "(100) Null,";
                    }
                    else if (_objWizardData.SelectedHeaders[k].ToString().Contains("Period start time"))
                        strColumn += "" + Convert.ToString(_objWizardData.SelectedHeaders[k]).Replace("\"", "") + " " + Convert.ToString(_objWizardData.SelectedColumnTypes[k]) + "(100) Null,";
                    else if (_objWizardData.SelectedHeaders[k].ToString().Contains("BCC,NCC"))
                        strColumn += "BCC " + Convert.ToString(_objWizardData.SelectedColumnTypes[k]) + "(100) Null,";
                    else
                        strColumn += "" + Convert.ToString(_objWizardData.SelectedHeaders[k]).Replace("\"", "") + " " + Convert.ToString(_objWizardData.SelectedColumnTypes[k]) + "(100) Null,";
                }
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 1].Value = "Success"; }));
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Creating Table...."; }));
                //progressBar1.MarqueeAnimationSpeed = 100;
                strDetailColumn = strDetailColumn.Substring(0, strDetailColumn.Length - 1);
                strNullReplacableQuery = strNullReplacableQuery.Substring(0, strNullReplacableQuery.Length - 1);
                strColumn = strColumn.TrimEnd(',');
                strColumn += ")";
                //query = "SELECT table_name FROM information_schema.tables WHERE"
                 //       + " table_name = '" + strTableName + "'; ";

                //DataTable dt = reader.FireSelectSql(query);
                
                query = "CREATE TABLE " + strTableName + " " + strColumn;
                SqlCommand command = konek.CreateCommand();
                command.CommandText = query;
                SqlDataReader Reader;
                Reader = command.ExecuteReader();
                Reader.Close();
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 2].Value = "Success"; }));
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Inserting Data...."; }));
                /* query = "LOAD DATA INFILE '" + filePath.Replace(@"\", "/").Replace(@"\\", "/") + "' INTO TABLE " + strTableName + " FIELDS TERMINATED BY  '\t'  OPTIONALLY  ENCLOSED BY '\"' LINES " +
                                "TERMINATED BY '\n'  IGNORE 1 LINES";// (" + strDetailColumn.Replace(" ", "") + ") ;";//+ getAddonStringQuery(_objWizardData.TableID, _objWizardData.UploadedFileType, strNullReplacableQuery, strFileName) + ";";
                 //_dbf.FireDMLSql(query);
                 SqlCommand insert = konek.CreateCommand();
                 insert.CommandText = query;
                 SqlDataReader reader;
                 reader = insert.ExecuteReader();*/
                int len = File.ReadLines(filePath).Skip(1).Count();
                for (int i = 0; i < len; i++)
                {
                    var Column1 = File.ReadLines(filePath).Skip(i + 1).Take(1).First();
                    string[] arrCoulmns1 = Column1.Split('\t');
                    StringBuilder insert = new StringBuilder("INSERT INTO ");
                    insert.Append(_objWizardData.tablename);
                    insert.Append(" (");
                    for (int k = 0; k < arrCoulmns.Length; k++)
                    {
                        insert.Append(_objWizardData.SelectedHeaders[k]);
                        if (k != arrCoulmns.Length - 1)
                        {
                            insert.Append(",");
                        }
                    }
                    insert.Append(")");
                    insert.Append(" VALUES (");
                    for (int k = 0; k <arrCoulmns.Length; k++)
                    {
                        insert.Append("'");
                        insert.Append(arrCoulmns1[k]);
                        insert.Append("'");
                        if (k != arrCoulmns.Length - 1)
                        {
                            insert.Append(",");
                        }
                    }
                    this.Invoke(new MethodInvoker(delegate { grdStatus[1, 1].Value = "Success"; }));
                    this.Invoke(new MethodInvoker(delegate { grdStatus[1, 2].Value = "Success"; }));
                    this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Entering Data......"; }));
                    insert.Append(");");
                    string str = insert.ToString();
                    SqlConnection konek1 = new SqlConnection();
                    konek1.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                    //MySqlConnection connection = new MySqlConnection(myConnectionString);
                    SqlCommand Command = konek1.CreateCommand();
                    Command.CommandText = str;
                    SqlDataReader Reader1;
                    konek.Close();
                    konek1.Open();
                    if (konek1.State == ConnectionState.Open)
                    {
                        Reader1 = Command.ExecuteReader();
                        konek1.Close();
                    }
                }
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 3].Value = "Success"; }));
                //                MessageBox.Show("Conversion Complete");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void enter_into_existing_SQL()
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Validating...."; }));
                string query = "";
                //_dbf = new DBFunctions();

                /*if (!validation())
                    return;*/
                int count = 0;

                string filePath = "";

                //string strTableName = "queryMRR16jan2018";
                string strTableName = "rxlevel0";
                if (count == 0 && true)
                    strTableName = _objWizardData.tablename;
                else if (count == 1 && true)
                    strTableName = _objWizardData.tablename;
                else if (count == 2 && true)
                    strTableName = _objWizardData.tablename;
                if(_objWizardData.SelectedFileType==WizardData.FileType.TextFile || _objWizardData.SelectedFileType == WizardData.FileType.CsvFile)
                    filePath = _objWizardData.SelectedFilePaths[0];
                else
                    filePath = _objWizardData.addr;
                int len = File.ReadLines(filePath).Skip(1).Count();
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 0].Value = "Success"; }));
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Preparing Data...."; }));
                for (int i = 0; i < len; i++)
                {
                    var Column = File.ReadLines(filePath).Skip(i + 1).Take(1).First();
                    string[] arrCoulmns = Column.Split('\t');
                    StringBuilder insert = new StringBuilder("INSERT INTO ");
                    insert.Append(_objWizardData.tablename);
                    insert.Append(" (");
                    for (int k = 0; k < _objWizardData.SelectedColumnNames.Length; k++)
                    {
                        insert.Append(_objWizardData.SelectedColumnNames[k]);
                        if (k != _objWizardData.SelectedColumnNames.Length - 1)
                        {
                            insert.Append(",");
                        }
                    }
                    insert.Append(")");
                    insert.Append(" VALUES (");
                    for (int k = 0; k < _objWizardData.SelectedColumnNames.Length; k++)
                    {
                        insert.Append("'");
                        insert.Append(arrCoulmns[k]);
                        insert.Append("'");
                        if (k != _objWizardData.SelectedColumnNames.Length - 1)
                        {
                            insert.Append(",");
                        }
                    }
                    this.Invoke(new MethodInvoker(delegate { grdStatus[1, 1].Value = "Success"; }));
                    this.Invoke(new MethodInvoker(delegate { grdStatus[1, 2].Value = "Success"; }));
                    this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Entering Data......"; }));
                    insert.Append(");");
                    string str = insert.ToString();
                    SqlConnection konek = new SqlConnection();
                    konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                    //MySqlConnection connection = new MySqlConnection(myConnectionString);
                    SqlCommand command = konek.CreateCommand();
                    command.CommandText = str;
                    SqlDataReader Reader;
                    konek.Open();
                    if (konek.State == ConnectionState.Open)
                    {
                        Reader = command.ExecuteReader();
                        konek.Close();
                    }
                }
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 3].Value = "Success"; }));
                //this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Completed!"; }));
                //MessageBox.Show("Conversion Complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       private void create_new_MySQL()
       {
            try
            {
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Validating Data...."; }));
                string query = "";
                _dbf = new DBFunctions();

                /*if (!validation())
                    return;*/
                int count = 0;
                //foreach (string strPath in Directory.GetFiles(txtFolderPath.Text, "*.txt").Select(Path.GetFullPath))
                //{
                string strColumn = "(";
                string strDetailColumn = string.Empty;
                string strNullReplacableQuery = string.Empty;

                string filePath = "";

                //string strTableName = "queryMRR16jan2018";
                string strTableName = "rxlevel0";
                if (count == 0 && true)
                    strTableName = _objWizardData.tablename;
                else if (count == 1 && true)
                    strTableName = _objWizardData.tablename;
                else if (count == 2 && true)
                    strTableName = _objWizardData.tablename;

                //strTableName = Path.GetFileNameWithoutExtension(strPath);   // rw["file_name"].ToString().Trim();
                //filePath = strPath;// +"\\" + rw["file_name"].ToString().Trim() + ".txt";
                //string strPath = txtFolderPath.Text;
                if (_objWizardData.SelectedFileType == WizardData.FileType.TextFile || _objWizardData.SelectedFileType == WizardData.FileType.CsvFile)
                    filePath = _objWizardData.SelectedFilePaths[0];
                else
                    filePath = _objWizardData.addr;

                var Column = File.ReadLines(filePath).Skip(0).Take(1).First();
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 0].Value = "Success"; }));
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Preparing Data...."; }));
                string[] arrCoulmns = Column.Split('\t');

                for (int k = 0; k < _objWizardData.SelectedHeaders.Length; k++)
                {
                    if (Convert.ToString(_objWizardData.SelectedHeaders[k]) == "") continue;
                    strDetailColumn += "`" + Convert.ToString(_objWizardData.SelectedHeaders[k]) + "`,";
                    strNullReplacableQuery += "`" + Convert.ToString(_objWizardData.SelectedHeaders[k]) + "` = NULLIF(`" + Convert.ToString(_objWizardData.SelectedHeaders[k]) + "`,''),";
                    if (_objWizardData.SelectedHeaders[k].ToString().Contains(":"))
                    {
                        strColumn += "`" + Convert.ToString(_objWizardData.SelectedHeaders[k].Split(':')[0]).Replace("\"", "") + "` " + Convert.ToString(_objWizardData.SelectedColumnTypes[k]) + "(100) Null,";
                    }
                    else if (_objWizardData.SelectedHeaders[k].ToString().Contains("Period start time"))
                        strColumn += "`" + Convert.ToString(_objWizardData.SelectedHeaders[k]).Replace("\"", "") + "` " + Convert.ToString(_objWizardData.SelectedColumnTypes[k]) + "(100) Null,";
                    else if (_objWizardData.SelectedHeaders[k].ToString().Contains("BCC,NCC"))
                        strColumn += "`BCC` " + Convert.ToString(_objWizardData.SelectedColumnTypes[k]) + "(100) Null,";
                    else
                        strColumn += "`" + Convert.ToString(_objWizardData.SelectedHeaders[k]).Replace("\"", "") + "` " + Convert.ToString(_objWizardData.SelectedColumnTypes[k]) + "(100) Null,";
                }
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 1].Value = "Success"; }));
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Creating Table...."; }));
                //progressBar1.MarqueeAnimationSpeed = 100;
                strDetailColumn = strDetailColumn.Substring(0, strDetailColumn.Length - 1);
                strNullReplacableQuery = strNullReplacableQuery.Substring(0, strNullReplacableQuery.Length - 1);
                strColumn = strColumn.TrimEnd(',');
                strColumn += ")";
                query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'test'"
                        + "AND table_name = '" + strTableName + "'; ";
                DataTable dt = _dbf.FireSelectSql(query);

                if (dt.Rows.Count == 0)
                {
                    DBTableByProcedure("CREATE", strTableName, strColumn);
                    count++;
                }
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 2].Value = "Success"; }));
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Inserting Data...."; }));
                query = "LOAD DATA INFILE '" + filePath.Replace(@"\", "/").Replace(@"\\", "/") + "' INTO TABLE " + strTableName + " FIELDS TERMINATED BY  '\t'  OPTIONALLY  ENCLOSED BY '\"' LINES " +
                               "TERMINATED BY '\n'  IGNORE 1 LINES";// (" + strDetailColumn.Replace(" ", "") + ") ;";//+ getAddonStringQuery(_objWizardData.TableID, _objWizardData.UploadedFileType, strNullReplacableQuery, strFileName) + ";";
                _dbf.FireDMLSql(query);
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 3].Value = "Success"; }));
//                MessageBox.Show("Conversion Complete");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       }
       
       private void enter_into_existing_MySQL()
       {
            try
            {
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Validating...."; }));
                string query = "";
                _dbf = new DBFunctions();

                /*if (!validation())
                    return;*/
                int count = 0;

                string filePath = "";

                //string strTableName = "queryMRR16jan2018";
                string strTableName = "rxlevel0";
                if (count == 0 && true)
                    strTableName = _objWizardData.tablename;
                else if (count == 1 && true)
                    strTableName = _objWizardData.tablename;
                else if (count == 2 && true)
                    strTableName = _objWizardData.tablename;

                if (_objWizardData.SelectedFileType == WizardData.FileType.TextFile || _objWizardData.SelectedFileType == WizardData.FileType.CsvFile)
                    filePath = _objWizardData.SelectedFilePaths[0];
                else
                    filePath = _objWizardData.addr;
                int len = File.ReadLines(filePath).Skip(1).Count();
                this.Invoke(new MethodInvoker(delegate { grdStatus[1,0].Value="Success"; }));
                this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Preparing Data...."; }));
                for (int i = 0; i < len; i++)
                {
                    var Column = File.ReadLines(filePath).Skip(i + 1).Take(1).First();
                    string[] arrCoulmns = Column.Split('\t');
                    StringBuilder insert = new StringBuilder("INSERT INTO ");
                    insert.Append(_objWizardData.tablename);
                    insert.Append(" (");
                    for (int k = 0; k < _objWizardData.SelectedColumnNames.Length; k++)
                    {
                        insert.Append(_objWizardData.SelectedColumnNames[k]);
                        if (k != _objWizardData.SelectedColumnNames.Length - 1)
                        {
                            insert.Append(",");
                        }
                    }
                    insert.Append(")");
                    insert.Append(" VALUES (");
                    for (int k = 0; k < _objWizardData.SelectedColumnNames.Length; k++)
                    {
                        insert.Append("'");
                        insert.Append(arrCoulmns[k]);
                        insert.Append("'");
                        if (k != _objWizardData.SelectedColumnNames.Length - 1)
                        {
                            insert.Append(",");
                        }
                    }
                    this.Invoke(new MethodInvoker(delegate { grdStatus[1,1].Value="Success"; }));
                    this.Invoke(new MethodInvoker(delegate { grdStatus[1,2].Value = "Success"; }));
                    this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Entering Data......"; }));                  
                    insert.Append(");");
                    string str = insert.ToString();
                    MySqlConnection konek = new MySqlConnection();
                    konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                    //MySqlConnection connection = new MySqlConnection(myConnectionString);
                    MySqlCommand command = konek.CreateCommand();
                    command.CommandText = str;
                    MySqlDataReader Reader;
                    konek.Close();
                    konek.Open();
                    if (konek.State == ConnectionState.Open)
                    {
                        Reader = command.ExecuteReader();
                        konek.Close();
                    }
                }
                this.Invoke(new MethodInvoker(delegate { grdStatus[1, 3].Value = "Success"; }));
                //this.Invoke(new MethodInvoker(delegate { lblProcessing.Text = "Completed!"; }));
                //MessageBox.Show("Conversion Complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       }
       private void Validate()
       {
           Boolean blnValidate = false;
           _objFileDt.Rows[0][1] = "Processing";          
           for (int i = 0; i < _objWizardData.MappingTable.Rows.Count; i++)
           {
               for (int j = 0; j < _objWizardData.MappingTable.Columns.Count; j++)
               {
                   if (_objWizardData.MappingTable.Rows[i][j].ToString().Trim() == "")
                   {
                       blnValidate = true;
                       _objFileDt.Rows[0][1] = "Failed";
                       _objFileDt.Rows[0][2] = "Some of required Column are missing in input file(s)";
                   }
               }               
           }
           if (!blnValidate)
               _objFileDt.Rows[0][1] = "Success";
       }
       private void PrepareData()
       {
           string strColumns="";
           string[] arrColumn;
           
           try
           {
               if (_objFileDt.AsEnumerable().Where(row => row.ItemArray.ElementAt(1).ToString() == "Failed").ToList().Count == 0)
               {
                   _objFileDt.Rows[1][1] = "Processing";
                   if (_objWizardData.SelectedFileType == WizardData.FileType.TextFile || _objWizardData.SelectedFileType == WizardData.FileType.CsvFile)
                   {
                       for (int i = 0; i < _objWizardData.SelectedFilePaths.Length; i++)
                       {
                           DataTable objDT = WizardData.getDataTable(_objWizardData.SelectedFilePaths[i],
                                                                               _objWizardData.FileProcessDetails[i, 0],
                                                                             Convert.ToInt16(_objWizardData.FileProcessDetails[i, 1]));
                           //strColumns = string.Empty;
                           for (int j = 0; j < objDT.Columns.Count; j++)
                           {
                               if (_objWizardData.MappingTable.Select("Column='" + objDT.Columns[j].ColumnName + "'").Length == 0)
                                   strColumns = strColumns + objDT.Columns[j].ColumnName + ";";
                           }



                           arrColumn = strColumns.Substring(0, strColumns.Length - 1).Split(';');
                           for (int j = 0; j < arrColumn.Length; j++)
                           {
                               objDT.Columns.Remove(arrColumn[j]);
                           }

                           objDT.AcceptChanges();
                           WizardData.CreateCSV(objDT, WizardData._AppPath + @"\Temp\" + Guid.NewGuid().ToString() + ".txt");
                       }
                       _objFileDt.Rows[1][1] = "Success";
                   }
               }
           }
           catch (Exception e)
           {
               _objFileDt.Rows[1][1] = "Failed";
               _objFileDt.Rows[1][2] = e.Message;
           }
       }
       private void CreateTable()
       {
           if (_objFileDt.AsEnumerable().Where(row => row.ItemArray.ElementAt(1).ToString() == "Failed").ToList().Count == 0)
           {
               _objFileDt.Rows[2][1] = "Processing";
               string strDetailColumn = "(";
               for (int i = 0; i < _objWizardData.MappingTable.Rows.Count; i++)
               {
                   strDetailColumn += "`" + Convert.ToString(_objWizardData.MappingTable.Rows[i][1]).Replace(" ", "") + "` " + _objWizardData.MappingTable.Rows[i][2] + " Null,";
               }
               strDetailColumn = strDetailColumn.Substring(0, strDetailColumn.Length - 1) + ")";
               bool blOutput = _objbzImport.DBTableByProcedure("CREATE", "MRR_100", strDetailColumn);
               _objFileDt.Rows[2][1] = "Success";
           }
       }
       private void Execute()
       {
           if (_objFileDt.AsEnumerable().Where(row => row.ItemArray.ElementAt(1).ToString() == "Failed").ToList().Count == 0)
           {
               _objFileDt.Rows[3][1] = "Processing";
               for (int i = 0; i < Directory.GetFiles(WizardData._AppPath + @"\temp\").Count(); i++)
               {
                   _objbzImport.LoadDataInFile(Directory.GetFiles(WizardData._AppPath + @"\temp\").ElementAt(i), "MRR_100");
               }
               _objFileDt.Rows[3][1] = "Success";
           }
       }
       private void PostExecute()
       {
           if (_objFileDt.AsEnumerable().Where(row => row.ItemArray.ElementAt(1).ToString() == "Failed").ToList().Count == 0)
           {
               _objFileDt.Rows[4][1] = "Processing";
               for (int i = 0; i < Directory.GetFiles(WizardData._AppPath + @"\temp\").Count(); i++)
               {
                   File.Delete(Directory.GetFiles(WizardData._AppPath + @"\temp\").ElementAt(i));
               }
               _objFileDt.Rows[4][1] = "Success";
           }
       }

        public bool DBTableByProcedure(string strOperationType, string strTableName, string strColumns)
        {
            List<Fracton.mxCell.DBLayer.Parameter> _lst = null; ;
            try
            {
                _dbf = new DBFunctions();
                _lst = new List<Fracton.mxCell.DBLayer.Parameter>();
                Fracton.mxCell.DBLayer.Parameter objParameter = new Fracton.mxCell.DBLayer.Parameter();
                objParameter.Name = "Operation";
                objParameter.Value = strOperationType;
                _lst.Add(objParameter);

                objParameter = new Fracton.mxCell.DBLayer.Parameter();
                objParameter.Name = "TName";
                objParameter.Value = strTableName;
                _lst.Add(objParameter);

                objParameter = new Fracton.mxCell.DBLayer.Parameter();
                objParameter.Name = "ColumnList";
                objParameter.Value = strColumns;
                _lst.Add(objParameter);
            }
            catch (Exception ex)
            {
                throw ex;// new CustomException(ex, "bzImport:-DBTableByProcedure");
            }
            return _dbf.ExecuteProcedure("sp_CreateAlterDeletePMObjectsTable", _lst);
        }
        public void CreateIndex(int intTableId, string strTechnology, string strUploadType, string fileName = "")
        {
            DBFunctions dbf = new DBFunctions();
            try
            {
                List<Parameter> _lst = new List<Parameter>();
                Parameter objParameter = new Parameter();
                objParameter.Name = "TName";
                if (strUploadType.ToUpper() == "COUNTERFILE-GSM")
                {
                    objParameter.Value = "PM_" + intTableId;
                    _lst.Add(objParameter);
                    dbf.ExecuteProcedure("sp_CreatePMIndex", _lst);
                }
                else if (strUploadType == "GSM-CNADUMP-cellwise" || strUploadType == "GSM-CNADUMP-bscwise")
                {
                    objParameter.Value = fileName;
                    _lst.Add(objParameter);
                    if (strUploadType == "GSM-CNADUMP-cellwise")
                        dbf.ExecuteProcedure("sp_CreateCNAFilesIndexCellWise", _lst);
                    else
                        dbf.ExecuteProcedure("sp_CreateCNAFilesIndecBSCWise", _lst);
                }
                else
                {
                    objParameter.Value = "DT_" + intTableId;
                    _lst.Add(objParameter);
                    if (strTechnology.ToUpper() == "GSM")
                        dbf.ExecuteProcedure("sp_CreateDriveTestIndex", _lst);
                    else if (strTechnology.ToUpper() == "WCDMA")
                        dbf.ExecuteProcedure("sp_CreateWCDMADriveTestIndex", _lst);
                }

            }
            catch (Exception ex)
            {
                //throw new CustomException(ex, "bzImport:-CreateIndex", "");
            }
            finally
            {
                dbf.Dispose();
                dbf = null;
            }
        }

    }
}
