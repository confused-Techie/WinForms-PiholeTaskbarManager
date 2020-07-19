using System;

namespace PiholeTaskbarManager
{
    partial class ConfigBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigBox));
            this.url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedList = new System.Windows.Forms.CheckedListBox();
            this.connectionCheckBox = new System.Windows.Forms.CheckBox();
            this.testConnection = new System.Windows.Forms.CheckBox();
            this.updateTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(15, 25);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(146, 20);
            this.url.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Full URL of your Pi-hole.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "EXAMPLE: http://192.168.0.1/admin/api.php";
            // 
            // checkedList
            // 
            this.checkedList.FormattingEnabled = true;
            this.checkedList.Items.AddRange(new object[] {
            "Domains Being Blocked",
            "DNS Queries Today",
            "Ads Blocked Today",
            "Percentage of Ads Blocked Today",
            "Unique Domains Queried Today",
            "DNS Queries Forwarded",
            "DNS Queries Cached",
            "Clients Ever Seen",
            "Unique Clients",
            "DNS Queries of All Types",
            "Replies of NODATA",
            "Replies of NXDOMAIN",
            "Replies of CNAME",
            "Replies of IP",
            "DNS Resolver Privacy Level",
            "Enabled/Disabled Status"});
            this.checkedList.Location = new System.Drawing.Point(12, 111);
            this.checkedList.Name = "checkedList";
            this.checkedList.Size = new System.Drawing.Size(260, 244);
            this.checkedList.TabIndex = 3;
            // 
            // connectionCheckBox
            // 
            this.connectionCheckBox.AutoSize = true;
            this.connectionCheckBox.Location = new System.Drawing.Point(122, 64);
            this.connectionCheckBox.Name = "connectionCheckBox";
            this.connectionCheckBox.Size = new System.Drawing.Size(102, 17);
            this.connectionCheckBox.TabIndex = 4;
            this.connectionCheckBox.Text = "Use Connection";
            this.connectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // testConnection
            // 
            this.testConnection.AutoSize = true;
            this.testConnection.Location = new System.Drawing.Point(12, 64);
            this.testConnection.Name = "testConnection";
            this.testConnection.Size = new System.Drawing.Size(104, 17);
            this.testConnection.TabIndex = 5;
            this.testConnection.Text = "Test Connection";
            this.testConnection.UseVisualStyleBackColor = true;
            // 
            // updateTime
            // 
            this.updateTime.Location = new System.Drawing.Point(212, 81);
            this.updateTime.MaxLength = 10000;
            this.updateTime.Name = "updateTime";
            this.updateTime.Size = new System.Drawing.Size(60, 20);
            this.updateTime.TabIndex = 6;
            this.updateTime.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "How often to update data? (In Seconds)";
            // 
            // ConfigBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(288, 367);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.updateTime);
            this.Controls.Add(this.testConnection);
            this.Controls.Add(this.connectionCheckBox);
            this.Controls.Add(this.checkedList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.url);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigBox";
            this.Text = "Configure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckedListBox checkedList;
        public System.Windows.Forms.CheckBox connectionCheckBox;
        public System.Windows.Forms.CheckBox testConnection;
        public System.Windows.Forms.TextBox updateTime;
        private System.Windows.Forms.Label label3;
    }
}