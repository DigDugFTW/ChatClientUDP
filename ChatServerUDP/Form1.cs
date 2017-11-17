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
        private List<Client> _clients = new List<Client>();
        private Client _client = default(Client);

        /*
         * For both the client and the server the following issues need to be resolved:
         * renegade threads
         * proper start / stopping of threads
         * the server needs to keep track of each client, possibly via the ClientID property.
         * server needs to be able to see a live list of all the connected clients
         */

        private UdpClient _server = default(UdpClient);
        private IPEndPoint _address = new IPEndPoint(IPAddress.Any, 0);
        public ServerForm()
        {
            InitializeComponent();
        }



        private readonly Stopwatch _serverTime = new Stopwatch();

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            _serverTime.Start();
            UpdateServerLog($"Starting server. {DateTime.Now}");
           _server = new UdpClient(int.Parse(textBoxServerPort.Text));
            try
            {
                _server.BeginReceive(new AsyncCallback(AsyncCallBackRecieve), null);
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

        private void AsyncCallBackRecieve(IAsyncResult result)
        {
            byte[] received = _server.EndReceive(result, ref _address);
            
            _server.BeginReceive(new AsyncCallback(AsyncCallBackRecieve), null);
            string[] msg = Encoding.ASCII.GetString(received).Split('&');

            // reply port / hostname / message / [connection data | ( new_connection | disconnected) client_address

            if (msg.Length >= 4 && msg[3].Equals("new_connection"))
            {
                newClient = new Client()
                {
                    UserName = msg[1],
                    ClientAddress = _address.Address,
                    ClientPort = int.Parse(msg[0]),
                    
                };
                UpdateConnectedClients(newClient);
            }
            if(msg.Length >= 4 && msg[3].Equals("disconnecting"))
            {
                var message = $"Client disconnected\n{msg[2]} disconnected";
                UpdateServerLog(message);
               
              
            }

            foreach(var client in listBoxConnectedClients.Items)
            {

                var refClient = client as Client;
                if (refClient != null && msg[0].Equals(refClient.ClientPort.ToString())) continue;
                var message = $"[{msg[1]}] {msg[2]}";
                var buffer = Encoding.ASCII.GetBytes(message);
                // should be sending to refClient.ClientAddress
                _server.Send(buffer, buffer.Length, new IPEndPoint(refClient.ClientAddress, refClient.ClientPort));
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
                UpdateServerLog($"Server ran for {_serverTime.Elapsed.Days} Days, {_serverTime.Elapsed.Hours} Hours and {_serverTime.Elapsed.Minutes}");
                _serverTime.Stop();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
  
        }

        

        private void btnClientInfo_Click(object sender, EventArgs e)
        {
            _client = listBoxConnectedClients.SelectedItem as Client;

            if (_client == null) return;
            var message = $"USERNAME:{_client.UserName}\nAddress{_client.ClientAddress}:{_client.ClientPort}";
            MessageBox.Show(message);
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
