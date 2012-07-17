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

namespace BuiltToRoam.Network
{
    public class BindableConnectivity : DependencyObject
    {
        public ConnectionStatus Status
        {
            get { return (ConnectionStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(ConnectionStatus),
                                    typeof(BindableConnectivity),
                                    new PropertyMetadata(ConnectionStatus.Unknown));

        public bool NetworkAvailable
        {
            get { return (bool)GetValue(NetworkAvailableProperty); }
            set { SetValue(NetworkAvailableProperty, value); }
        }

        public static readonly DependencyProperty NetworkAvailableProperty =
            DependencyProperty.Register("NetworkAvailable", typeof(bool),
                                    typeof(BindableConnectivity),
                                    new PropertyMetadata(false));

        public bool ServiceReachable
        {
            get { return (bool)GetValue(ServiceReachableProperty); }
            set { SetValue(ServiceReachableProperty, value); }
        }

        public static readonly DependencyProperty ServiceReachableProperty =
            DependencyProperty.Register("ServiceReachableProperty", typeof(bool),
                                    typeof(BindableConnectivity),
                                    new PropertyMetadata(false));

        public bool Disconnected
        {
            get { return (bool)GetValue(DisconnectedProperty); }
            set { SetValue(DisconnectedProperty, value); }
        }

        public static readonly DependencyProperty DisconnectedProperty =
            DependencyProperty.Register("DisconnectedProperty", typeof(bool),
                                    typeof(BindableConnectivity),
                                    new PropertyMetadata(false));

        public BindableConnectivity()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            UpdateStatus(Connectivity.Status);
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectionEventArgs e)
        {
            UpdateStatus(e.Status);
        }

        private void UpdateStatus(ConnectionStatus connectionStatus)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.Status = connectionStatus;
                this.NetworkAvailable = (this.Status & ConnectionStatus.NetWorkAvailable) > 0;
                this.ServiceReachable = (this.Status & ConnectionStatus.ServiceReachable) > 0;
                this.Disconnected = (this.Status & ConnectionStatus.Disconnected) > 0;
            });
        }
    }
}
