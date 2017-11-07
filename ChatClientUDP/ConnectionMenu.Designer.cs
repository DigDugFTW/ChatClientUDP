namespace ChatClientUDP
{
    partial class ConnectionMenu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxServerList = new System.Windows.Forms.ListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnServerAdd = new System.Windows.Forms.Button();
            this.btnServerRemove = new System.Windows.Forms.Button();
            this.btnServerEdit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxServerList);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server List";
            // 
            // listBoxServerList
            // 
            this.listBoxServerList.FormattingEnabled = true;
            this.listBoxServerList.Location = new System.Drawing.Point(7, 20);
            this.listBoxServerList.Name = "listBoxServerList";
            this.listBoxServerList.Size = new System.Drawing.Size(255, 147);
            this.listBoxServerList.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(20, 225);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnServerAdd
            // 
            this.btnServerAdd.Location = new System.Drawing.Point(20, 196);
            this.btnServerAdd.Name = "btnServerAdd";
            this.btnServerAdd.Size = new System.Drawing.Size(75, 23);
            this.btnServerAdd.TabIndex = 5;
            this.btnServerAdd.Text = "Add Server";
            this.btnServerAdd.UseVisualStyleBackColor = true;
            this.btnServerAdd.Click += new System.EventHandler(this.btnServerAdd_Click);
            // 
            // btnServerRemove
            // 
            this.btnServerRemove.Location = new System.Drawing.Point(101, 196);
            this.btnServerRemove.Name = "btnServerRemove";
            this.btnServerRemove.Size = new System.Drawing.Size(95, 23);
            this.btnServerRemove.TabIndex = 6;
            this.btnServerRemove.Text = "Remove Server";
            this.btnServerRemove.UseVisualStyleBackColor = true;
            this.btnServerRemove.Click += new System.EventHandler(this.btnServerRemove_Click);
            // 
            // btnServerEdit
            // 
            this.btnServerEdit.Location = new System.Drawing.Point(202, 196);
            this.btnServerEdit.Name = "btnServerEdit";
            this.btnServerEdit.Size = new System.Drawing.Size(75, 23);
            this.btnServerEdit.TabIndex = 7;
            this.btnServerEdit.Text = "Edit";
            this.btnServerEdit.UseVisualStyleBackColor = true;
            this.btnServerEdit.Click += new System.EventHandler(this.btnServerEdit_Click);
            // 
            // ConnectionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 254);
            this.Controls.Add(this.btnServerEdit);
            this.Controls.Add(this.btnServerRemove);
            this.Controls.Add(this.btnServerAdd);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectionMenu";
            this.Text = "ConnectionMenu";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        //private System.Windows.Forms.Button btnAddServer;
        //private System.Windows.Forms.Button btnRemoveServer;
        //private System.Windows.Forms.Button btnEditServer;
        private System.Windows.Forms.ListBox listBoxServerList;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnServerAdd;
        private System.Windows.Forms.Button btnServerRemove;
        private System.Windows.Forms.Button btnServerEdit;
    }
}