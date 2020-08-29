using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportData
{
    public partial class ucConnection : UserControl
    {
        WizardData _objWizardData;
        bzImport _objbzImport;
        public DataTable _objFinal;
        public Boolean blnbtnNextEnable = false;
        private ucConnection _objucConnection;
        ucMySQL _objucMySQL;
        ucSQL _objucSQL;
        /*private string _conntype;
        public string conntype
        { get { return this._conntype; } set { this._conntype = value; } }*/
        //public string connstr = "";
        /*readonly string connectionString;

        public ReportConnectionStringManager(string connectionString)
        {
            this.connectionString = connectionString;
        }
        */
        private void frmConnection_Load(object sender, EventArgs e)
        {
            _objucMySQL = new ucMySQL(_objWizardData);
            _objucSQL = new ucSQL(_objWizardData);

            _objucMySQL.Size = pnlConnectionContainer.Size;
            _objucSQL.Size = pnlConnectionContainer.Size;
        }
        public ucConnection(WizardData objWizardData)
        {
            InitializeComponent();
            _objWizardData = objWizardData;
        }

        public ucConnection(ucConnection _objucConnection)
        {
            this._objucConnection = _objucConnection;
        }

        public void Load()
        {
            blnbtnNextEnable = false;
            this.Show();
        }
        private void cbConnectionType_Selected(object sender, EventArgs e)
        {
            
            if (cbConnectionType.SelectedIndex == 1)
            {
                _objWizardData.SelectedConnectionType = WizardData.ConnectionTypes.MySQL;
                pnlConnectionContainer.Controls.Clear();
                _objucMySQL = new ucMySQL(_objWizardData);
                _objucMySQL.Size = pnlConnectionContainer.Size;
                _objucMySQL.Size = pnlConnectionContainer.Size;
                this._objucMySQL.Dock = DockStyle.Fill;
                _objucMySQL.Load();
                pnlConnectionContainer.Controls.Add(_objucMySQL);
               // public string connstr = "dsfshfkuhfu";
            }
            if (cbConnectionType.SelectedIndex == 0)
            {
                _objWizardData.SelectedConnectionType = WizardData.ConnectionTypes.SQL;
                pnlConnectionContainer.Controls.Clear();
                _objucSQL = new ucSQL(_objWizardData);
                _objucSQL.Size = pnlConnectionContainer.Size;
                _objucSQL.Size = pnlConnectionContainer.Size;
                this._objucSQL.Dock = DockStyle.Fill;
                _objucSQL.Load();
                pnlConnectionContainer.Controls.Add(_objucSQL);
                }
                          
        }
    }
}
