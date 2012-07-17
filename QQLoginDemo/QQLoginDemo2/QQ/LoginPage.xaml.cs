using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QQLoginDemo2.Services;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace QQLoginDemo2.QQ
{
    public partial class LoginPage : PhoneApplicationPage
    {
        //这样写界面，-.-
        public LoginPage()
        {
            InitializeComponent();
            //Loaded +=
            //    (sender, args) =>
            InitializePivot();
        }

        private void InitializePivot()
        {
            Pivot pivotLogin = new Pivot();
            pivotLogin.Foreground = new SolidColorBrush(Color.FromArgb(255, 109, 187, 242));
            StackPanel stpTmp = new StackPanel { Orientation = System.Windows.Controls.Orientation.Horizontal };
            Image image_pivotTitle = new Image
            {
                Source = new BitmapImage(new Uri("/Images/pivotTitle.png", UriKind.Relative)),
                Opacity = 0.5,
            };
            TextBlock txtBlock_pivotTitle = new TextBlock
            {
                Text = "手机QQ",
                Foreground = new SolidColorBrush(Color.FromArgb(255, 147, 209, 239)),
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                FontWeight = FontWeights.Light,
            };
            stpTmp.Children.Add(image_pivotTitle);
            stpTmp.Children.Add(txtBlock_pivotTitle);
            pivotLogin.Title = stpTmp;

            PivotItem itemLogin = new PivotItem
            {
                Header = "登陆",
                Padding = new Thickness(10, 0, 10, 0),
            };
            PivotItem itemSetting = new PivotItem
            {
                Header = "设置",
                Padding = new Thickness(10, 0, 10, 0)
            };
            itemLogin.Content = InitializeLoginItem();
            itemSetting.Content = InitializeSettingItem();
            pivotLogin.Items.Add(itemLogin);
            pivotLogin.Items.Add(itemSetting);
            pivotLogin.SelectionChanged += pivotLogion_SelectionChanged;

            LayoutRoot.Children.Add(pivotLogin);
        }

        private Object InitializeLoginItem()
        {
            StackPanel stpLogin = new StackPanel();
            //#FFA39797
            stpLogin.Children.Add(new TextBlock
            {
                Text = "帐号",
                Foreground = new SolidColorBrush(Color.FromArgb(255, 163, 151, 151)),
            });
            StackPanel stpTmp = new StackPanel
            {
                Orientation = System.Windows.Controls.Orientation.Horizontal,
                Background = new SolidColorBrush(Color.FromArgb(191, 226, 226, 226)),
                Margin = new Thickness(18, 0, 17, 13),
                Width = 421,
                Height = 58,
            };
            Image imageTile = new Image
            {
                Source = new BitmapImage(new Uri("/Images/tile.png", UriKind.Relative)),
                Width = 55,
                Height = 55
            };
            TextBox txtBoxID = new TextBox
            {
                Background = new SolidColorBrush(Colors.Transparent),
                BorderBrush = new SolidColorBrush(Color.FromArgb(191, 226, 226, 226)),
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                //InputScope = InputScopeNameValue.Digits,
                Height = 85,
                Width = 400,
            };
            stpTmp.Children.Add(imageTile);
            stpTmp.Children.Add(txtBoxID);
            stpLogin.Children.Add(stpTmp);

            stpLogin.Children.Add(new TextBlock
            {
                Text = "密码",
                Foreground = new SolidColorBrush(Color.FromArgb(255, 163, 151, 151)),
            });
            stpLogin.Children.Add(new PasswordBox
            {
                Background = new SolidColorBrush(Color.FromArgb(191, 226, 226, 226)),
                Height = 85,
            });
            Button btnConfirm = new Button();
            btnConfirm.Content = "确认";
            btnConfirm.Height = 85;
            btnConfirm.Background = new SolidColorBrush(Color.FromArgb(255, 65, 162, 229));
            btnConfirm.Foreground = new SolidColorBrush(Colors.White);
            btnConfirm.BorderBrush = new SolidColorBrush(Colors.Transparent);
            btnConfirm.Click += BtnConfirm_Click;
            stpLogin.Children.Add(btnConfirm);
            StackPanel stpTemp = new StackPanel { Orientation = System.Windows.Controls.Orientation.Horizontal };
            stpTemp.Children.Add(new CheckBox
            {
                Content = "记住我            ",
                Background = new SolidColorBrush(Color.FromArgb(191, 98, 148, 196)),
                FontSize = 27,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
            });
            stpTemp.Children.Add(new HyperlinkButton
            {
                Content = "注册新帐号",
                Foreground = new SolidColorBrush(Color.FromArgb(255, 50, 120, 229)),
                FontSize = 27,
                NavigateUri = new Uri("/QQ/BrowserPage.xaml?WebName=register", UriKind.Relative)
            });
            stpLogin.Children.Add(stpTemp);

            return stpLogin;
        }

        private Object InitializeSettingItem()
        {
            StackPanel stpSetting = new StackPanel();
            stpSetting.Children.Add(new TextBlock
            {
                Text = "您可以在这里进行软件设置，还可以管理登陆过的帐号",
                //FF5684CB
                TextWrapping = System.Windows.TextWrapping.Wrap,
                FontSize = 20,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 86, 132, 203)),
                Padding = new Thickness(0, 0, 0, 15)
            });
            stpSetting.Children.Add(new ToggleSwitch
            {
                Header = new TextBlock
                {
                    Text = "隐身登录",
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Colors.Black),
                },
                FontSize = 22,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 163, 151, 151)),
                Background = new SolidColorBrush(Colors.Blue),
                //OnContent OffContent Toggled  --all invalid! why??
                //Toggled += ToggleSwitch_Hidding_Toggled,
            });
            stpSetting.Children.Add(new ToggleSwitch
            {
                Header = new TextBlock
                {
                    Text = "声音提示",
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Colors.Black),
                },
                FontSize = 22,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 163, 151, 151)),
                Background = new SolidColorBrush(Colors.Blue),
            });
            stpSetting.Children.Add(new ToggleSwitch
            {
                Header = new TextBlock
                {
                    Text = "消息振动",
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Colors.Black),
                },
                FontSize = 22,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 163, 151, 151)),
                Background = new SolidColorBrush(Colors.Blue),
            });
            return stpSetting;
        }

        private void pivotLogion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    ApplicationBar = null;
                    break;
                case 1:
                    ApplicationBar = ((ApplicationBar)Application.Current.Resources["AppBar_Setting"]);
                    break;
            }
            //将焦点转移到页面上
            this.Focus();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("登陆成功");
        }

        private void ToggleSwitch_Hidding_Toggled(object sender, RoutedEventArgs e)
        {
            //TODO
        }
    }
}