using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatClientUDP
{
   public class Server : Client
    {
        
        public Server(string serverName, string clientName, IPEndPoint serverAddress)
        {
            ServerName = serverName;
            ConnectedClient = clientName;
            ServerAddress = serverAddress.Address;
            ServerPort = serverAddress.Port;
        }

        private List<Client> clientList = new List<Client>();

        #region Server Properties
        public string ConnectedClient
        {
            set;
            get;
        }
        public string ServerName
        {
            set;
            get;
        }

        public int ClientCount
        {
            set; get;
        } = 0;

        /// <summary>
        /// mutable property about the servers information
        /// </summary>
        public IPAddress ServerAddress
        {
            set; get;
        }
        public int ServerPort
        {
            set; get;
        }

        /// <summary>
        /// mutable array of clients
        /// </summary>
        public List<Client> ClientList
        {
             get;
        }
        #endregion

        #region Edit client list
        /// <summary>
        /// Accessor to the client list
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            clientList.Add(client);
        }



        public bool RemoveClient(Client client)
        {
            return clientList.Remove(client);
        }
        #endregion

        public override string ToString()
        {
            return $"[{ServerName}] {ServerAddress}:{ServerPort} | {ClientCount}";
        }

    }
}
