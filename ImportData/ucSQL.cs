using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Configuration;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace ImportData
{
    public partial class ucSQL : UserControl
    {
        WizardData _objWizardData;
        bzImport _objbzImport;
        public DataTable _objFinal;
        public Boolean blnbtnNextEnable = false;
        private ucMySQL _objucSQL;

        public ucSQL(WizardData objWizardData)
        {
            InitializeComponent();
            _objWizardData = objWizardData;
        }

        public ucSQL(ucMySQL _objucSQL)
        {
            this._objucSQL = _objucSQL;
        }

        public void Load()
        {
            blnbtnNextEnable = false;
            this.Show();
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
        private void btnTestConnection_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Data Source=TARUN\SQLEXPRESS,3306;Integrated Security=False;User ID=root;Password=[Password]
                StringBuilder a = new StringBuilder("Data Source = ");
                a.Append(txtbxServerName.Text);
                //a.Append(",");
                //a.Append(txtbxPortNumber.Text);
                a.Append(";Integrated Security=");
                a.Append(txtbxAuthentication.Text);
                a.Append(";User ID=");
                a.Append(txtbxUserID.Text);
                a.Append(";Password=");
                a.Append(txtbxPassword.Text);
                a.Append(";Pooling=False");
                // a.Append(txtbxSSLMode.Text);
                a.Append(";");
                string strCon = a.ToString();
                updateConfigFile(strCon);
                //create mysql connection
                SqlConnection konek = new SqlConnection();
                //for refreshing connection string whenever it will use the previous connection string
                ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    lblSqlDisp.Text = "Connection is Active.";
                    konek.Close();
                }
                else
                {
                    lblSqlDisp.Text = "Connection is not Active";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(ConfigurationManager.ConnectionStrings["con"].ToString() + " .This is invalid connection”,”INCORRECT SERVER / DATABASE" + err);
            }
        }

    }
}
