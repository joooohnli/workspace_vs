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
using System.Net.NetworkInformation;

namespace BuiltToRoam.Network
{
    public class DeviceNetworkInterface : INetWorkInterface
    {
        public event NetworkAddressChangedEventHandler NetworkAddressChanged;

        public DeviceNetworkInterface()
        {
            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
        }

        private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            if (NetworkAddressChanged != null)
            {
                NetworkAddressChanged(sender, e);
            }
        }

        public bool GetIsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}
