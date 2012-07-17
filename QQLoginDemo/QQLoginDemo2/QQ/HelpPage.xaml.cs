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

namespace QQLoginDemo2.QQ
{
    public partial class HelpPage : PhoneApplicationPage
    {
        public HelpPage()
        {
            InitializeComponent();
            StackPanel stp = new StackPanel();
            stp.Children.Add(new TextBlock
            {
                Text = "帮助页",
                FontSize = 40,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 109, 187, 242)),
                Padding = new Thickness(0, 40, 0, 70),
            });
            stp.Children.Add(new HyperlinkButton
            {
                Content = "反馈意见",
                FontSize = 30,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 109, 180, 252)),
                NavigateUri = new Uri("/QQ/BrowserPage.xaml?WebName=suggest", UriKind.Relative),
            });
            stp.Children.Add(new HyperlinkButton
            {
                Content = "官方论坛",
                FontSize = 30,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 109, 180, 252)),
                NavigateUri = new Uri("/QQ/BrowserPage.xaml?WebName=forum", UriKind.Relative),
            });
            stp.Children.Add(new HyperlinkButton
            {
                Content = "新功能介绍",
                FontSize = 30,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 109, 180, 252)),
                NavigateUri = new Uri("/QQ/BrowserPage.xaml?WebName=newfeatures", UriKind.Relative),
            });
            LayoutRoot.Children.Add(stp);
        }
    }
}