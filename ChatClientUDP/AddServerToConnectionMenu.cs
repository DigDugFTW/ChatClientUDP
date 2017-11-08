using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace ChatClientUDP
{
    public partial class AddServerToConnectionMenu : Form
    {
        

        // direct reference to ConnectionMenu current instance from this form
        ConnectionMenu referencedConnectionMenu = null;

        /// <summary>
        /// Contructor takes a reference to ConnectionMenu allowing for direct manipulation of the 
        /// current instance of the ConnectionMenu
        /// </summary>
        /// <param name="form">
        /// Reference of ConnectionMenu; Allowing direct manipulation of current instance of ConnectionMenu
        /// </param>
        public AddServerToConnectionMenu(ConnectionMenu form)
        {
            referencedConnectionMenu = form;
            InitializeComponent();
        }

        public AddServerToConnectionMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// splits ip and port and creates a remote IPEndPoint with that informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateServer_Click(object sender, EventArgs e)
        {

            try
            {
                string[] tempAddr = textBoxServerAddress.Text.Split(':');
                IPEndPoint tempEndPoint = new IPEndPoint(IPAddress.Parse(tempAddr[0]), Convert.ToInt32(tempAddr[1]));
                Server newServer = new Server(textBoxServerName.Text, textBoxUserName.Text, tempEndPoint);

                referencedConnectionMenu.AddServer(newServer);

                Close();
            }
            catch (Exception f)
            {
                MessageBox.Show($"Invalid Address specified, please rety.\nBe sure to input the address in the following format:\nXXX.XXX.X.X:XXXX\nFor debug:\nMessage:\n{f.Message}\nStack Trace:\n{f.StackTrace}", "Address error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }

        /// <summary>
        /// Will create and save the connection then also connect to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateAndConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelCreateServer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
