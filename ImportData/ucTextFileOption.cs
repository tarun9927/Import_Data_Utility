using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using FileHelpers.RunTime;
using FileHelpers;

namespace ImportData
{
    public partial class ucTextFileOption : UserControl
    {
        WizardData _objWizardData;
        private BackgroundWorker backgroundWorker1;
        int firstcharindex = 0;
        string currentlinetext = string.Empty;

        public ucTextFileOption(WizardData objWizardData)
        {
            InitializeComponent();
            _objWizardData = objWizardData;           
        }       
        public void Load()
        {
            try
            {
                this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                rtxtData.WordWrap = false;
                numericUpDown1.Enabled = false;
                tbSheets.TabPages.Clear();
                _objWizardData.FileProcessDetails = new string[_objWizardData.SelectedFilePaths.Length,2];
                for (int i = 0; i < _objWizardData.SelectedFilePaths.Length; i++)
                {
                    tbSheets.TabPages.Add(Path.GetFileName(_objWizardData.SelectedFilePaths[i]));
                    _objWizardData.FileProcessDetails[i,0] = "\t";
                    _objWizardData.FileProcessDetails[i,1] = "1";
                }
                this.backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private char getSpiliter()
        {
            if (rdTab.Checked == true)
            {
                _objWizardData.SelectedSeparator = WizardData.Separator.tab;
                return '\t';
            }
            else if (rdSpace.Checked == true)
            {
                _objWizardData.SelectedSeparator = WizardData.Separator.space;
                return ' ';
            }
            else
            {
                _objWizardData.SelectedSeparator = WizardData.Separator.custom;
                return Convert.ToChar(textBox1.Text);
            }
        }
       

        private void backgroundWorker1_RunWorkerCompleted(object sender,RunWorkerCompletedEventArgs e)
        {
            int intLineCount = 0;
            string filename = _objWizardData.SelectedFilePaths[tbSheets.SelectedIndex];
            rtxtData.Text = "";
            foreach (string line in File.ReadLines(filename))
            {
                intLineCount++;                
                string text = line;
                rtxtData.AppendText(text + "\n");
            }
            dataGridView1.Visible = false;
            rtxtData.Visible = true;


            if (_objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1] == "0" || _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1] == "1")
            {
                firstcharindex = rtxtData.GetFirstCharIndexFromLine(0);
                currentlinetext = rtxtData.Lines[0];
                rtxtData.SelectionBackColor = System.Drawing.Color.LightGray;
                rtxtData.Select(firstcharindex, currentlinetext.Length);
                firstcharindex = rtxtData.GetFirstCharIndexFromLine(1);
                currentlinetext = rtxtData.Lines[1];
                rtxtData.SelectionBackColor = System.Drawing.Color.LightGray;
                rtxtData.Select(firstcharindex, currentlinetext.Length);
            }
            else
            {
                for (int i = 0; i < Convert.ToInt16(_objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1]) - 1; i++)
                {
                    firstcharindex = rtxtData.GetFirstCharIndexFromLine(i);
                    currentlinetext = rtxtData.Lines[i];
                    rtxtData.SelectionBackColor = System.Drawing.Color.LightCyan;
                    rtxtData.Select(firstcharindex, currentlinetext.Length);
                    firstcharindex = rtxtData.GetFirstCharIndexFromLine(i + 1);
                    currentlinetext = rtxtData.Lines[i + 1];
                    rtxtData.SelectionBackColor = System.Drawing.Color.LightCyan;
                    rtxtData.Select(firstcharindex, currentlinetext.Length);
                }
                //For Header
                firstcharindex = rtxtData.GetFirstCharIndexFromLine(Convert.ToInt16(_objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1]));
                currentlinetext = rtxtData.Lines[Convert.ToInt16(Convert.ToInt16(_objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1]))];
                rtxtData.SelectionBackColor = System.Drawing.Color.LightGray;
                rtxtData.Select(firstcharindex, currentlinetext.Length);
            }
           
        }        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {            
            numericUpDown2.Value = numericUpDown1.Value + 1;

            if (numericUpDown1.Value == 0)
                numericUpDown2.Value = 0;

            if (Convert.ToInt16(((UpDownBase)sender).Text) < Convert.ToInt16(numericUpDown1.Value))
            {
                //For Skip Line
                firstcharindex = rtxtData.GetFirstCharIndexFromLine(Convert.ToInt16(((UpDownBase)sender).Text));
                currentlinetext = rtxtData.Lines[Convert.ToInt16(((UpDownBase)sender).Text)];
                rtxtData.SelectionBackColor = System.Drawing.Color.LightCyan;
                rtxtData.Select(firstcharindex, currentlinetext.Length);
                firstcharindex = rtxtData.GetFirstCharIndexFromLine(Convert.ToInt16(((UpDownBase)sender).Text) + 1);
                currentlinetext = rtxtData.Lines[Convert.ToInt16(((UpDownBase)sender).Text) + 1];
                rtxtData.SelectionBackColor = System.Drawing.Color.LightCyan;
                rtxtData.Select(firstcharindex, currentlinetext.Length);

                //For Header
                firstcharindex = rtxtData.GetFirstCharIndexFromLine(Convert.ToInt16(((UpDownBase)sender).Text)+2);
                currentlinetext = rtxtData.Lines[Convert.ToInt16(((UpDownBase)sender).Text)+2];
                rtxtData.SelectionBackColor = System.Drawing.Color.LightGray;
                rtxtData.Select(firstcharindex, currentlinetext.Length);                
            }
            else
            {
                //For Skip Line
                firstcharindex = rtxtData.GetFirstCharIndexFromLine(Convert.ToInt16(numericUpDown1.Value));
                currentlinetext = rtxtData.Lines[Convert.ToInt16(numericUpDown1.Value)];
                rtxtData.SelectionBackColor = System.Drawing.Color.White;
                rtxtData.Select(firstcharindex, currentlinetext.Length);

                firstcharindex = rtxtData.GetFirstCharIndexFromLine(Convert.ToInt16(numericUpDown1.Value)+1);
                currentlinetext = rtxtData.Lines[Convert.ToInt16(numericUpDown1.Value)+1];
                rtxtData.SelectionBackColor = System.Drawing.Color.White;
                rtxtData.Select(firstcharindex, currentlinetext.Length);
                
                if (numericUpDown1.Value > 0)
                {
                    firstcharindex = rtxtData.GetFirstCharIndexFromLine(Convert.ToInt16(numericUpDown1.Value) - 1);
                    currentlinetext = rtxtData.Lines[Convert.ToInt16(numericUpDown1.Value) - 1];
                    rtxtData.SelectionBackColor = System.Drawing.Color.White;
                    rtxtData.Select(firstcharindex, currentlinetext.Length);

                    firstcharindex = rtxtData.GetFirstCharIndexFromLine(Convert.ToInt16(numericUpDown1.Value) - 1);
                    currentlinetext = rtxtData.Lines[Convert.ToInt16(numericUpDown1.Value) - 1];
                    rtxtData.SelectionBackColor = System.Drawing.Color.LightGray;
                    rtxtData.Select(firstcharindex, currentlinetext.Length);
                }
            }

            if (rbHeader.Checked == true)
                _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1] = "1";
            else if (rbCustomHeader.Checked == true)
                _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1] = numericUpDown2.Value.ToString();
           
        }
        private void rbCutom_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
        }       
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (getSpiliter().ToString() == "")
            {
                MessageBox.Show("Please select Column Spiliter.", "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (btnPreview.Text == "Preview")
            {
                dataGridView1.DataSource = WizardData.getDataTable(_objWizardData.SelectedFilePaths[tbSheets.SelectedIndex], 
                                                                        _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 0], 
                                                                        Convert.ToInt16(_objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1]));
                dataGridView1.Visible = true;
                rtxtData.Visible = false;
                btnPreview.Text = "Back";               
            }
            else
            {
                dataGridView1.Visible = false;
                rtxtData.Visible = true;
                btnPreview.Text = "Preview";
            }
            if (rbHeader.Checked == true)
                _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1] = "1";
            else if (rbCustomHeader.Checked == true)
                _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1] = numericUpDown2.Value.ToString();
        }       
        private void tbSheets_Selected(object sender, TabControlEventArgs e)
        {
            if (tbSheets.TabPages.Count > 0)
            {
                btnPreview.Text = "Preview";
                this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                this.backgroundWorker1.RunWorkerAsync();

                if (_objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 0] == "\t")
                    rdTab.Checked = true;
                else if (_objWizardData.FileProcessDetails[tbSheets.SelectedIndex,0] == " ")
                    rdSpace.Checked = true;
                else
                {
                    rdCustom.Checked = true;
                    textBox1.Text = _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 0];
                }

                if(_objWizardData.FileProcessDetails[tbSheets.SelectedIndex,1] =="0" || _objWizardData.FileProcessDetails[tbSheets.SelectedIndex,1] =="1")
                    rbHeader.Checked=true;
                else
                {
                    rbCustomHeader.Checked=true;
                    numericUpDown1.Value = Convert.ToInt16( _objWizardData.FileProcessDetails[tbSheets.SelectedIndex,1])-1;
                    numericUpDown2.Value = Convert.ToInt16( _objWizardData.FileProcessDetails[tbSheets.SelectedIndex,1]);                     
                }

                if (rbHeader.Checked == true)
                    _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1] = "1";
                else if (rbCustomHeader.Checked == true)
                    _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 1] = numericUpDown2.Value.ToString();

                _objWizardData.FileProcessDetails[tbSheets.SelectedIndex, 0] = getSpiliter().ToString();

               
            }
        }
    }
}
