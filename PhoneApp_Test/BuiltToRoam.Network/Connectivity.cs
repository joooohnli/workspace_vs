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
using System.Threading;
using System.ComponentModel;

namespace BuiltToRoam.Network
{
    public class Connectivity
    {
        public static event EventHandler<ConnectionEventArgs> ConnectivityChanged;

        public static Uri ServiceTestUrl { get; set; }
        public static TimeSpan ServiceTimeout { get; set; }

        private static ConnectionStatus status;
        private static int checkingConnectivity = 0;
        private static WebClient client;
        private static Timer serviceTestTimer;
        private static object serviceLock = new object();

        static Connectivity()   
        {
            Status = ConnectionStatus.Unknown;

            NetworkInfo.Instance.NetworkAddressChanged += NetworkAddressChanged;
            serviceTestTimer = new Timer(ServiceTimeOutCallback, null,
                                        Timeout.Infinite, Timeout.Infinite);
        }

        public static void TestConnectivity()
        {
            if (!DesignerProperties.IsInDesignTool)
            {
                var t = new Thread(UpdateConnectivity);
                t.Start();
            }
        }

        public static ConnectionStatus Status
        {
            get
            {
                return status;
            }
            private set
            {
                if (status == value)
                {
                    return;
                }
                status = value;
                if (ConnectivityChanged != null)
                {
                    ConnectivityChanged(null, new ConnectionEventArgs() { Status = status });
                }
            }
        }

        private static void NetworkAddressChanged(object sender, EventArgs e)
        {
            TestConnectivity();
        }

        private static void UpdateConnectivity()
        {
            if (Interlocked.CompareExchange(ref checkingConnectivity, 1, 0) == 1)
            {
                return;
            }

            var testingService = false;
            try
            {
                var connected = NetworkInfo.Instance.GetIsNetworkAvailable();
                if (connected)
                {
                    if (ServiceTestUrl != null)
                    {
                        lock (serviceLock)
                        {
                            client = new WebClient();
                            client.OpenReadCompleted += WebClient_OpenReadCompleted;
                            serviceTestTimer.Change(ServiceTimeout, ServiceTimeout);
                            testingService = true;
                            client.OpenReadAsync(ServiceTestUrl);
                        }
                    }
                    else
                    {
                        Status = ConnectionStatus.NetWorkAvailable;
                    }
                }
                else
                {
                    Status = ConnectionStatus.Disconnected;
                }
            }
            finally
            {
                if (!testingService)
                {
                    Interlocked.Decrement(ref checkingConnectivity);
                }
            }
        }

        private static void ServiceTimeOutCallback(object state)
        {
            lock (serviceLock)
            {
                serviceTestTimer.Change(Timeout.Infinite, Timeout.Infinite);
                client.CancelAsync();
            }
        }

        static void WebClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            try
            {
                serviceTestTimer.Change(Timeout.Infinite, Timeout.Infinite);

                if (e.Error != null)
                {
                    Status = ConnectionStatus.NetWorkAvailable;
                    return;
                }

                var strm = e.Result;
                var buffer = new byte[1000];

                var cnt = 0;
                while (strm.Position < strm.Length)
                {
                    cnt = strm.Read(buffer, 0, buffer.Length);
                    if (cnt == 0)
                    {
                        break;
                    }
                }

                Status = ConnectionStatus.ServiceReachable |
                         ConnectionStatus.NetWorkAvailable;
            }
            catch (Exception)
            {
                Status = ConnectionStatus.NetWorkAvailable;
            }
            finally
            {
                Interlocked.Decrement(ref checkingConnectivity);
            }
        }
    }

    [Flags()]
    public enum ConnectionStatus
    {
        Unknown = 0,
        NetWorkAvailable = 1,
        ServiceReachable = 2,
        Disconnected = 4
    }

    public class ConnectionEventArgs : EventArgs
    {
        public ConnectionStatus Status { get; set; }
    }
}
