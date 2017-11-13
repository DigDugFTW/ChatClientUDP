namespace ChatServerUDP
{
    partial class ServerForm
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
            this.btnClientBan = new System.Windows.Forms.Button();
            this.btnClientKick = new System.Windows.Forms.Button();
            this.btnClientInfo = new System.Windows.Forms.Button();
            this.listBoxConnectedClients = new System.Windows.Forms.ListBox();
            this.labelClientsConnected = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxServerLog = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxServerPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClientBan);
            this.groupBox1.Controls.Add(this.btnClientKick);
            this.groupBox1.Controls.Add(this.btnClientInfo);
            this.groupBox1.Controls.Add(this.listBoxConnectedClients);
            this.groupBox1.Controls.Add(this.labelClientsConnected);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 189);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Information";
            // 
            // btnClientBan
            // 
            this.btnClientBan.Location = new System.Drawing.Point(257, 116);
            this.btnClientBan.Name = "btnClientBan";
            this.btnClientBan.Size = new System.Drawing.Size(75, 23);
            this.btnClientBan.TabIndex = 5;
            this.btnClientBan.Text = "Ban";
            this.btnClientBan.UseVisualStyleBackColor = true;
            // 
            // btnClientKick
            // 
            this.btnClientKick.Location = new System.Drawing.Point(257, 87);
            this.btnClientKick.Name = "btnClientKick";
            this.btnClientKick.Size = new System.Drawing.Size(75, 23);
            this.btnClientKick.TabIndex = 4;
            this.btnClientKick.Text = "Kick";
            this.btnClientKick.UseVisualStyleBackColor = true;
            // 
            // btnClientInfo
            // 
            this.btnClientInfo.Location = new System.Drawing.Point(257, 58);
            this.btnClientInfo.Name = "btnClientInfo";
            this.btnClientInfo.Size = new System.Drawing.Size(75, 23);
            this.btnClientInfo.TabIndex = 3;
            this.btnClientInfo.Text = "Info";
            this.btnClientInfo.UseVisualStyleBackColor = true;
            this.btnClientInfo.Click += new System.EventHandler(this.btnClientInfo_Click);
            // 
            // listBoxConnectedClients
            // 
            this.listBoxConnectedClients.FormattingEnabled = true;
            this.listBoxConnectedClients.Location = new System.Drawing.Point(10, 58);
            this.listBoxConnectedClients.Name = "listBoxConnectedClients";
            this.listBoxConnectedClients.Size = new System.Drawing.Size(241, 108);
            this.listBoxConnectedClients.TabIndex = 2;
            // 
            // labelClientsConnected
            // 
            this.labelClientsConnected.AutoSize = true;
            this.labelClientsConnected.Location = new System.Drawing.Point(119, 30);
            this.labelClientsConnected.Name = "labelClientsConnected";
            this.labelClientsConnected.Size = new System.Drawing.Size(13, 13);
            this.labelClientsConnected.TabIndex = 1;
            this.labelClientsConnected.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clients Connected";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxServerLog);
            this.groupBox2.Location = new System.Drawing.Point(19, 286);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 224);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Log";
            // 
            // listBoxServerLog
            // 
            this.listBoxServerLog.FormattingEnabled = true;
            this.listBoxServerLog.Location = new System.Drawing.Point(6, 19);
            this.listBoxServerLog.Name = "listBoxServerLog";
            this.listBoxServerLog.Size = new System.Drawing.Size(430, 199);
            this.listBoxServerLog.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelPassword);
            this.groupBox3.Controls.Add(this.textBoxServerPassword);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxServerPort);
            this.groupBox3.Controls.Add(this.btnStopServer);
            this.groupBox3.Controls.Add(this.btnStartServer);
            this.groupBox3.Location = new System.Drawing.Point(19, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 72);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Control";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(70, 27);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(99, 13);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Password (optional)";
            // 
            // textBoxServerPassword
            // 
            this.textBoxServerPassword.Location = new System.Drawing.Point(73, 43);
            this.textBoxServerPassword.MaxLength = 20;
            this.textBoxServerPassword.Name = "textBoxServerPassword";
            this.textBoxServerPassword.PasswordChar = '*';
            this.textBoxServerPassword.Size = new System.Drawing.Size(110, 20);
            this.textBoxServerPassword.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Server Port";
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(10, 43);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(57, 20);
            this.textBoxServerPort.TabIndex = 6;
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(270, 41);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(75, 23);
            this.btnStopServer.TabIndex = 5;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(189, 41);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 4;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 522);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelClientsConnected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxServerLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox textBoxServerPassword;
        private System.Windows.Forms.ListBox listBoxConnectedClients;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button btnClientBan;
        private System.Windows.Forms.Button btnClientKick;
        private System.Windows.Forms.Button btnClientInfo;
    }
}

