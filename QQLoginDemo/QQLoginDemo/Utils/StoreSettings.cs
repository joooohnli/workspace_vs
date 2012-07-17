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
using System.IO.IsolatedStorage;
using System.Diagnostics;
using QQLoginDemo.Entities;

namespace QQLoginDemo.Utils
{
    public class StoreSettings
    {
        private static StoreSettings instance = new StoreSettings();
        private static string str_Account = "account";

        private StoreSettings() { }

        public static StoreSettings Instance
        {
            get
            {
                return instance;
            }
        }

        public void StoreAccountSettings(Account account)
        {
            IsolatedStorageSettings.ApplicationSettings[str_Account] = account;

            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        public Account ReadAccountSettings()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(str_Account))
            {
                 return IsolatedStorageSettings.ApplicationSettings[str_Account] as Account;
            }
            else
                return null;
        }
    }
}
