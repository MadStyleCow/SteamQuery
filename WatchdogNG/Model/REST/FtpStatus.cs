using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SteamNG.Model.REST
{
    [DataContract]
    public class FtpStatus
    {
        /* Properties */
        [DataMember(Name = "online")]
        public bool Online { get; set; }

        /* Constructors */
        public FtpStatus() { }
    }
}
