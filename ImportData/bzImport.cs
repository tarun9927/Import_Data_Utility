using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fracton.mxCell.DBLayer;
using Fracton.mxCell.ExceptionHandler;
using System.IO;
using System.Windows.Forms;

namespace ImportData
{
    class bzImport
    {
        DBFunctions _dbf;
        /*public DataTable getFileDetails(int Vendor, string FileType)
        {
            _dbf = new DBFunctions();
            DataTable objzDT;
            try
            {
                _dbf = new DBFunctions();
                string sql = @"SELECT fd.ID,`Column`,`ColumnType` FROM `ms_filedetails` FD INNER JOIN `ms_filetype` FT 
                                ON FT.`ID` = FD.`FileTypeID` 
                                WHERE FT.`VendorID` = " + Vendor +
                                @" AND `FileType` = '" + FileType + "';";
                objzDT = _dbf.FireSelectSql(sql);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(err+ "");
                throw new CustomException(ex, "getFileDetails");
            }
            finally
            {
                _dbf.Dispose();
            }
            return objzDT;
        }*/
        /*public DataTable getImportAction()
        {
            _dbf = new DBFunctions();
            DataTable objzDT;
            try
            {
                _dbf = new DBFunctions();
                string sql = @"SELECT step AS `Action`, '' AS `Status`, '' Message FROM `ms_importstep` ORDER BY id  ;";
                objzDT = _dbf.FireSelectSql(sql);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex, "getImportAction");
            }
            finally
            {
                _dbf.Dispose();
            }
            return objzDT;
        }*/
        public bool DBTableByProcedure(string strOperationType, string strTableName, string strColumns)
        {
            _dbf = new DBFunctions();
            List<Fracton.mxCell.DBLayer.Parameter> _lst = new List<Fracton.mxCell.DBLayer.Parameter>();
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
            return _dbf.ExecuteProcedure("sp_CreateAlterDeletePMObjectsTable", _lst);
        }
        internal void LoadDataInFile(string strFilePath, string strTableName)
        {
            _dbf = new DBFunctions();
            var Column = File.ReadLines(strFilePath).Skip(0).Take(1).First();
            string query = "LOAD DATA INFILE '" + strFilePath.Replace(@"\", "/") + "' INTO TABLE " + strTableName + " FIELDS TERMINATED BY ';' LINES " +
                           "TERMINATED BY '\r\n' IGNORE 1 LINES (`" + Column.Replace(",","`,`").Replace(" ", "").Replace("  ","") + "`);";
            _dbf.FireDMLSql(query);
        }
    }
}