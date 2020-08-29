namespace ImportData
{
    partial class ucMapping
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
            this.tbSheets = new System.Windows.Forms.TabControl();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.grdMapping = new System.Windows.Forms.DataGridView();
            this.rdbCreateNew = new System.Windows.Forms.RadioButton();
            this.rdbUseExisting = new System.Windows.Forms.RadioButton();
            this.txtbxCreateNew = new System.Windows.Forms.TextBox();
            this.cbUseExisting = new System.Windows.Forms.ComboBox();
            this.lblSelectDatabase = new System.Windows.Forms.Label();
            this.cbSelectDatabase = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdMapping)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSheets
            // 
            this.tbSheets.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbSheets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSheets.Location = new System.Drawing.Point(3, 509);
            this.tbSheets.Margin = new System.Windows.Forms.Padding(4);
            this.tbSheets.Name = "tbSheets";
            this.tbSheets.SelectedIndex = 0;
            this.tbSheets.Size = new System.Drawing.Size(916, 25);
            this.tbSheets.TabIndex = 11;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 2;
            this.lineShape1.X2 = 785;
            this.lineShape1.Y1 = 433;
            this.lineShape1.Y2 = 433;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(920, 543);
            this.shapeContainer1.TabIndex = 12;
            this.shapeContainer1.TabStop = false;
            // 
            // grdMapping
            // 
            this.grdMapping.AllowUserToAddRows = false;
            this.grdMapping.AllowUserToDeleteRows = false;
            this.grdMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMapping.Location = new System.Drawing.Point(4, 92);
            this.grdMapping.Margin = new System.Windows.Forms.Padding(10);
            this.grdMapping.Name = "grdMapping";
            this.grdMapping.RowHeadersVisible = false;
            this.grdMapping.Size = new System.Drawing.Size(911, 414);
            this.grdMapping.TabIndex = 13;
            this.grdMapping.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdMapping_DataBindingComplete);
            // 
            // rdbCreateNew
            // 
            this.rdbCreateNew.AutoSize = true;
            this.rdbCreateNew.Location = new System.Drawing.Point(4, 64);
            this.rdbCreateNew.Name = "rdbCreateNew";
            this.rdbCreateNew.Size = new System.Drawing.Size(142, 21);
            this.rdbCreateNew.TabIndex = 14;
            this.rdbCreateNew.TabStop = true;
            this.rdbCreateNew.Text = "Create New Table";
            this.rdbCreateNew.UseVisualStyleBackColor = true;
            this.rdbCreateNew.CheckedChanged += new System.EventHandler(this.rdbCreateNew_CheckedChanged);
            // 
            // rdbUseExisting
            // 
            this.rdbUseExisting.AutoSize = true;
            this.rdbUseExisting.Location = new System.Drawing.Point(4, 37);
            this.rdbUseExisting.Name = "rdbUseExisting";
            this.rdbUseExisting.Size = new System.Drawing.Size(146, 21);
            this.rdbUseExisting.TabIndex = 15;
            this.rdbUseExisting.TabStop = true;
            this.rdbUseExisting.Text = "Use Existing Table";
            this.rdbUseExisting.UseVisualStyleBackColor = true;
            this.rdbUseExisting.CheckedChanged += new System.EventHandler(this.rdbUseExisting_CheckedChanged);
            // 
            // txtbxCreateNew
            // 
            this.txtbxCreateNew.Location = new System.Drawing.Point(156, 63);
            this.txtbxCreateNew.Name = "txtbxCreateNew";
            this.txtbxCreateNew.Size = new System.Drawing.Size(147, 22);
            this.txtbxCreateNew.TabIndex = 17;
            //this.txtbxCreateNew.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cbUseExisting
            // 
            this.cbUseExisting.FormattingEnabled = true;
            this.cbUseExisting.Location = new System.Drawing.Point(156, 36);
            this.cbUseExisting.Name = "cbUseExisting";
            this.cbUseExisting.Size = new System.Drawing.Size(146, 24);
            this.cbUseExisting.TabIndex = 18;
            this.cbUseExisting.SelectedIndexChanged += new System.EventHandler(this.cbUseExisting_SelectedIndexChanged);
            // 
            // lblSelectDatabase
            // 
            this.lblSelectDatabase.AutoSize = true;
            this.lblSelectDatabase.Location = new System.Drawing.Point(3, 10);
            this.lblSelectDatabase.Name = "lblSelectDatabase";
            this.lblSelectDatabase.Size = new System.Drawing.Size(116, 17);
            this.lblSelectDatabase.TabIndex = 20;
            this.lblSelectDatabase.Text = "Select Database:";
            // 
            // cbSelectDatabase
            // 
            this.cbSelectDatabase.FormattingEnabled = true;
            this.cbSelectDatabase.Location = new System.Drawing.Point(125, 7);
            this.cbSelectDatabase.Name = "cbSelectDatabase";
            this.cbSelectDatabase.Size = new System.Drawing.Size(319, 24);
            this.cbSelectDatabase.TabIndex = 21;
            this.cbSelectDatabase.SelectedIndexChanged += new System.EventHandler(this.cbSelectDatabase_SelectedIndexChanged);
            // 
            // ucMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.cbSelectDatabase);
            this.Controls.Add(this.lblSelectDatabase);
            this.Controls.Add(this.cbUseExisting);
            this.Controls.Add(this.txtbxCreateNew);
            this.Controls.Add(this.rdbUseExisting);
            this.Controls.Add(this.rdbCreateNew);
            this.Controls.Add(this.grdMapping);
            this.Controls.Add(this.tbSheets);
            this.Controls.Add(this.shapeContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucMapping";
            this.Size = new System.Drawing.Size(920, 543);
            ((System.ComponentModel.ISupportInitialize)(this.grdMapping)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbSheets;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.DataGridView grdMapping;
        private System.Windows.Forms.RadioButton rdbCreateNew;
        private System.Windows.Forms.RadioButton rdbUseExisting;
        private System.Windows.Forms.TextBox txtbxCreateNew;
        private System.Windows.Forms.ComboBox cbUseExisting;
        private System.Windows.Forms.Label lblSelectDatabase;
        private System.Windows.Forms.ComboBox cbSelectDatabase;
    }
}
