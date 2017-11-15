using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatServerUDP
{
   public class Client
    {
        private IPAddress clientAddress = default(IPAddress);

        #region Client Properties

        public long ClientID { private set; get; } = 0;
        private string[] MiscClientData
        {
            set;
            get;
        } 
        
        public IPAddress ClientAddress
        {

            set => clientAddress = value;

            get
            {
                if (clientAddress != null)
                    return clientAddress;

                 throw new Exception("Address was not specified before calling");
            }
        }
        public int ClientPort
        {
            set;
            get;
        }

        public string UserName
        {
            set;
            get;
        } = "noname";

        #endregion

        /// <summary>
        /// Client constructor with misc data parameter
        /// 
        /// </summary>
        /// <param name="username">
        /// client username used in connection
        /// </param>
        /// <param name="clientAddr">
        /// client internet protocol end point (address and port)
        /// </param>
        /// <param name="miscData">
        /// misselanious data on the client, eg: wants admin permissions (server will confirm)
        /// </param>
        /// <param name="clientID">
        /// Unique ID tied to the client 
        /// </param>
        public Client(string username, IPEndPoint clientAddr, long clientID, string[] miscData)
        {
            UserName = username;
            ClientPort = clientAddr.Port;
            ClientAddress = clientAddr.Address;
            ClientID = clientID;
            MiscClientData = miscData;
        }
        public Client(string username, IPEndPoint clientAddr, long clientID)
        {
            UserName = username;
            ClientPort = clientAddr.Port;
            ClientAddress = clientAddr.Address;
            ClientID = clientID;
        }
        public Client() { }

        /// <summary>
        /// Returns data on the client object
        /// </summary>
        /// <returns>
        /// Returns interpolated string data on client and client connection data
        /// </returns>
        public override string ToString()
        { 
            return $"Name:[{UserName}]Address:[{ClientAddress}]Port:[{ClientPort}]ID:[{ClientID}]";
        }

        /// <summary>
        /// Returns data on client object in array format
        /// </summary>
        /// <returns>
        /// returns data on client index [0 = username, 1 = clientaddress]
        /// </returns>
        public string[] ClientData()
        {
            return new string[] {UserName, ClientAddress.ToString() };
        }
    }
}
