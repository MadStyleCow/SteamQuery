using SteamNG.Model;
using SteamNG.Model.REST;
using SteamNG.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Transactions;
using System.Threading.Tasks;

namespace SteamNG.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    class ServerStatusService : IServerStatusService
    {
        /* Private methods */
        async private Task<ServerStatus> GetServerInfo(Server _serverEntry)
        {
            try
            {
                QueryMaster.GameServer.Server serverQuery = 
                    QueryMaster.GameServer.ServerQuery.GetServerInstance(
                        QueryMaster.EngineType.Source,
                        new IPEndPoint(IPAddress.Parse(_serverEntry.IPAddress),
                        _serverEntry.Port), false, 2500, 2500, 1);

                QueryMaster.GameServer.ServerInfo serverInfo = serverQuery.GetInfo();

                if (serverInfo != null)
                {
                    var result = new ServerStatus()
                    {
                        Map = serverInfo.Description,
                        World = serverInfo.Map,
                        Online = true,
                        Players = serverInfo.Players,
                        MaxPlayers = serverInfo.MaxPlayers
                    };

                    return result;
                }
                else
                {
                    return new ServerStatus() { Online = false };
                }
            }
            catch (Exception)
            {
                return new ServerStatus() { Online = false };
            }
        }

        async private Task<FtpStatus> GetFtpInfo(Server _serverEntry)
        {
            try
            {
                FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri(_serverEntry.PrimaryFTPAddress));
                requestDir.Timeout = 5000;
                requestDir.Method = WebRequestMethods.Ftp.ListDirectory;

                WebResponse response = await requestDir.GetResponseAsync();
                return new FtpStatus { Online = true };

            }
            catch (Exception)
            {
                return new FtpStatus { Online = false };
            }
        }

        /* Service methods */
        public void GetOptions()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "GET, OPTIONS");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
        }

        public List<Server> GetServers()
        {
            try
            {
                // Allow all origins
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Type", "application/json; charset=utf-8");

                // Return list of servers
                return ServerProvider.Instance.GetServers();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public ServerStatus GetServerStatus(int idKey)
        {
            try {
                // Allow all origins
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Type", "application/json; charset=utf-8");

                var serverTask = GetServerInfo(ServerProvider.Instance.GetServer(idKey));

                serverTask.Wait();

                return serverTask.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public FtpStatus GetFtpStatus(int idKey)
        {
            try
            {
                // Allow all origins
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Type", "application/json; charset=utf-8");

                var ftpTask = GetFtpInfo(ServerProvider.Instance.GetServer(idKey));

                ftpTask.Wait();

                return ftpTask.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}