using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamNG.DataModel
{
    [Serializable]
    public class ServerList
    {
        /* Properties */
        public List<ServerData> serverList { get; set; }

        /* Constructor */
        public ServerList() { }
    }
}
