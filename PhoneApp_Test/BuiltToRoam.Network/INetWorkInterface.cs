using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace BuiltToRoam.Network
{
    public interface INetWorkInterface
    {
        event NetworkAddressChangedEventHandler NetworkAddressChanged;

        bool GetIsNetworkAvailable();
    }
}
