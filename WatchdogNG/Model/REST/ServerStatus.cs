using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SteamNG.Model.REST
{
    [DataContract]
    public class ServerStatus
    {
        /* Properties */
        [DataMember(Name = "online")]
        public bool Online { get; set; }

        [DataMember(Name = "map")]
        public string Map { get; set; }

        [DataMember(Name = "world")]
        public string World { get; set; }

        [DataMember(Name = "players")]
        public int Players { get; set; }

        [DataMember(Name = "maxPlayers")]
        public int MaxPlayers { get; set; }

        /* Constructors */
        public ServerStatus() { }
    }
}
