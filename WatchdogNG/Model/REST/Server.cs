using SteamNG.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SteamNG.Model.REST
{
    [DataContract]
    public class Server
    {
        /* Properties */
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "serverName")]
        public string ServerName { get; set; }

        [DataMember(Name = "imageUrl")]
        public string ServerImage { get; set; }

        [DataMember(Name = "ipAddress")]
        public string IPAddress { get; set; }

        [DataMember(Name = "gamePort")]
        public int GamePort { get; set; }

        [DataMember(Name = "port")]
        public int Port { get; set; }

        [DataMember(Name = "tsAddress")]
        public string TSAddress { get; set; }

        [DataMember(Name = "tsPort")]
        public int TSPort { get; set; }

        [DataMember(Name = "primaryFtpAddress")]
        public string PrimaryFTPAddress { get; set; }

        [DataMember(Name = "secondaryFtpAddress")]
        public string SecondaryFTPAddress { get; set; }

        [DataMember(Name = "description_ru")]
        public string ServerDescriptionRU { get; set; }

        [DataMember(Name = "description_en")]
        public string ServerDescriptionEN { get; set; }

        /* Constructors */
        public Server() { }

        public Server(ServerData _serverData)
        {
            this.Id = _serverData.idKey;
            this.ServerName = _serverData.serverName;
            this.ServerImage = _serverData.serverImage;
            this.IPAddress = _serverData.ipAddress;
            this.GamePort = _serverData.gamePort;
            this.Port = _serverData.port;
            this.TSAddress = _serverData.tsAddress;
            this.TSPort = _serverData.tsPort;
            this.PrimaryFTPAddress = _serverData.primaryFtpAddress;
            this.SecondaryFTPAddress = _serverData.secondaryFtpAddress;
            this.ServerDescriptionRU = _serverData.serverDescription_ru;
            this.ServerDescriptionEN = _serverData.serverDescription_en;
        }
    }
}
