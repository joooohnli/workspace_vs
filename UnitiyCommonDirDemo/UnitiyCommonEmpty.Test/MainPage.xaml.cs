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

using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitiyCommonEmpty.Test
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Content = UnitTestSystem.CreateTestPage();
            IMobileTestPage mobileTestPage = Content as IMobileTestPage;
            if (mobileTestPage != null)
                BackKeyPress += (x, se) => se.Cancel = mobileTestPage.NavigateBack();             
        }
    }
}