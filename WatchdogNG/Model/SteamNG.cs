using SteamNG.Services;
using SteamNG.Services.Contracts;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace SteamNG.Model
{
    class SteamNG
    {
        /* Properties */


        /* Variables */
        private Uri _statusUri = new Uri(Properties.Settings.Default.bindAddress);

        private WebServiceHost _statusHost;

        /* Constructors */
        public SteamNG()
        {
            OnStart();
        }

        /* Event handlers */
        public void OnStart()
        {
            _statusHost = GetServiceHost(_statusUri, typeof(ServerStatusService), typeof(IServerStatusService));
        }

        public void OnStop ()
        {
            _statusHost.Close();
        }

        /* Methods */
        private WebServiceHost GetServiceHost(Uri serviceUri, Type serviceType, Type contractType)
        {
            var wsHost = new WebServiceHost(serviceType, serviceUri);
            var wsBehaviour = new ServiceMetadataBehavior();

            wsHost.AddServiceEndpoint(contractType, new WebHttpBinding(), serviceUri);
            wsBehaviour.HttpGetEnabled = false;

            wsHost.Description.Behaviors.Add(wsBehaviour);

            ServiceDebugBehavior wsDebugBehaviour = wsHost.Description.Behaviors.Find<ServiceDebugBehavior>();
            wsDebugBehaviour.HttpHelpPageEnabled = false;

            wsHost.Open();

            return wsHost;
        }
    }
}
