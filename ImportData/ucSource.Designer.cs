namespace ImportData
{
    partial class ucSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSource));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblExcel2007 = new System.Windows.Forms.Label();
            this.lblExcel = new System.Windows.Forms.Label();
            this.lblCsv = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.pnlDesc = new System.Windows.Forms.Panel();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblExcel2007);
            this.panel1.Controls.Add(this.lblExcel);
            this.panel1.Controls.Add(this.lblCsv);
            this.panel1.Controls.Add(this.lblText);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 181);
            this.panel1.TabIndex = 0;
            // 
            // lblExcel2007
            // 
            this.lblExcel2007.AutoEllipsis = true;
            this.lblExcel2007.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblExcel2007.Image = ((System.Drawing.Image)(resources.GetObject("lblExcel2007.Image")));
            this.lblExcel2007.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblExcel2007.Location = new System.Drawing.Point(497, 26);
            this.lblExcel2007.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExcel2007.Name = "lblExcel2007";
            this.lblExcel2007.Size = new System.Drawing.Size(83, 64);
            this.lblExcel2007.TabIndex = 3;
            this.lblExcel2007.Text = "Excel 2007";
            this.lblExcel2007.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblExcel2007.UseMnemonic = false;
            this.lblExcel2007.Click += new System.EventHandler(this.lblExcel2007_Click);
            // 
            // lblExcel
            // 
            this.lblExcel.AutoEllipsis = true;
            this.lblExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblExcel.Image = ((System.Drawing.Image)(resources.GetObject("lblExcel.Image")));
            this.lblExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblExcel.Location = new System.Drawing.Point(349, 26);
            this.lblExcel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExcel.Name = "lblExcel";
            this.lblExcel.Size = new System.Drawing.Size(83, 64);
            this.lblExcel.TabIndex = 2;
            this.lblExcel.Text = "Excel File";
            this.lblExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblExcel.UseMnemonic = false;
            this.lblExcel.Click += new System.EventHandler(this.lblExcel_Click);
            // 
            // lblCsv
            // 
            this.lblCsv.AutoEllipsis = true;
            this.lblCsv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCsv.Image = ((System.Drawing.Image)(resources.GetObject("lblCsv.Image")));
            this.lblCsv.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCsv.Location = new System.Drawing.Point(211, 26);
            this.lblCsv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCsv.Name = "lblCsv";
            this.lblCsv.Size = new System.Drawing.Size(83, 64);
            this.lblCsv.TabIndex = 1;
            this.lblCsv.Text = "CSV File";
            this.lblCsv.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCsv.UseMnemonic = false;
            this.lblCsv.Click += new System.EventHandler(this.lblCsv_Click);
            // 
            // lblText
            // 
            this.lblText.AutoEllipsis = true;
            this.lblText.BackColor = System.Drawing.Color.White;
            this.lblText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblText.Image = ((System.Drawing.Image)(resources.GetObject("lblText.Image")));
            this.lblText.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblText.Location = new System.Drawing.Point(75, 26);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(83, 64);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Text File";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblText.UseMnemonic = false;
            this.lblText.Click += new System.EventHandler(this.lblText_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(80, 218);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(620, 59);
            this.txtFileName.TabIndex = 5;
            // 
            // lblFile
            // 
            this.lblFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(7, 217);
            this.lblFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(71, 17);
            this.lblFile.TabIndex = 2;
            this.lblFile.Text = "File Name";
            // 
            // pnlDesc
            // 
            this.pnlDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDesc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDesc.Controls.Add(this.lblDesc);
            this.pnlDesc.Location = new System.Drawing.Point(1, 182);
            this.pnlDesc.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Size = new System.Drawing.Size(807, 28);
            this.pnlDesc.TabIndex = 1;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(5, 5);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(0, 17);
            this.lblDesc.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(708, 249);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 30);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ucSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.pnlDesc);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucSource";
            this.Size = new System.Drawing.Size(812, 286);
            this.Load += new System.EventHandler(this.ucSource_Load);
            this.panel1.ResumeLayout(false);
            this.pnlDesc.ResumeLayout(false);
            this.pnlDesc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblCsv;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblExcel2007;
        private System.Windows.Forms.Label lblExcel;
    }
}
