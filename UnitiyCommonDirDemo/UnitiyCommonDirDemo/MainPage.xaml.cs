﻿using System;
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

using UnitiyCommonDirDemo.ViewModels;

namespace UnitiyCommonDirDemo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private MainPage_ViewModel mainPage_ViewModel = null;
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.mainPage_ViewModel == null)
                this.mainPage_ViewModel = new MainPage_ViewModel();
            this.mainPage_ViewModel.LoadCatalogDefaultData();
            this.DataContext = mainPage_ViewModel;
        }
    }
}