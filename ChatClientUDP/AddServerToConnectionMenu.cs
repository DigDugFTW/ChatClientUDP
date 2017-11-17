using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq.Expressions;

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

        /// <summary>
        /// default constructor
        /// </summary>
        public AddServerToConnectionMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// splits ip and port and creates a remote IPEndPoint with that information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateServer_Click(object sender, EventArgs e)
        {
            var filePath = @"C:\%temp%";
            var fileName = "ServerList.txt";
            var tempPath = Path.GetTempPath();

            if (textBoxUserName.Text.Length >= 4)
            {
                try
                {
                    string[] tempAddr = textBoxServerAddress.Text.Split(':');
                    IPEndPoint tempEndPoint =
                        new IPEndPoint(IPAddress.Parse(tempAddr[0]), Convert.ToInt32(tempAddr[1]));
                    Server newServer = new Server(textBoxServerName.Text, textBoxUserName.Text, tempEndPoint);
                    //MessageBox.Show("Writing to file " + Path.Combine(tempPath, fileName) + "\nWith data:\n" +
                    //                newServer.ToSerializableString());


                    using (var sw = File.AppendText(Path.Combine(tempPath, fileName)))
                    {
                        sw.Write(newServer.ToSerializableString() + "\r\n");
                    }





                    referencedConnectionMenu.AddServer(newServer);

                    Close();
                }
                catch (Exception f)
                {
                    MessageBox.Show(
                        $"Invalid Address specified, please rety.\nBe sure to input the address in the following format:\nXXX.XXX.X.X:XXXX\nFor debug:\nMessage:\n{f.Message}\nStack Trace:\n{f.StackTrace}",
                        "Address error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Username must be atleast 4 characters long");
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

        /// <summary>
        /// Closes the add server menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelCreateServer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddServerToConnectionMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
