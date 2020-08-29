namespace ImportData
{
    partial class ucSQL
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
            this.txtbxUserID = new System.Windows.Forms.TextBox();
            this.txtbxAuthentication = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblAuthentication = new System.Windows.Forms.Label();
            this.txtbxServerName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.lblSqlDisp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbxPassword
            // 
            this.txtbxPassword.Location = new System.Drawing.Point(148, 147);
            this.txtbxPassword.Name = "txtbxPassword";
            this.txtbxPassword.PasswordChar = '*';
            this.txtbxPassword.Size = new System.Drawing.Size(339, 22);
            this.txtbxPassword.TabIndex = 34;
            this.txtbxPassword.Text = "toor123";
            // 
            // txtbxUserID
            // 
            this.txtbxUserID.Location = new System.Drawing.Point(148, 102);
            this.txtbxUserID.Name = "txtbxUserID";
            this.txtbxUserID.Size = new System.Drawing.Size(339, 22);
            this.txtbxUserID.TabIndex = 32;
            this.txtbxUserID.Text = "root";
            // 
            // txtbxAuthentication
            // 
            this.txtbxAuthentication.Location = new System.Drawing.Point(148, 61);
            this.txtbxAuthentication.Name = "txtbxAuthentication";
            this.txtbxAuthentication.Size = new System.Drawing.Size(339, 22);
            this.txtbxAuthentication.TabIndex = 30;
            this.txtbxAuthentication.Text = "False";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 147);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 29;
            this.lblPassword.Text = "Password";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(12, 107);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(55, 17);
            this.lblUserID.TabIndex = 28;
            this.lblUserID.Text = "User ID";
            // 
            // lblAuthentication
            // 
            this.lblAuthentication.AutoSize = true;
            this.lblAuthentication.Location = new System.Drawing.Point(10, 64);
            this.lblAuthentication.Name = "lblAuthentication";
            this.lblAuthentication.Size = new System.Drawing.Size(132, 17);
            this.lblAuthentication.TabIndex = 27;
            this.lblAuthentication.Text = "Intergrated Security";
            // 
            // txtbxServerName
            // 
            this.txtbxServerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbxServerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtbxServerName.Location = new System.Drawing.Point(148, 25);
            this.txtbxServerName.Name = "txtbxServerName";
            this.txtbxServerName.Size = new System.Drawing.Size(339, 22);
            this.txtbxServerName.TabIndex = 26;
            this.txtbxServerName.Text = "TARUN\\SQLEXPRESS";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(10, 25);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(91, 17);
            this.lblServerName.TabIndex = 25;
            this.lblServerName.Text = "Server Name";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.AutoSize = true;
            this.btnTestConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnTestConnection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTestConnection.Location = new System.Drawing.Point(0, 433);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(710, 27);
            this.btnTestConnection.TabIndex = 37;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click_1);
            // 
            // lblSqlDisp
            // 
            this.lblSqlDisp.AutoSize = true;
            this.lblSqlDisp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSqlDisp.Location = new System.Drawing.Point(0, 416);
            this.lblSqlDisp.Name = "lblSqlDisp";
            this.lblSqlDisp.Size = new System.Drawing.Size(0, 17);
            this.lblSqlDisp.TabIndex = 42;
            // 
            // ucSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSqlDisp);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.txtbxPassword);
            this.Controls.Add(this.txtbxUserID);
            this.Controls.Add(this.txtbxAuthentication);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.lblAuthentication);
            this.Controls.Add(this.txtbxServerName);
            this.Controls.Add(this.lblServerName);
            this.Name = "ucSQL";
            this.Size = new System.Drawing.Size(710, 460);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtbxPassword;
        private System.Windows.Forms.TextBox txtbxUserID;
        private System.Windows.Forms.TextBox txtbxAuthentication;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblAuthentication;
        private System.Windows.Forms.TextBox txtbxServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblSqlDisp;
    }
}
