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
using System.Diagnostics;

namespace ChatServerUDP
{
    public partial class ServerForm : Form
    {
        List<Client> clients = new List<Client>();
        Client client = default(Client);

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



        Stopwatch serverTime = new Stopwatch();

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            serverTime.Start();
            UpdateServerLog($"Starting server. {DateTime.Now}");
           server = new UdpClient(int.Parse(textBoxServerPort.Text));
            try
            {
                server.BeginReceive(new AsyncCallback(asyncCallBackRecieve), null);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error starting server");
            }


            
        }

        private void UpdateServerLog(string message)
        {
            MethodInvoker inv = delegate
            {
                listBoxServerLog.Items.Add(message);
            };
            Invoke(inv);
        }

        // needs improvement
        
        private void UpdateConnectedClients(Client client)
        {
            MethodInvoker inv = delegate
            {
                listBoxConnectedClients.Items.Add(client);
                labelClientsConnected.Text = listBoxConnectedClients.Items.Count.ToString();
            };
            Invoke(inv);
        }
        Client newClient = default(Client);
        private void asyncCallBackRecieve(IAsyncResult result)
        {
            byte[] received = server.EndReceive(result, ref Address);
            server.BeginReceive(new AsyncCallback(asyncCallBackRecieve), null);
            string[] msg = Encoding.ASCII.GetString(received).Split('.');

            // reply port / hostname / message / [connection data | ( new_connection | disconnected) client_address
           
            if (msg.Length >= 4 && msg[3].Equals("new_connection"))
            {
                newClient = new Client()
                {
                    UserName = msg[1],
                    ClientAddress = IPAddress.Parse(msg[4]),
                    ClientPort = int.Parse(msg[0]),
                    
                };
                UpdateConnectedClients(newClient);
            }
            if(msg.Length >= 4 && msg[3].Equals("disconnecting"))
            {
                MessageBox.Show($"Client disconnected\n{msg[2]} disconnected");
                // fix this
              
            }

            foreach(var client in listBoxConnectedClients.Items)
            {

                Client refClient = client as Client;
                if (!msg[0].Equals(refClient.ClientPort.ToString()))
                {
                    string message = $"[{msg[1]}] {msg[2]}";
                    byte[] buffer = Encoding.ASCII.GetBytes(message);
                    // should be sending to refClient.ClientAddress
                    server.Send(buffer, buffer.Length, new IPEndPoint(IPAddress.Parse("10.0.0.58"), refClient.ClientPort));
                }
            }
            UpdateServerLog($"{msg[1]} : {msg[2]}");
        }

        private void RemoveItemListBoxClients(int index)
        {
            MethodInvoker inv = delegate
            {
                listBoxConnectedClients.Items.RemoveAt(index);
            };
            Invoke(inv);
        }

        // need to setup stop server
        private void btnStopServer_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateServerLog($"Stopping server.{DateTime.Now}");
                UpdateServerLog("Server ran for "+serverTime.Elapsed.Seconds+" seconds");
                serverTime.Stop();

                
                
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
  
        }

        

        private void btnClientInfo_Click(object sender, EventArgs e)
        {
            client = listBoxConnectedClients.SelectedItem as Client;

            if(client != null)
            MessageBox.Show($"USERNAME:{client.UserName}\nAddress\n{client.ClientAddress}:{client.ClientPort}");
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
