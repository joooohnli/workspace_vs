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
using System.Collections.ObjectModel;

namespace QQLoginDemo2.Services
{
    public class LoginPivotItems
    {
        public ObservableCollection<Item> Items { set; get; }
        
        public LoginPivotItems()
        {
            this.Items = new ObservableCollection<Item>();
            Items.Add(new Item("登陆"));
            Items.Add(new Item("设置"));
        }
    }
}
