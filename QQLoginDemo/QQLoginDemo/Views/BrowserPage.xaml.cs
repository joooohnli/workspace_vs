using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace QQLoginDemo.Views
{
    public partial class BrowserPage : PhoneApplicationPage
    {
        public BrowserPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.Count > 0)
            {
                String urlString = "";
                if (NavigationContext.QueryString["WebName"].Equals("register"))
                {
                    urlString = "http://www.baidu.com";
                }
                else if (NavigationContext.QueryString["WebName"].Equals("suggest"))
                {
                    urlString = "http://www.google.com";
                }

                else if (NavigationContext.QueryString["WebName"].Equals("forum"))
                {
                    urlString = "http://www.bing.com";
                }
                else if (NavigationContext.QueryString["WebName"].Equals("newfeatures"))
                {
                    urlString = "http://www.yahoo.com";
                }
                webBrowser.Navigate(new Uri(urlString));
            }
        }
    }
}