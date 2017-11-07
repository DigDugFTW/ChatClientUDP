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
        public Server(string serverName, IPEndPoint serverAddress)
        {
            ServerName = serverName;
            ServerAddress = serverAddress.Address;
            ServerPort = serverAddress.Port;
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

        private List<Client> clientList = new List<Client>();

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

        public override string ToString()
        {
            return $"[{ServerName}] {ServerAddress}:{ServerPort} | {ClientCount}";
        }

    }
}
