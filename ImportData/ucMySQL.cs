using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Xml;


namespace ImportData
{
    public partial class ucMySQL : UserControl
    {
        WizardData _objWizardData;
        bzImport _objbzImport;
        public DataTable _objFinal;
        public Boolean blnbtnNextEnable = false;
        private ucMySQL _objucMySQL;
        
        public ucMySQL(WizardData objWizardData)
        {
            InitializeComponent();
            _objWizardData = objWizardData;
        }

        public ucMySQL(ucMySQL _objucMySQL)
        {
            this._objucMySQL = _objucMySQL;
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

        private void btnTestConnectionMySQL_Click(object sender, EventArgs ex)
        {
            //MessageBox.Show(ds);
            //Database = import_data_utility; Data Source = localhost; User Id = root; Password = toor123; pooling = false; port = 3306; Allow User Variables = true; SslMode = none
            try
            {
                StringBuilder a = new StringBuilder("Data Source = ");
                a.Append(txtbxServerName.Text);
                a.Append("; User ID = ");
                a.Append(txtbxUserID.Text);
                a.Append("; Password = ");
                a.Append(txtbxPassword.Text);
                a.Append("; pooling = false");
                a.Append("; port = ");
                a.Append(txtbxPortNumber.Text);
                a.Append("; Allow User Variables = true");
                a.Append("; SslMode = ");
                a.Append(txtbxSSLMode.Text);
                a.Append(";");
                string strCon = a.ToString();
                updateConfigFile(strCon);
                //create mysql connection
                MySqlConnection konek = new MySqlConnection();
                //for refreshing connection string whenever it will use the previous connection string
                ConfigurationManager.RefreshSection("connectionStrings");
                konek.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                konek.Open();
                if (konek.State == ConnectionState.Open)
                {
                    lblMySqlDisp.Text = "Connection is Active.";
                    konek.Close();
                }
                else
                {
                    lblMySqlDisp.Text = "Connection is not Active.";
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(ConfigurationManager.ConnectionStrings["con"].ToString() + " .This is invalid connection”,”INCORRECT SERVER / DATABASE" +err);
            }
            //_myConnection.Open();

        }
    }
}
