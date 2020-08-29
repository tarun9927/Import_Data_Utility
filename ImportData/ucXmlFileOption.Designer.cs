namespace ImportData
{
    partial class ucXmlFileOption
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
            this.grdData = new System.Windows.Forms.DataGridView();
            this.rtxtData = new System.Windows.Forms.RichTextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.tbSheets = new System.Windows.Forms.TabControl();
            this.cmbSheets = new ImportData.CheckedComboBox();
            this.tbBooks = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Location = new System.Drawing.Point(11, 41);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(474, 152);
            this.grdData.TabIndex = 0;
            // 
            // rtxtData
            // 
            this.rtxtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtData.Location = new System.Drawing.Point(11, 41);
            this.rtxtData.Name = "rtxtData";
            this.rtxtData.Size = new System.Drawing.Size(474, 174);
            this.rtxtData.TabIndex = 2;
            this.rtxtData.Text = "";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnPreview.Location = new System.Drawing.Point(214, 10);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 24);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 11;
            this.lineShape1.X2 = 483;
            this.lineShape1.Y1 = 214;
            this.lineShape1.Y2 = 214;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(496, 247);
            this.shapeContainer1.TabIndex = 12;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 11;
            this.lineShape2.X2 = 483;
            this.lineShape2.Y1 = 237;
            this.lineShape2.Y2 = 237;
            // 
            // tbSheets
            // 
            this.tbSheets.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbSheets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSheets.Location = new System.Drawing.Point(12, 195);
            this.tbSheets.Name = "tbSheets";
            this.tbSheets.SelectedIndex = 0;
            this.tbSheets.Size = new System.Drawing.Size(473, 19);
            this.tbSheets.TabIndex = 13;
            this.tbSheets.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbSheets_Selected);
            // 
            // cmbSheets
            // 
            this.cmbSheets.CheckOnClick = true;
            this.cmbSheets.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSheets.DropDownHeight = 1;
            this.cmbSheets.FormattingEnabled = true;
            this.cmbSheets.IntegralHeight = false;
            this.cmbSheets.Location = new System.Drawing.Point(11, 12);
            this.cmbSheets.Name = "cmbSheets";
            this.cmbSheets.Size = new System.Drawing.Size(197, 21);
            this.cmbSheets.TabIndex = 11;
            this.cmbSheets.ValueSeparator = ", ";
            this.cmbSheets.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cmbSheets_ItemCheck);
            // 
            // tbBooks
            // 
            this.tbBooks.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBooks.Location = new System.Drawing.Point(11, 217);
            this.tbBooks.Name = "tbBooks";
            this.tbBooks.SelectedIndex = 0;
            this.tbBooks.Size = new System.Drawing.Size(475, 20);
            this.tbBooks.TabIndex = 14;
            this.tbBooks.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbBooks_Selected);
            // 
            // ucXmlFileOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tbBooks);
            this.Controls.Add(this.cmbSheets);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.rtxtData);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.shapeContainer1);
            this.Controls.Add(this.tbSheets);
            this.Name = "ucXmlFileOption";
            this.Size = new System.Drawing.Size(496, 247);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.RichTextBox rtxtData;
        private System.Windows.Forms.Button btnPreview;
        private CheckedComboBox cmbSheets;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.TabControl tbSheets;
        private System.Windows.Forms.TabControl tbBooks;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
    }
}
