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
using Microsoft.Silverlight.Testing;
namespace UnitiyCommonEmptyDemo.Test.Views
{
    public partial class MainPageOutPut_Form : PhoneApplicationPage
    {
        public MainPageOutPut_Form()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPageOutPut_Form_Loaded);
        }

        void MainPageOutPut_Form_Loaded(object sender, RoutedEventArgs e)
        {
            //UnAvaliable SystemTray
            SystemTray.IsVisible=false;
            var currentMobileTestPage = UnitTestSystem.CreateTestPage() as IMobileTestPage;
            if (currentMobileTestPage != null)
            {
                BackKeyPress += (x, se) => se.Cancel = currentMobileTestPage.NavigateBack();
                (Application.Current.RootVisual as PhoneApplicationFrame).Content = currentMobileTestPage;
            }
        }
    }
}