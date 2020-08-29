namespace ImportData
{
    partial class ucExcelFileOption
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucExcelFileOption));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartRow = new System.Windows.Forms.Button();
            this.txtStartRowIndex = new System.Windows.Forms.TextBox();
            this.rbPosition = new System.Windows.Forms.RadioButton();
            this.rbFirstRow = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.grbSplit = new System.Windows.Forms.GroupBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkRange = new System.Windows.Forms.CheckBox();
            this.txtEndCell = new System.Windows.Forms.TextBox();
            this.txtStartCell = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSheets = new System.Windows.Forms.TabControl();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.tbBooks = new System.Windows.Forms.TabControl();
            this.chkAutoMode = new System.Windows.Forms.CheckBox();
            this.cmbSheets = new ImportData.CheckedComboBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbSplit.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btnStartRow);
            this.groupBox1.Controls.Add(this.txtStartRowIndex);
            this.groupBox1.Controls.Add(this.rbPosition);
            this.groupBox1.Controls.Add(this.rbFirstRow);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(338, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 132);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnStartRow
            // 
            this.btnStartRow.Image = ((System.Drawing.Image)(resources.GetObject("btnStartRow.Image")));
            this.btnStartRow.Location = new System.Drawing.Point(248, 80);
            this.btnStartRow.Name = "btnStartRow";
            this.btnStartRow.Size = new System.Drawing.Size(30, 23);
            this.btnStartRow.TabIndex = 9;
            this.btnStartRow.UseVisualStyleBackColor = true;
            this.btnStartRow.Click += new System.EventHandler(this.btnStartRow_Click);
            // 
            // txtStartRowIndex
            // 
            this.txtStartRowIndex.Location = new System.Drawing.Point(36, 82);
            this.txtStartRowIndex.Name = "txtStartRowIndex";
            this.txtStartRowIndex.Size = new System.Drawing.Size(206, 20);
            this.txtStartRowIndex.TabIndex = 6;
            // 
            // rbPosition
            // 
            this.rbPosition.AutoSize = true;
            this.rbPosition.Location = new System.Drawing.Point(19, 59);
            this.rbPosition.Name = "rbPosition";
            this.rbPosition.Size = new System.Drawing.Size(62, 17);
            this.rbPosition.TabIndex = 3;
            this.rbPosition.TabStop = true;
            this.rbPosition.Text = "Position";
            this.rbPosition.UseVisualStyleBackColor = true;
            // 
            // rbFirstRow
            // 
            this.rbFirstRow.AutoSize = true;
            this.rbFirstRow.Checked = true;
            this.rbFirstRow.Location = new System.Drawing.Point(19, 34);
            this.rbFirstRow.Name = "rbFirstRow";
            this.rbFirstRow.Size = new System.Drawing.Size(114, 17);
            this.rbFirstRow.TabIndex = 2;
            this.rbFirstRow.TabStop = true;
            this.rbFirstRow.Text = "First row in a range";
            this.rbFirstRow.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 23);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Header";
            // 
            // grbSplit
            // 
            this.grbSplit.Controls.Add(this.cmbSheets);
            this.grbSplit.Controls.Add(this.btnEnd);
            this.grbSplit.Controls.Add(this.btnStart);
            this.grbSplit.Controls.Add(this.chkRange);
            this.grbSplit.Controls.Add(this.txtEndCell);
            this.grbSplit.Controls.Add(this.txtStartCell);
            this.grbSplit.Controls.Add(this.label5);
            this.grbSplit.Controls.Add(this.label4);
            this.grbSplit.Controls.Add(this.label3);
            this.grbSplit.Controls.Add(this.panel1);
            this.grbSplit.Location = new System.Drawing.Point(9, -4);
            this.grbSplit.Name = "grbSplit";
            this.grbSplit.Size = new System.Drawing.Size(325, 132);
            this.grbSplit.TabIndex = 3;
            this.grbSplit.TabStop = false;
            // 
            // btnEnd
            // 
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(290, 83);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(30, 23);
            this.btnEnd.TabIndex = 9;
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(289, 58);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(30, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkRange
            // 
            this.chkRange.AutoSize = true;
            this.chkRange.Checked = true;
            this.chkRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRange.Location = new System.Drawing.Point(62, 109);
            this.chkRange.Name = "chkRange";
            this.chkRange.Size = new System.Drawing.Size(161, 17);
            this.chkRange.TabIndex = 7;
            this.chkRange.Text = "Detect a range automatically";
            this.chkRange.UseVisualStyleBackColor = true;
            this.chkRange.CheckedChanged += new System.EventHandler(this.chkRange_CheckedChanged);
            // 
            // txtEndCell
            // 
            this.txtEndCell.Location = new System.Drawing.Point(62, 85);
            this.txtEndCell.Name = "txtEndCell";
            this.txtEndCell.Size = new System.Drawing.Size(222, 20);
            this.txtEndCell.TabIndex = 6;
            // 
            // txtStartCell
            // 
            this.txtStartCell.Location = new System.Drawing.Point(62, 60);
            this.txtStartCell.Name = "txtStartCell";
            this.txtStartCell.Size = new System.Drawing.Size(222, 20);
            this.txtStartCell.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "End Cell:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Start Cell:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sheet:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 23);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Location";
            // 
            // tbSheets
            // 
            this.tbSheets.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbSheets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSheets.Location = new System.Drawing.Point(9, 435);
            this.tbSheets.Name = "tbSheets";
            this.tbSheets.SelectedIndex = 0;
            this.tbSheets.Size = new System.Drawing.Size(750, 20);
            this.tbSheets.TabIndex = 9;
            this.tbSheets.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbSheets_Selected);
            this.tbSheets.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tbSheets_Deselected);
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.GridColor = System.Drawing.SystemColors.Control;
            this.grdData.Location = new System.Drawing.Point(9, 149);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdData.Size = new System.Drawing.Size(748, 281);
            this.grdData.TabIndex = 10;
            this.grdData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdData_CellMouseDoubleClick);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(766, 485);
            this.shapeContainer1.TabIndex = 8;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 9;
            this.lineShape2.X2 = 759;
            this.lineShape2.Y1 = 478;
            this.lineShape2.Y2 = 478;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 9;
            this.lineShape1.X2 = 759;
            this.lineShape1.Y1 = 455;
            this.lineShape1.Y2 = 455;
            // 
            // tbBooks
            // 
            this.tbBooks.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBooks.Location = new System.Drawing.Point(8, 458);
            this.tbBooks.Name = "tbBooks";
            this.tbBooks.SelectedIndex = 0;
            this.tbBooks.Size = new System.Drawing.Size(750, 20);
            this.tbBooks.TabIndex = 11;
            this.tbBooks.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbBooks_Selected);
            // 
            // chkAutoMode
            // 
            this.chkAutoMode.AutoSize = true;
            this.chkAutoMode.Checked = true;
            this.chkAutoMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoMode.Location = new System.Drawing.Point(9, 130);
            this.chkAutoMode.Name = "chkAutoMode";
            this.chkAutoMode.Size = new System.Drawing.Size(357, 17);
            this.chkAutoMode.TabIndex = 12;
            this.chkAutoMode.Text = "Detect row header and range automatically for all selected worksheets";
            this.chkAutoMode.UseVisualStyleBackColor = true;
            this.chkAutoMode.CheckedChanged += new System.EventHandler(this.chkAutoMode_CheckedChanged);
            // 
            // cmbSheets
            // 
            this.cmbSheets.CheckOnClick = true;
            this.cmbSheets.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSheets.DropDownHeight = 1;
            this.cmbSheets.FormattingEnabled = true;
            this.cmbSheets.IntegralHeight = false;
            this.cmbSheets.Location = new System.Drawing.Point(62, 34);
            this.cmbSheets.Name = "cmbSheets";
            this.cmbSheets.Size = new System.Drawing.Size(257, 21);
            this.cmbSheets.TabIndex = 10;
            this.cmbSheets.ValueSeparator = ", ";
            this.cmbSheets.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cmbSheets_ItemCheck);
            // 
            // ucExcelFileOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.chkAutoMode);
            this.Controls.Add(this.tbBooks);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.tbSheets);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbSplit);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "ucExcelFileOption";
            this.Size = new System.Drawing.Size(766, 485);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbSplit.ResumeLayout(false);
            this.grbSplit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbSplit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRange;
        private System.Windows.Forms.TextBox txtEndCell;
        private System.Windows.Forms.TextBox txtStartCell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartRowIndex;
        private System.Windows.Forms.RadioButton rbPosition;
        private System.Windows.Forms.RadioButton rbFirstRow;
        private System.Windows.Forms.Button btnStartRow;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private CheckedComboBox cmbSheets;
        private System.Windows.Forms.TabControl tbSheets;
        private System.Windows.Forms.DataGridView grdData;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TabControl tbBooks;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.CheckBox chkAutoMode;
    }
}
