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
        // global udpclient instance
        UdpClient udpClient;
        // get localhost ip address
        IPAddress HostIP = Dns.GetHostEntry("localhost").AddressList[0];
        // for receiving
        //IPEndPoint clientEndPoint;

        public Form1()
        {
            InitializeComponent();
        }

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
            // will need to be a little more random (or less)
            string tmp = sb.ToString().Substring(0, 1) + sb.ToString().Substring(sb.ToString().Length - 3);
            return tmp;
        }

        Client clientObj = default(Client);
        Server serverObj = default(Server);

        /// <summary>
        /// Connect to a server
        /// </summary>
        /// <param name="server">
        /// server object that contains the parameters to the server
        /// </param>
        /// <param name="clientName">
        /// clients username, used in creating the reply port
        /// </param>
        public void ConnectToServer(Server server, string clientName)
        {
            MessageBox.Show("Connecting to server:\n" + server);
            // will need to check that the client name is atleast 4 charaters long
            clientObj = new Client();
            serverObj = server;
            clientObj.ClientPort = int.Parse(ConvertNameToReplyPort(clientName));
            // could be source to issue with remote connection
            clientObj.ClientAddress = HostIP;
            clientObj.UserName = clientName;
            MessageBox.Show($"Special reply port: {clientObj.ClientPort}\nClient info: {clientObj}");
            try
            {
                // provides our local port
                // changed constructor for udp client from clientobj.clientport to localhost
                udpClient = new UdpClient(AddressFamily.InterNetwork);
                
                    // reply port / hostname / message / [connection data | ( new_connection | disconnected)] / client_address 
                    byte[] ConnectionData = Encoding.ASCII.GetBytes($"{clientObj.ClientPort}.{clientObj.UserName}.{clientObj.UserName + " Connected!"}.{"new_connection"}.{clientObj.ClientAddress}");
                MessageBox.Show($"{clientObj.ClientPort}.{clientObj.UserName}.{clientObj.UserName + " Connected!"}\n.{"new_connection"}.{clientObj.ClientAddress}");
                    // bytes / bytes length / to server address / at the server port
                    udpClient.Send(ConnectionData, ConnectionData.Length, serverObj.ServerAddress.ToString(), server.ServerPort);
               udpClient.Close();

                toolStripStatusLabel.Text = $"Connected to {server.ServerName}";

                
            }
            catch (Exception f)
            {
                MessageBox.Show("MSG:\n" + f.Message + "\nStkStrc:\n" + f.StackTrace, "Issue connecting to server");
            }


            ReceiveMessages();

        }

       

        #region Asynchronous send
        /// <summary>
        /// Data will be send in the following order:
        /// replyport.hostname.message | .new_connection | diconnected .address
        /// </summary>
        private void SendMessage()
        {
            UdpClient sendClient = new UdpClient();
            

            byte[] buffer = Encoding.ASCII.GetBytes($"{ConvertNameToReplyPort(clientObj.UserName)}.{clientObj.UserName}.{textBoxSend.Text}");

            MessageBox.Show($"Sending: {serverObj.ServerAddress.ToString()},\n{serverObj.ServerPort}");
            sendClient.Send(buffer, buffer.Length, serverObj.ServerAddress.ToString(), serverObj.ServerPort);
            string[] delimitedData = Encoding.ASCII.GetString(buffer).Split('.');
            listBoxReceive.Items.Add($"[{delimitedData[1]}] {delimitedData[2]}");
            udpClient.Close();

            textBoxSend.Clear();

        }
       

        #endregion
        // Make this asynchronous

        #region Asynchronous reply
            UdpClient receiveUdpClient = default(UdpClient);
        private void ReceiveMessages()
        {
            receiveUdpClient = new UdpClient(clientObj.ClientPort);
            receiveUdpClient.BeginReceive(new AsyncCallback(asyncCallbackReply), null);
            
        }

        private void asyncCallbackReply(IAsyncResult res)
        {
            IPEndPoint serverAddress = new IPEndPoint(serverObj.ServerAddress, serverObj.ServerPort);
            byte[] receivedData = receiveUdpClient.EndReceive(res, ref serverAddress);
            receiveUdpClient.BeginReceive(asyncCallbackReply, null);
            UpdateTextArea(Encoding.ASCII.GetString(receivedData));
        }
        #endregion


        /// <summary>
        /// Update received text area outside the thread
        /// </summary>
        /// <param name="msg"></param>
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
           udpClient = new UdpClient();
            // reply port / hostname / message
            byte[] ConnectionData = Encoding.ASCII.GetBytes($"{ConvertNameToReplyPort(clientObj.UserName)}.{clientObj.UserName}.{clientObj.UserName + " disconnected!"}.{"disconnecting"}");
            udpClient.Send(ConnectionData, ConnectionData.Length, serverObj.ServerAddress.ToString(), serverObj.ServerPort);
            MessageBox.Show($"Sending: {serverObj.ServerAddress.ToString()},\n{serverObj.ServerPort}");
            udpClient.Close();

        }

        #endregion

        /// <summary>
        /// Do some clean up prior to closing the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        /// <summary>
        /// allow for enter to be pressed in the text box to send data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
