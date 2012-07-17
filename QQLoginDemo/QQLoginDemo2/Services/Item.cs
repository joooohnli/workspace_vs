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

namespace QQLoginDemo2.Services
{
    public class Item
    {
        public string Header { set; get; }

        public Item(string header)
        {
            this.Header = header;
        }
    }
}
