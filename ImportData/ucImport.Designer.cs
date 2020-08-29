namespace ImportData
{
    partial class ucImport
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
            this.grdStatus = new System.Windows.Forms.DataGridView();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // grdStatus
            // 
            this.grdStatus.AllowUserToAddRows = false;
            this.grdStatus.AllowUserToDeleteRows = false;
            this.grdStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdStatus.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grdStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.grdStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStatus.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grdStatus.Location = new System.Drawing.Point(7, 6);
            this.grdStatus.Margin = new System.Windows.Forms.Padding(4);
            this.grdStatus.Name = "grdStatus";
            this.grdStatus.RowHeadersVisible = false;
            this.grdStatus.ShowCellErrors = false;
            this.grdStatus.Size = new System.Drawing.Size(803, 461);
            this.grdStatus.TabIndex = 14;
            // 
            // lblProcessing
            // 
            this.lblProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProcessing.Location = new System.Drawing.Point(32, 470);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(180, 17);
            this.lblProcessing.TabIndex = 15;
            this.lblProcessing.Text = "Processing......Please Wait!";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(35, 490);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(750, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 16;
            // 
            // ucImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.grdStatus);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucImport";
            this.Size = new System.Drawing.Size(816, 475);
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdStatus;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
