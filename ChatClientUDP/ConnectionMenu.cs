using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ChatClientUDP
{
    public partial class ConnectionMenu : Form
    {
        // refrain from creating class objects that reference other classes, can result in stack overflow error
        List<Server> ServerList = new List<Server>();

            // reference to form1
        Form1 form1Ref = null;

        public ConnectionMenu(Form1 form)
        {
            // form1 is passed as a parameter in ConnectionMenu
            // allowing for access in this class
            form1Ref = form;
            
            InitializeComponent();
        }

        public ConnectionMenu()
        {
            InitializeComponent();
        }
        
        public void AddServer(Server server)
        {
           
            listBoxServerList.Items.Add(server);
            //ServerList.Add(server);
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
                var s = listBoxServerList.SelectedItem as Server;

                form1Ref.ConnectToServer(s, s.ConnectedClient);
                Close();
            }
            catch (Exception f)
            {
                MessageBox.Show($"Message:\n{f.Message}\nStack Trace:\n{f.StackTrace}", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Adds a server to the connection menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerAdd_Click(object sender, EventArgs e)
        {
            // passes a reference to addServerToConnectioMenu allowing for that
            // form to change ConnectionMenu
            AddServerToConnectionMenu addServerToConnectionMenu = new AddServerToConnectionMenu(this);
            

            addServerToConnectionMenu.Show();
        }

        /// <summary>
        /// Deletes an item in the server listbox, prompts the user to confirm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerRemove_Click(object sender, EventArgs e)
        {
            if (!(listBoxServerList.SelectedItem is Server s)) return;
            var result = MessageBox.Show(this, $"Delete server {s.ServerName}", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                listBoxServerList.Items.Remove(listBoxServerList.SelectedItem);
        }

        /// <summary>
        /// Currently just shows info about the server that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerEdit_Click(object sender, EventArgs e)
        {
            
            var s = listBoxServerList.SelectedItem as Server;
            // temp will just show server information
            if (s == null) return;
            var serverName = s.ServerName;
            var serverAddress = s.ServerAddress.ToString();
            var serverPort = s.ServerPort.ToString();

            MessageBox.Show($"Server Name\n\t{serverName}\nServer Address\n\t{serverAddress}\nServer Port\n\t{serverPort}");
        }

        private void ConnectionMenu_Load(object sender, EventArgs e)
        {
            


        }
    }
}
