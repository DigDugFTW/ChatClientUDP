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
using System.Threading;
namespace ChatServerUDP
{
    public partial class ServerForm : Form
    {
        

        /*
         * For both the client and the server the following issues need to be resolved:
         * renegade threads
         * proper start / stopping of threads
         * the server needs to keep track of each client, possibly via the ClientID property.
         * server needs to be able to see a live list of all the connected clients
         */

        UdpClient server = default(UdpClient);
        IPEndPoint Address = new IPEndPoint(IPAddress.Any, 0);
        public ServerForm()
        {
            InitializeComponent();
        }
        
        private Thread ServerThread;

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            
            UpdateServerLog("Starting server..");
           server = new UdpClient(int.Parse(textBoxServerPort.Text));

            ServerThread = new Thread(() => StartServer());
            ServerThread.Start();
        }

        private void UpdateServerLog(string message)
        {
            MethodInvoker inv = delegate
            {
                listBoxServerLog.Items.Add(message);
            };
            Invoke(inv);
        }

        private void UpdateClientsConnectedLabel(bool decrement)
        {
            int connectedClients = 0;
            MethodInvoker inv = delegate
            {
                labelClientsConnected.Text = (++connectedClients).ToString();
                if (decrement && --connectedClients >= 0)
                    --connectedClients;

            };
            Invoke(inv);
        }

        private void StartServer()
        {
            
            while (true)
            {

                

                UpdateServerLog("Waiting for messages");
                byte[] buffer = server.Receive(ref Address);
                // replyport.hostname.message
                string[] msg = Encoding.ASCII.GetString(buffer).Split('.');
                
                if(msg.Length == 4)
                {
                    UpdateClientsConnectedLabel(false);
                }
                UpdateServerLog(msg[1] + " => " + msg[2]);

            }
            
        }

        // need to setup stop server
        private void btnStopServer_Click(object sender, EventArgs e)
        {
            
            
            UpdateServerLog($"Stopping server..");
            
            
            UpdateServerLog(ServerThread.IsAlive ? $"Failure" : $"Success");
            
        }
    }
}
