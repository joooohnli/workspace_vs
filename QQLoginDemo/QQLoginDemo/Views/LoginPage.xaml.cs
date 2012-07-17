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
using QQLoginDemo.Utils;
using QQLoginDemo.Entities;
using System.Diagnostics;

namespace QQLoginDemo.Views
{
    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    ApplicationBar = null;
                    break;
                case 1:
                    ApplicationBar = (ApplicationBar)Application.Current.Resources["settingBar"];
                    break;
            }
            //将焦点转移到页面上
            this.Focus();
        }


        private void Button_Confirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("登陆成功");
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("未开启推送，确定退出吗？", "退出", new MessageBoxButton());
        }

        private void CheckBox_RemeberMe_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            ReadAccount();
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {  
            base.OnNavigatedFrom(e);
            StoreAccount();
        }

        private void StoreAccount()
        {
            Account account = new Account();
            account.ID = TextBox_ID.Text;
            account.Password = PasswordBox_Password.Password;
            account.IsRemeber = (bool)CheckBox_RemeberMe.IsChecked;
            account.IsHiding = (bool)ToggleSwitch_IsHidding.IsChecked;
            account.IsWarning = (bool)ToogleSwitch_IsWarning.IsChecked;
            account.IsVibrating = (bool)ToogleSwitch_IsVibrating.IsChecked;

            StoreSettings.Instance.StoreAccountSettings(account);
        }

        private void ReadAccount()
        {
            Account account = StoreSettings.Instance.ReadAccountSettings();

            if (account == null)
            {
                return;
            }
            else
            {
                TextBox_ID.Text = account.ID;
                PasswordBox_Password.Password = account.IsRemeber == true ? account.Password : "";
                CheckBox_RemeberMe.IsChecked = account.IsRemeber;
                ToggleSwitch_IsHidding.IsChecked = account.IsHiding;
                ToogleSwitch_IsWarning.IsChecked = account.IsWarning;
                ToogleSwitch_IsVibrating.IsChecked = account.IsVibrating;
            }
        }

    }
}