using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fracton.MaxRAN.DBLayer;
using System.IO;

namespace GenericUploaderDB
{
    public partial class Form1 : Form
    {
        DBFunctions _dbf = null;

        string folderPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbD = new OpenFileDialog();
            if (fbD.ShowDialog() == DialogResult.OK)
            {
                folderPath = fbD.FileName;
                txtFolderPath.Text = fbD.FileName;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try {
                string query = "";
                _dbf = new DBFunctions();
                
                if (!validation())
                    return;
                int count = 0;
                //foreach (string strPath in Directory.GetFiles(txtFolderPath.Text, "*.txt").Select(Path.GetFullPath))
                //{
                string strColumn = "(";
                string strDetailColumn = string.Empty;
                string strNullReplacableQuery = string.Empty;

                string filePath = "";

                    //string strTableName = "queryMRR16jan2018";
                string strTableName = "rxlevel";
                if (count == 0 && true)
                    strTableName = "TCHH";
                else if (count == 1 && true)
                    strTableName = "TCHH";
                else if (count == 2 && true)
                    strTableName = "TCHF";

                //strTableName = Path.GetFileNameWithoutExtension(strPath);   // rw["file_name"].ToString().Trim();
                //filePath = strPath;// +"\\" + rw["file_name"].ToString().Trim() + ".txt";
                //string strPath = txtFolderPath.Text;
                filePath = txtFolderPath.Text;    

                var Column = File.ReadLines(filePath).Skip(0).Take(1).First();

                string[] arrCoulmns = Column.Split('\t');

                for (int k = 0; k < arrCoulmns.Length; k++)
                {
                    if (Convert.ToString(arrCoulmns[k]) == "") continue;
                    strDetailColumn += "`" + Convert.ToString(arrCoulmns[k]) + "`,";
                    strNullReplacableQuery += "`" + Convert.ToString(arrCoulmns[k]) + "` = NULLIF(`" + Convert.ToString(arrCoulmns[k]) + "`,''),";
                    if (arrCoulmns[k].ToString().Contains(":"))
                    {
                        strColumn += "`" + Convert.ToString(arrCoulmns[k].Split(':')[0]).Replace("\"", "") + "` varchar(10) Null,";
                    }
                    else if(arrCoulmns[k].ToString().Contains("Period start time"))
                        strColumn += "`" + Convert.ToString(arrCoulmns[k]).Replace("\"", "") + "` varchar(100) Null,";
                    else if (arrCoulmns[k].ToString().Contains("BCC,NCC"))
                        strColumn += "`BCC` varchar(100) Null,";
                    else
                        strColumn += "`" + Convert.ToString(arrCoulmns[k]).Replace("\"", "") + "` varchar(100) Null,";
                }
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
                query = "LOAD DATA INFILE '" + filePath.Replace(@"\", "/").Replace(@"\\", "/") + "' INTO TABLE " + strTableName + " FIELDS TERMINATED BY  '\t'  OPTIONALLY  ENCLOSED BY '\"' LINES " +
                               "TERMINATED BY '\n'  IGNORE 1 LINES";// (" + strDetailColumn.Replace(" ", "") + ") ;";//+ getAddonStringQuery(_objWizardData.TableID, _objWizardData.UploadedFileType, strNullReplacableQuery, strFileName) + ";";
                _dbf.FireDMLSql(query);
                MessageBox.Show("Conversion Complete");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool validation()
        {
            if (folderPath == "")
            {
                MessageBox.Show("select folder", "Validation");
                return false;
            }
            /*else if(txtSeperator.Text=="")
            {
                MessageBox.Show("Enter seperator","Validation");
                return false;
            }*/

            return true;
        }


        public bool DBTableByProcedure(string strOperationType, string strTableName, string strColumns)
        {
            List<Fracton.MaxRAN.DBLayer.Parameter> _lst = null; ;
            try
            {
                _dbf = new DBFunctions();
                _lst = new List<Fracton.MaxRAN.DBLayer.Parameter>();
                Fracton.MaxRAN.DBLayer.Parameter objParameter = new Fracton.MaxRAN.DBLayer.Parameter();
                objParameter.Name = "Operation";
                objParameter.Value = strOperationType;
                _lst.Add(objParameter);

                objParameter = new Fracton.MaxRAN.DBLayer.Parameter();
                objParameter.Name = "TName";
                objParameter.Value = strTableName;
                _lst.Add(objParameter);

                objParameter = new Fracton.MaxRAN.DBLayer.Parameter();
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
