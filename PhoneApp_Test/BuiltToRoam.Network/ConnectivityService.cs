using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace BuiltToRoam.Network
{
    public class ConnectivityService : IApplicationService
    {
        public Uri ServiceTestUrl { get; set; }
        public TimeSpan ServiceTimeout { get; set; }

        public void StartService(ApplicationServiceContext context)
        {
            Connectivity.ServiceTestUrl = this.ServiceTestUrl;
            Connectivity.ServiceTimeout = this.ServiceTimeout;
            Connectivity.TestConnectivity();
            Debug.WriteLine("test");
        }

        public void StopService()
        {
        }
    }
}
