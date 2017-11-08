using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClientUDP
{
    public partial class ConnectionMenu : Form
    {
        // refrain from creating class objects that reference other classes, can result in stack overflow error

        Form1 form1Ref = null;
        public ConnectionMenu(Form1 form)
        {
            form1Ref = form;
            
            InitializeComponent();
        }

        public ConnectionMenu()
        {
            InitializeComponent();
        }
        
      
       

        public void AddServer(Server server)
        {
            MessageBox.Show($"Adding server\nServer Name\n\t{server.ServerName}");
            listBoxServerList.Items.Add(server);
        }
        public void RemoveServer()
        {
            listBoxServerList.Items.Remove(listBoxServerList.SelectedItem);
        }
       
       

        /// <summary>
        /// Connect to the selected server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Server s = listBoxServerList.SelectedItem as Server;
               
                form1Ref.ConnectToServer(s, s.ConnectedClient);
                Close();
            }
            catch (Exception f)
            {
                MessageBox.Show($"Message:\n{f.Message}\nStack Trace:\n{f.StackTrace}", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        // **************
        private void btnServerAdd_Click(object sender, EventArgs e)
        {
            AddServerToConnectionMenu addServerToConnectionMenu = new AddServerToConnectionMenu(this);
            addServerToConnectionMenu.Show();
        }

        private void btnServerRemove_Click(object sender, EventArgs e)
        {

            Server s = listBoxServerList.SelectedItem as Server;
            if (s != null)
            {
                DialogResult result = MessageBox.Show(this, $"Delete server {s.ServerName}", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                    listBoxServerList.Items.Remove(listBoxServerList.SelectedItem);
            }
      
        }

        private void btnServerEdit_Click(object sender, EventArgs e)
        {
            
            Server s = listBoxServerList.SelectedItem as Server;
            // temp will just show server information
            if (s != null)
            {
                string serverName = s.ServerName;
                string serverAddress = s.ServerAddress.ToString();
                string serverPort = s.ServerPort.ToString();

                MessageBox.Show($"Server Name\n\t{serverName}\nServer Address\n\t{serverAddress}\nServer Port\n\t{serverPort}");
            }
        }
    }
}
