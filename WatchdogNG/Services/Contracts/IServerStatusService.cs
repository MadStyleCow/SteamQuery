using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using SteamNG.Model.REST;

namespace SteamNG.Services.Contracts
{
    [ServiceContract]
    public interface IServerStatusService
    {
        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Server> GetServers();

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
        ServerStatus GetServerStatus(Int32 idKey);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
        FtpStatus GetFtpStatus(Int32 idKey);

        [OperationContract, WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void GetOptions();
    }
}
