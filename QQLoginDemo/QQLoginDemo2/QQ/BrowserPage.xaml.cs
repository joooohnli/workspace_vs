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
using Microsoft.Phone.Shell;

namespace QQLoginDemo2.QQ
{
    public partial class BrowserPage : PhoneApplicationPage
    {
        private WebBrowser webBrowser;
        public BrowserPage()
        {
            InitializeComponent();
            webBrowser = new WebBrowser();
            LayoutRoot.Children.Add(webBrowser);

            InitializeApplicationBar();
        }

        private void InitializeApplicationBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.BackgroundColor = Color.FromArgb(255, 86, 166, 216);
            //System.Drawing.Color.FromKnownColor("White");   System.Drawing无法引用？
            ApplicationBar.ForegroundColor = Color.FromArgb(255, 255, 255, 255);
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;

            ApplicationBarIconButton appBar_button_back = new ApplicationBarIconButton();
            appBar_button_back.IconUri = new Uri("/Images/back.png", UriKind.Relative);
            appBar_button_back.Text = "后退";
            ApplicationBar.Buttons.Add(appBar_button_back);

            ApplicationBarIconButton appBar_button_next = new ApplicationBarIconButton();
            appBar_button_next.IconUri = new Uri("/Images/next.png", UriKind.Relative);
            appBar_button_next.Text = "前进";
            ApplicationBar.Buttons.Add(appBar_button_next);

            ApplicationBarIconButton appBar_button_sync = new ApplicationBarIconButton();
            appBar_button_sync.IconUri = new Uri("/Images/sync.png", UriKind.Relative);
            appBar_button_sync.Text = "刷新";
            ApplicationBar.Buttons.Add(appBar_button_sync);

            ApplicationBarIconButton appBar_button_stop = new ApplicationBarIconButton();
            appBar_button_stop.IconUri = new Uri("/Images/stop.png", UriKind.Relative);
            appBar_button_stop.Text = "停止";
            ApplicationBar.Buttons.Add(appBar_button_stop);
            //appBar_button_help.Click += new EventHandler(appBar_button_help_Click);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.Count > 0)
            {
                String urlString = "http://ww.qq.com";
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