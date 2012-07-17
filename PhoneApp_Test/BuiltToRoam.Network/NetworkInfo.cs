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
using System.ComponentModel;

namespace BuiltToRoam.Network
{
    public class NetworkInfo
    {
        public readonly static INetWorkInterface Instance;

        static NetworkInfo()//不带访问修饰符的static构造函数是什么意思？->C#语法，没有访问修饰符也没有参数,创建第一个类实例或任何静态成员被引用时
        {
            if (!DesignerProperties.IsInDesignTool)//这一点很重要，因为在设计时编译器无法解析System.Environment.DeviceType
            {
                Instance = PickRuntimeNetworkInterface();
            }
            else
            {
                Instance = CreateEmulatorInterface();
            }
        }

        private static INetWorkInterface PickRuntimeNetworkInterface()
        {
            if (Microsoft.Devices.Environment.DeviceType == Microsoft.Devices.DeviceType.Device)
            {
                return new DeviceNetworkInterface();
            }
            else
            {
                return CreateEmulatorInterface();
            }
        }

        private static INetWorkInterface CreateEmulatorInterface()
        {
            return new EmulatorNetworkInterface(
                new EmulatorNetworkInterface.ConnectionTimes[]
                {
                    new EmulatorNetworkInterface.ConnectionTimes()
                    {
                        Connected = true, ConnectionDuration = new TimeSpan(0, 0,1)
                    },
                    new EmulatorNetworkInterface.ConnectionTimes()
                    {
                        Connected = true, ConnectionDuration = new TimeSpan(0, 0, 5)
                    },
                    new EmulatorNetworkInterface.ConnectionTimes()
                    {
                        Connected = false, ConnectionDuration = new TimeSpan(0, 0, 5)
                    },
                    new EmulatorNetworkInterface.ConnectionTimes()
                    {
                        Connected = true, ConnectionDuration = new TimeSpan(0, 0, 2)
                    },
                    new EmulatorNetworkInterface.ConnectionTimes()
                    {
                        Connected = false, ConnectionDuration = new TimeSpan(0, 0, 5)
                    },
                    new EmulatorNetworkInterface.ConnectionTimes()
                    {
                        Connected = true, ConnectionDuration = new TimeSpan(0, 0, 2)
                    },
                    new EmulatorNetworkInterface.ConnectionTimes()
                    {
                        Connected = false, ConnectionDuration = new TimeSpan(0, 0, 8)
                    },
                    new EmulatorNetworkInterface.ConnectionTimes()
                    {
                        Connected = false, ConnectionDuration = new TimeSpan(0, 0, 5)
                    },
                    new EmulatorNetworkInterface.ConnectionTimes()
                    {
                        Connected = true, ConnectionDuration = new TimeSpan(0, 0, 3)
                    }
                });
        }
    }
}
