using System;

namespace ImportData
{
    partial class ucConnection
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbConnectionType = new System.Windows.Forms.ComboBox();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.pnlConnectionContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cbConnectionType
            // 
            this.cbConnectionType.FormattingEnabled = true;
            this.cbConnectionType.Items.AddRange(new object[] {
            "SQL",
            "MySQL"});
            this.cbConnectionType.Location = new System.Drawing.Point(200, 6);
            this.cbConnectionType.Name = "cbConnectionType";
            this.cbConnectionType.Size = new System.Drawing.Size(188, 24);
            this.cbConnectionType.TabIndex = 14;
            this.cbConnectionType.SelectedIndexChanged += new System.EventHandler(this.cbConnectionType_Selected);
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.AutoSize = true;
            this.lblConnectionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionType.Location = new System.Drawing.Point(3, 6);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(191, 20);
            this.lblConnectionType.TabIndex = 15;
            this.lblConnectionType.Text = "Select Connection Type:";
            // 
            // pnlConnectionContainer
            // 
            this.pnlConnectionContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConnectionContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlConnectionContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.pnlConnectionContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConnectionContainer.Location = new System.Drawing.Point(0, 37);
            this.pnlConnectionContainer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlConnectionContainer.Name = "pnlConnectionContainer";
            this.pnlConnectionContainer.Size = new System.Drawing.Size(861, 388);
            this.pnlConnectionContainer.TabIndex = 18;
            // 
            // ucConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlConnectionContainer);
            this.Controls.Add(this.lblConnectionType);
            this.Controls.Add(this.cbConnectionType);
            this.Name = "ucConnection";
            this.Size = new System.Drawing.Size(861, 429);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cbConnectionType;
        private System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.Panel pnlConnectionContainer;
    }
}
