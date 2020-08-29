namespace ImportData
{
    partial class frmImport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.pnlConnection = new System.Windows.Forms.Panel();
            this.lblConnection = new System.Windows.Forms.Label();
            this.pnlImport = new System.Windows.Forms.Panel();
            this.lblImport = new System.Windows.Forms.Label();
            this.pnlSource = new System.Windows.Forms.Panel();
            this.lblSource = new System.Windows.Forms.Label();
            this.pnlMapping = new System.Windows.Forms.Panel();
            this.lblMapping = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblOptions = new System.Windows.Forms.Label();
            this.pnlNevigator = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.pnlConnection.SuspendLayout();
            this.pnlImport.SuspendLayout();
            this.pnlSource.SuspendLayout();
            this.pnlMapping.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlNevigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblDescription);
            this.pnlHeader.Controls.Add(this.lblHeading);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1264, 110);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(67, 52);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 17);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description";
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(32, 28);
            this.lblHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(87, 20);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Heading";
            // 
            // pnlTab
            // 
            this.pnlTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(222)))));
            this.pnlTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTab.Controls.Add(this.pnlConnection);
            this.pnlTab.Controls.Add(this.pnlImport);
            this.pnlTab.Controls.Add(this.pnlSource);
            this.pnlTab.Controls.Add(this.pnlMapping);
            this.pnlTab.Controls.Add(this.pnlOptions);
            this.pnlTab.Location = new System.Drawing.Point(0, 110);
            this.pnlTab.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Size = new System.Drawing.Size(162, 592);
            this.pnlTab.TabIndex = 1;
            // 
            // pnlConnection
            // 
            this.pnlConnection.Controls.Add(this.lblConnection);
            this.pnlConnection.Location = new System.Drawing.Point(1, 52);
            this.pnlConnection.Margin = new System.Windows.Forms.Padding(4);
            this.pnlConnection.Name = "pnlConnection";
            this.pnlConnection.Size = new System.Drawing.Size(160, 37);
            this.pnlConnection.TabIndex = 6;
            this.pnlConnection.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlConnectionType_Paint);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnection.Location = new System.Drawing.Point(17, 10);
            this.lblConnection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(87, 17);
            this.lblConnection.TabIndex = 0;
            this.lblConnection.Text = "Connection";
            this.lblConnection.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlImport
            // 
            this.pnlImport.Controls.Add(this.lblImport);
            this.pnlImport.Location = new System.Drawing.Point(1, 187);
            this.pnlImport.Margin = new System.Windows.Forms.Padding(4);
            this.pnlImport.Name = "pnlImport";
            this.pnlImport.Size = new System.Drawing.Size(160, 37);
            this.pnlImport.TabIndex = 5;
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImport.Location = new System.Drawing.Point(17, 10);
            this.lblImport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(56, 17);
            this.lblImport.TabIndex = 0;
            this.lblImport.Text = "Import";
            // 
            // pnlSource
            // 
            this.pnlSource.Controls.Add(this.lblSource);
            this.pnlSource.Location = new System.Drawing.Point(1, 7);
            this.pnlSource.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(160, 37);
            this.pnlSource.TabIndex = 2;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(17, 10);
            this.lblSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(57, 17);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source";
            // 
            // pnlMapping
            // 
            this.pnlMapping.Controls.Add(this.lblMapping);
            this.pnlMapping.Location = new System.Drawing.Point(1, 142);
            this.pnlMapping.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMapping.Name = "pnlMapping";
            this.pnlMapping.Size = new System.Drawing.Size(160, 37);
            this.pnlMapping.TabIndex = 4;
            // 
            // lblMapping
            // 
            this.lblMapping.AutoSize = true;
            this.lblMapping.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapping.Location = new System.Drawing.Point(17, 10);
            this.lblMapping.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMapping.Name = "lblMapping";
            this.lblMapping.Size = new System.Drawing.Size(66, 17);
            this.lblMapping.TabIndex = 0;
            this.lblMapping.Text = "Mapping";
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.lblOptions);
            this.pnlOptions.Location = new System.Drawing.Point(1, 97);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(160, 37);
            this.pnlOptions.TabIndex = 3;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.Location = new System.Drawing.Point(17, 10);
            this.lblOptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(63, 17);
            this.lblOptions.TabIndex = 0;
            this.lblOptions.Text = "Options";
            // 
            // pnlNevigator
            // 
            this.pnlNevigator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNevigator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.pnlNevigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNevigator.Controls.Add(this.btnCancel);
            this.pnlNevigator.Controls.Add(this.btnNext);
            this.pnlNevigator.Controls.Add(this.btnback);
            this.pnlNevigator.Location = new System.Drawing.Point(0, 701);
            this.pnlNevigator.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNevigator.Name = "pnlNevigator";
            this.pnlNevigator.Size = new System.Drawing.Size(1264, 41);
            this.pnlNevigator.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnCancel.Location = new System.Drawing.Point(1155, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnNext.Location = new System.Drawing.Point(1047, 6);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 28);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next >";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnback
            // 
            this.btnback.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnback.Location = new System.Drawing.Point(939, 6);
            this.btnback.Margin = new System.Windows.Forms.Padding(4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(100, 28);
            this.btnback.TabIndex = 0;
            this.btnback.Text = "< Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.pnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContainer.Location = new System.Drawing.Point(161, 110);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1103, 592);
            this.pnlContainer.TabIndex = 3;
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 743);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlNevigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmImport";
            this.Text = "Data Import";
            this.Load += new System.EventHandler(this.frmImport_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTab.ResumeLayout(false);
            this.pnlConnection.ResumeLayout(false);
            this.pnlConnection.PerformLayout();
            this.pnlImport.ResumeLayout(false);
            this.pnlImport.PerformLayout();
            this.pnlSource.ResumeLayout(false);
            this.pnlSource.PerformLayout();
            this.pnlMapping.ResumeLayout(false);
            this.pnlMapping.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlNevigator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.Panel pnlNevigator;
        private System.Windows.Forms.Panel pnlImport;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Panel pnlMapping;
        private System.Windows.Forms.Label lblMapping;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Panel pnlSource;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Panel pnlConnection;
        private System.Windows.Forms.Label lblConnection;
    }
}