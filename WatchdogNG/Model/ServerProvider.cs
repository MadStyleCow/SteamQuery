using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamNG.DataModel;
using SteamNG.Model.REST;
using SteamNG.Utilities;
using System.IO;

namespace SteamNG.Model
{
    public class ServerProvider
    {
        /* Variables */
        private static ServerProvider instance;
        private static ServerList list;

        /* Properties */
        public static ServerProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerProvider();
                }

                return instance;
            }
        }

        public static ServerList List
        {
            get
            {
                if(list == null)
                {
                    list = (ServerList)XMLSerializer.DeserializeFromFile(Properties.Settings.Default.dataFileLocation, typeof(ServerList));
                }
                return list;
            }
        }

        /* Constructors */
        private ServerProvider() { }

        /* Singleton methods */
        public List<Server> GetServers()
        {
            var resultList = new List<Server>();

            foreach(ServerData _server in List.serverList)
            {
                resultList.Add(new Server(_server));
            }

            return resultList;
        }

        public Server GetServer(int _idKey)
        { 
            return new Server(List.serverList.Find(t => t.idKey == _idKey));
        }
    }
}
