using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ChatClientUDP
{
    public partial class Form1 : Form
    {
        UdpClient client;

        // for receiving
        //IPEndPoint clientEndPoint;

        public Form1()
        {
            InitializeComponent();
        }

        // idea for convert username into auto reply port number..

        /// <summary>
        /// *WIP.... just an idea.. don't hate me!!*
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private string ConvertNameToReplyPort(string username)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < username.Length; i++)
            {
                sb.Append((int)username[i]);
            }
            string tmp = sb.ToString().Substring(0, 1) + sb.ToString().Substring(sb.ToString().Length - 3);
            return tmp;
        }

        Client clientObj = default(Client);
        Server serverObj = null;

        public void ConnectToServer(Server server, string clientName)
        {
            // will need to check that the client name is atleast 4 charaters long
            clientObj = new Client();
            serverObj = server;
            clientObj.ClientPort = int.Parse(ConvertNameToReplyPort(clientName));
            clientObj.UserName = clientName;
            MessageBox.Show($"Special reply port: {clientObj.ClientPort}");
            try
            {
                client = new UdpClient(clientObj.ClientPort);
                
                    // reply port / hostname / message
                    byte[] ConnectionData = Encoding.ASCII.GetBytes($"{ConvertNameToReplyPort(clientObj.UserName)}.{clientObj.UserName}.{clientObj.UserName + " Connected!"}.{"new_connection"}");
                    client.Send(ConnectionData, ConnectionData.Length, "127.0.0.1", server.ServerPort);

                    statusStrip1.Text = $"Connected to {server.ServerName}";

                client.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show("MSG:\n" + f.Message + "\nStkStrc:\n" + f.StackTrace, "Issue connecting to server");
            }




        }
        // replyport.hostname.message
        private void SendMessage()
        {
            //MessageBox.Show("Trying to send\n" + $"{ConvertNameToReplyPort(clientObj.UserName)}.{clientObj.UserName}.{textBoxSend.Text}");
            
            client = new UdpClient(clientObj.ClientPort);
            
            byte[] buffer = Encoding.ASCII.GetBytes($"{ConvertNameToReplyPort(clientObj.UserName)}.{clientObj.UserName}.{textBoxSend.Text}");
            client.Send(buffer, buffer.Length, "127.0.0.1", serverObj.ServerPort);
            string[] delimitedData = Encoding.ASCII.GetString(buffer).Split('.');
            listBoxReceive.Items.Add($"[{delimitedData[1]}] {delimitedData[2]}");
            textBoxSend.Clear();
            client.Close();
            
        }
        private void ReceiveMessages()
        {
            // will add in a while


        }
       

        public void UpdateTextArea(string msg)
        {
            MethodInvoker inv = delegate
            {
                listBoxReceive.Items.Add(msg);
            };
            Invoke(inv);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        

        #region Tool strip menu
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionMenu connectionMenu = new ConnectionMenu(this);
            connectionMenu.ShowDialog();
        }

        private void connectionDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Opens settings menu (data capping / throttling / notifications / encryption (maybe server side though) / appearance (Theme..)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void textBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendMessage();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
