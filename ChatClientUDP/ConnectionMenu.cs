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
       

        public ConnectionMenu()
        {
           
            InitializeComponent();
        }
        
        // will be using current reference to the Connection Menu object
        public static void AddServerStatic(Server server)
        {
            MessageBox.Show($"Adding server\nServer Name\n\t{server.ServerName}");
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

        }

        // **************
        private void btnServerAdd_Click(object sender, EventArgs e)
        {
            AddServerToConnectionMenu addServerToConnectionMenu = new AddServerToConnectionMenu(this);
            addServerToConnectionMenu.Show();
        }

        private void btnServerRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnServerEdit_Click(object sender, EventArgs e)
        {
            Server s = listBoxServerList.SelectedItem as Server;
            // temp will just show server information
            string serverName = s.ServerName;
            string serverAddress = s.ServerAddress.ToString();
            string serverPort = s.ServerPort.ToString();

            MessageBox.Show($"Server Name\n\t{serverName}\nServer Address\n\t{serverAddress}\nServer Port\n\t{serverPort}");
        }
    }
}
