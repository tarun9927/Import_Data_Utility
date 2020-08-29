using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using FileHelpers.RunTime;
using FileHelpers;
using System.Windows.Forms;
using System.IO;
namespace ImportData
{
    public class WizardData
    {
        public enum wizardForms
        {
            Source = 1,
            Connection = 2,
            Options = 3,
            Mapping = 4,
            Import = 5,
            Finish = 6,
            Cancel = 99
        }
        public enum FileType
        {
            TextFile = 1,
            CsvFile = 2,
            ExcelFile = 3,
            Excel2007File = 4,
            XmlFile = 5
        }
        public enum ConnectionTypes
        {
            NULL= 0,
            SQL = 1,
            MySQL = 2
        }
        public enum ConnectionForms
        {
            SQLForm = 1,
            MySQLForm = 2
        }
        public enum SelectedDB
        {
            NULL = 0
        }
        public enum Separator
        {
            tab = 0,
            space = 1,
            custom = 2
        }
        public enum SelectTable
        {
            Existing = 0,
            New = 1
        }
        //public enum 
        public static string _AppPath = Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location).FullName + "\\";
        public wizardForms FormToShow { get; set; }
        public FileType SelectedFileType { get; set; }
        //public ConnectionTypes SelectedConnectionType { get; set; }
        public SelectedDB selectedDataBase { get; set; }
        public ConnectionTypes SelectedConnectionType { get; set; }
        public Separator SelectedSeparator { get; set; }
        public ConnectionForms FormToShow1 { get; set; }
        public SelectTable SelectedTableType { get; set; }
        public string[] SelectedColumnNames { get; set; }
        public string[] SelectedFilePaths { get; set; }
        public string tablename { get; set; }
        public string addr { get; set; }
        public string[] SelectedHeaders { get; set; }
        public string[] SelectedColumnTypes { get; set; }
        public string[,] FileProcessDetails { get; set; }
        public IList<WorkBook> WorkbookList { get; set; }
        public DataTable MappingTable { get; set; }
        

        private static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public static DataTable getDataTable(string strFilePath, string strSpliter, int intRowHeader)
        {
            DataTable dt = new DataTable();
            try
            {
                DelimitedClassBuilder cb = new DelimitedClassBuilder("Data", strSpliter);
                cb.IgnoreFirstLines = intRowHeader;
                cb.IgnoreEmptyLines = true;
                string currentlinetext = File.ReadLines(strFilePath).Skip(intRowHeader - 1).Take(1).First(); ;

                string[] arrCoulmn = currentlinetext.Split(Convert.ToChar(strSpliter));
                for (int i = 0; i < arrCoulmn.Length; i++)
                {
                    if (RemoveSpecialCharacters(arrCoulmn[i]).Replace(' ', '_').Trim() != "")
                        cb.AddField(RemoveSpecialCharacters(arrCoulmn[i]).Replace(' ', '_').Trim(), typeof(string));
                }
                FileHelperEngine engine = new FileHelperEngine(cb.CreateRecordClass());
                dt = engine.ReadFileAsDT(strFilePath);            

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dt.Columns[j].ColumnName = arrCoulmn[j];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public static void CreateCSV(DataTable objDT, string FilePath)
        {
            var lines = new List<string>();
            string[] columnNames = objDT.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).ToArray();
            var header = string.Join(",", columnNames);
            lines.Add(header);
            var valueLines = objDT.AsEnumerable().Select(row => (string.Join(";", row.ItemArray.Select(c => (c.ToString().Trim() == "" || c.ToString().Trim() == "  " ? @"\N" : c)))).Replace("\r", ""));
            lines.AddRange(valueLines);
            File.WriteAllLines(FilePath, lines);
        }
    }
    public class WorkBook
    {
        public string WorkbookName { get; set; }
        public string WorkSheetName { get; set; }
        public string CellStartRange { get; set; }
        public string CellEndRange { get; set; }
        public Boolean AutoDetect { get; set; }
        public Boolean AutoDetectRange { get; set; }
        public int RowHeader { get; set; }        
    }

     
}
