namespace ImportData
{
    partial class ucMySQL
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
            this.txtbxPassword = new System.Windows.Forms.TextBox();
            this.lblPortNumber = new System.Windows.Forms.Label();
            this.txtbxUserID = new System.Windows.Forms.TextBox();
            this.txtbxPortNumber = new System.Windows.Forms.TextBox();
            this.txtbxSSLMode = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblSSLMode = new System.Windows.Forms.Label();
            this.txtbxServerName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.btnTestConnectionMySQL = new System.Windows.Forms.Button();
            this.lblMySqlDisp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbxPassword
            // 
            this.txtbxPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbxPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtbxPassword.Location = new System.Drawing.Point(124, 170);
            this.txtbxPassword.Name = "txtbxPassword";
            this.txtbxPassword.PasswordChar = '*';
            this.txtbxPassword.Size = new System.Drawing.Size(339, 22);
            this.txtbxPassword.TabIndex = 23;
            this.txtbxPassword.Text = "toor123";
            // 
            // lblPortNumber
            // 
            this.lblPortNumber.AutoSize = true;
            this.lblPortNumber.Location = new System.Drawing.Point(16, 97);
            this.lblPortNumber.Name = "lblPortNumber";
            this.lblPortNumber.Size = new System.Drawing.Size(88, 17);
            this.lblPortNumber.TabIndex = 22;
            this.lblPortNumber.Text = "Port Number";
            // 
            // txtbxUserID
            // 
            this.txtbxUserID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbxUserID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtbxUserID.Location = new System.Drawing.Point(124, 133);
            this.txtbxUserID.Name = "txtbxUserID";
            this.txtbxUserID.Size = new System.Drawing.Size(339, 22);
            this.txtbxUserID.TabIndex = 21;
            this.txtbxUserID.Text = "root";
            // 
            // txtbxPortNumber
            // 
            this.txtbxPortNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbxPortNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtbxPortNumber.Location = new System.Drawing.Point(124, 97);
            this.txtbxPortNumber.Name = "txtbxPortNumber";
            this.txtbxPortNumber.Size = new System.Drawing.Size(339, 22);
            this.txtbxPortNumber.TabIndex = 20;
            this.txtbxPortNumber.Text = "3306";
            // 
            // txtbxSSLMode
            // 
            this.txtbxSSLMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbxSSLMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtbxSSLMode.Location = new System.Drawing.Point(124, 60);
            this.txtbxSSLMode.Name = "txtbxSSLMode";
            this.txtbxSSLMode.Size = new System.Drawing.Size(339, 22);
            this.txtbxSSLMode.TabIndex = 19;
            this.txtbxSSLMode.Text = "none";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 170);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "Password";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(16, 133);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(55, 17);
            this.lblUserID.TabIndex = 17;
            this.lblUserID.Text = "User ID";
            // 
            // lblSSLMode
            // 
            this.lblSSLMode.AutoSize = true;
            this.lblSSLMode.Location = new System.Drawing.Point(14, 60);
            this.lblSSLMode.Name = "lblSSLMode";
            this.lblSSLMode.Size = new System.Drawing.Size(73, 17);
            this.lblSSLMode.TabIndex = 16;
            this.lblSSLMode.Text = "SSL Mode";
            // 
            // txtbxServerName
            // 
            this.txtbxServerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbxServerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtbxServerName.Location = new System.Drawing.Point(124, 21);
            this.txtbxServerName.Name = "txtbxServerName";
            this.txtbxServerName.Size = new System.Drawing.Size(339, 22);
            this.txtbxServerName.TabIndex = 15;
            this.txtbxServerName.Text = "localhost";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(14, 21);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(87, 17);
            this.lblServerName.TabIndex = 14;
            this.lblServerName.Text = "Data Source";
            // 
            // btnTestConnectionMySQL
            // 
            this.btnTestConnectionMySQL.AutoSize = true;
            this.btnTestConnectionMySQL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTestConnectionMySQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnTestConnectionMySQL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTestConnectionMySQL.Location = new System.Drawing.Point(0, 432);
            this.btnTestConnectionMySQL.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestConnectionMySQL.Name = "btnTestConnectionMySQL";
            this.btnTestConnectionMySQL.Size = new System.Drawing.Size(627, 27);
            this.btnTestConnectionMySQL.TabIndex = 38;
            this.btnTestConnectionMySQL.Text = "Test Connection";
            this.btnTestConnectionMySQL.UseMnemonic = false;
            this.btnTestConnectionMySQL.UseVisualStyleBackColor = false;
            this.btnTestConnectionMySQL.Click += new System.EventHandler(this.btnTestConnectionMySQL_Click);
            // 
            // lblMySqlDisp
            // 
            this.lblMySqlDisp.AutoSize = true;
            this.lblMySqlDisp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMySqlDisp.Location = new System.Drawing.Point(0, 415);
            this.lblMySqlDisp.Name = "lblMySqlDisp";
            this.lblMySqlDisp.Size = new System.Drawing.Size(0, 17);
            this.lblMySqlDisp.TabIndex = 42;
            // 
            // ucMySQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMySqlDisp);
            this.Controls.Add(this.btnTestConnectionMySQL);
            this.Controls.Add(this.txtbxPassword);
            this.Controls.Add(this.lblPortNumber);
            this.Controls.Add(this.txtbxUserID);
            this.Controls.Add(this.txtbxPortNumber);
            this.Controls.Add(this.txtbxSSLMode);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.lblSSLMode);
            this.Controls.Add(this.txtbxServerName);
            this.Controls.Add(this.lblServerName);
            this.Name = "ucMySQL";
            this.Size = new System.Drawing.Size(627, 459);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxPassword;
        private System.Windows.Forms.Label lblPortNumber;
        private System.Windows.Forms.TextBox txtbxUserID;
        private System.Windows.Forms.TextBox txtbxPortNumber;
        private System.Windows.Forms.TextBox txtbxSSLMode;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblSSLMode;
        private System.Windows.Forms.TextBox txtbxServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Button btnTestConnectionMySQL;
        private System.Windows.Forms.Label lblMySqlDisp;
    }
}
