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
using System.Threading;

namespace BuiltToRoam.Network
{
    public class EmulatorNetworkInterface : INetWorkInterface
    {
        public class ConnectionTimes
        {
            public bool Connected { get; set; }
            public TimeSpan ConnectionDuration { get; set; }
        }

        public event NetworkAddressChangedEventHandler NetworkAddressChanged;

        private ConnectionTimes[] Times { get; set; }
        private int currentTime = -1;
        private Timer timer;

        public EmulatorNetworkInterface(ConnectionTimes[] connectionTimes)
        {
            Times = connectionTimes;
            //在超过 dueTime 以后及此后每隔 period 指定的时间间隔，都会调用一次此回调方法。
            timer = new Timer(ChangeNetworkStatua, null, Timeout.Infinite, Timeout.Infinite);
            MoveNext();
        }

        public bool GetIsNetworkAvailable()
        {
            return Times[currentTime].Connected;
        }

        private void ChangeNetworkStatua(object state)
        {
            MoveNext();
        }

        private void MoveNext()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            currentTime = (currentTime + 1) % Times.Length;
            var connection = Times[currentTime];

            if (NetworkAddressChanged != null)
            {
                NetworkAddressChanged(null, EventArgs.Empty);//无法捕获sender啊！
            }

            timer.Change(connection.ConnectionDuration, connection.ConnectionDuration);
        }
    }
}
