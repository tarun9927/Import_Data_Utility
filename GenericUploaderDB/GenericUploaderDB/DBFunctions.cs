using System;
using System.Configuration;
using System.Data;
using System.Xml;
//using Fracton.MaxRAN.ExceptionHandler;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Fracton.MaxRAN.DBLayer
{
    public class DBFunctions
    {
        private readonly MySqlConnection _myConnection;
        private readonly MySqlTransaction _trans;
        private bool _exceptionOccurred;

        public static string port
        {
            get
            {
                return "3306";
            }
        }
        public static string password
        {
            get
            {
                return "toor123";
            }
        }

        public DBFunctions(Boolean blnTransactionRequire = false, string strDataBase = "import_data_utility")
        {
            try
            {
                _myConnection = new MySqlConnection("Database=" + strDataBase + ";Data Source=localhost;User Id=root;Password=" + password + ";pooling=false;port=" + port + "; Allow User Variables = true;");
                if (_myConnection.State == ConnectionState.Open)
                    _myConnection.Close();
                _myConnection.Open();
                if (blnTransactionRequire)
                    _trans = _myConnection.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose(Boolean blnTransactionRequire = false, Boolean exceptionOccurred = false)
        {
            if (blnTransactionRequire)
            {
                _exceptionOccurred = exceptionOccurred;
                if (_trans != null && _exceptionOccurred && _myConnection.State == ConnectionState.Open)
                    _trans.Rollback();
                else if (_trans != null && !_exceptionOccurred && _myConnection.State == ConnectionState.Open)
                    _trans.Commit();
            }

            if (_myConnection.State == ConnectionState.Open)
                _myConnection.Close();
            _myConnection.Dispose();
        }

        public XmlDataDocument GetXML(string sql)
        {
            try
            {
                //-----check the sql query
                string csql = sql.Trim();
                string[] brokensql = csql.Split(' ');
                if (brokensql[0].ToLower() != "select")
                    throw new ArgumentException("Invalid SQL Statement! Select Statements must start with SELECT.", sql);
                //----check complete
                var mydt = new DataSet();
                var myDataAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = new MySqlCommand("set sql_big_selects =1; " + sql, _myConnection)
                    };
                myDataAdapter.Fill(mydt);
                mydt.EnforceConstraints = false;
                return new XmlDataDocument(mydt);
            }
            catch (Exception ex)
            {
                _exceptionOccurred = true;
                throw ex;// new CustomException(ex, sql);
            }
        }

        public int FireDMLSql(string sql)
        {
            try
            {
                //-----check the sql query
                string csql = sql.Trim();
                string[] brokensql = csql.Split(' ');
                if (brokensql[0].ToLower() != "insert"
                    && brokensql[0].ToLower() != "update"
                    && brokensql[0].ToLower() != "delete"
                    && brokensql[0].ToLower() != "load"
                    && brokensql[0].ToLower() != "drop"
                    && brokensql[0].ToLower() != "alter" && brokensql[0].ToLower() != "truncate"
                    && brokensql[0].ToLower() != "use")
                    throw new ArgumentException(
                        "Invalid SQL Statement! DML Statements must start with INSERT, UPDATE or DELETE.", sql);
                //----check complete

                int result;
                using (var myCommand = new MySqlCommand(sql, _myConnection))
                {
                    myCommand.CommandTimeout = int.MaxValue;
                    result = myCommand.ExecuteNonQuery();
                    myCommand.Dispose();
                }
                return result;
            }
            catch (Exception ex)
            {
                // _exceptionOccurred = true;
                // throw new CustomException(ex, sql);
                throw ex;
            }
        }

        /*
                public string FireScalarDecrypt(string sql)
                {
                    try
                    {
                        //-----check the sql query
                        string csql = sql.Trim();
                        string[] brokensql = csql.Split(' ');
                        if (brokensql[0].ToLower() != "select")
                            throw new ArgumentException("Invalid SQL Statement! Statement must start with SELECT.", sql);
                        //----check complete
                        byte[] b;
                        using (var myCommand = new MySqlCommand(sql, _myConnection))
                        {
                            b = (byte[])myCommand.ExecuteScalar();
                            myCommand.Dispose();
                        }
                        return System.Text.UnicodeEncoding.UTF8.GetString(b);
                    }
                    catch (Exception ex)
                    {
                        _exceptionOccurred = true;
                        throw new CustomException(ex, sql);
                    }
                }
        */

        public string FireScalarQuery(string sql)
        {
            try
            {
                //-----check the sql query
                string csql = sql.Trim();
                string[] brokensql = csql.Split(' ');
                if (brokensql[0].ToLower() != "select" && brokensql[0].ToLower() != "use")
                    throw new ArgumentException("Invalid SQL Statement! Statement must start with SELECT.", sql);
                //----check complete

                string result;
                using (var myCommand = new MySqlCommand(sql, _myConnection))
                {
                    result = Convert.ToString(myCommand.ExecuteScalar());
                    myCommand.Dispose();
                }
                return result;
            }
            catch (Exception ex)
            {
                _exceptionOccurred = true;
                throw ex;// new CustomException(ex, sql);
            }
        }

        public DataTable FireSelectSql(string sql)
        {
            try
            {
                //-----check the sql query
                string csql = sql.Trim();
                string[] brokensql = csql.Split(' ');
                if (brokensql[0].ToLower() != "select" && brokensql[0].ToLower() != "use")
                {
                    if (brokensql[0].ToLower() != "set")
                        throw new ArgumentException("Invalid SQL Statement! Select Statements must start with SELECT.", sql);
                }
                //----check complete
                var mydt = new DataTable();
                using (var myDataAdapter = new MySqlDataAdapter())
                {
                    myDataAdapter.SelectCommand = new MySqlCommand("set sql_big_selects =1; " + sql, _myConnection);
                    myDataAdapter.SelectCommand.CommandTimeout = Int32.MaxValue;
                    myDataAdapter.Fill(mydt);
                    myDataAdapter.Dispose();
                }
                return mydt;
            }
            catch (Exception ex)
            {
                _exceptionOccurred = true;
                throw ex;// new CustomException(ex, sql);
            }
        }

        public DataSet MultiSelectSql(string sql)
        {
            try
            {
                //-----check the sql query
                string csql = sql.Trim();
                string[] brokensql = csql.Split(' ');
                if (brokensql[0].ToLower() != "select" && brokensql[0].ToLower() != "use")
                    throw new ArgumentException("Invalid SQL Statement! Select Statements must start with SELECT.", sql);
                //----check complete
                var myds = new DataSet();
                using (var myDataAdapter = new MySqlDataAdapter())
                {
                    myDataAdapter.SelectCommand = new MySqlCommand("set sql_big_selects =1; " + sql, _myConnection);
                    myDataAdapter.SelectCommand.CommandTimeout = Int32.MaxValue;
                    myDataAdapter.Fill(myds);
                    myDataAdapter.Dispose();
                }
                return myds;
            }
            catch (Exception ex)
            {
                _exceptionOccurred = true;
                throw ex;// new CustomException(ex, sql);
            }
        }

        public bool ExecuteProcedure(string strProcName, List<Parameter> lstParameter)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(strProcName, _myConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = int.MaxValue;
                for (int i = 0; i < lstParameter.Count; i++)
                {
                    cmd.Parameters.Add(new MySqlParameter(lstParameter[i].Name, lstParameter[i].Value));
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                _exceptionOccurred = true;
                throw ex;// new CustomException(ex, strProcName);
            }
        }
    }
}
