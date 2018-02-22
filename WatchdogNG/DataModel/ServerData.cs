using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamNG.DataModel
{
    [Serializable]
    public class ServerData
    {
        /* Properties */
        public int idKey { get; set; }
        
        public string serverName { get; set; }
        public string serverImage { get; set; }

        public string ipAddress { get; set; }
        public int gamePort { get; set; }
        public int port { get; set; }

        public string tsAddress { get; set; }
        public int tsPort { get; set; }

        public string primaryFtpAddress { get; set; }
        public string secondaryFtpAddress { get; set; }

        public string serverDescription_ru { get; set; }
        public string serverDescription_en { get; set; }

        /* Constructor */
        public ServerData() { }
    }
}
