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

using Microsoft.Phone.Shell;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//Test Project References
using UnitiyCommonDirDemo;
using UnitiyCommonDirDemo.ViewModels;

namespace UnitiyCommonEmptyDemo.Test.UnitTestHelper
{
    [TestClass]
    public class MainPageTestHelper
    {
        [TestMethod]
        public void AllwaysCanBePass()
        {
            Assert.IsTrue(true,"Allways Can Be Pass Just TestMethord!");
        }

        [TestMethod]
        public void DataColIsChanged_Test()
        {
            bool isPropertyChanged = false;
            MainPage_ViewModel currentViewModel = new MainPage_ViewModel();
            currentViewModel.PropertyChanged += (x, se) => 
            {
                if(currentViewModel.CatalogInfoCol.Count>0)
                   isPropertyChanged = true;
            };
            currentViewModel.CatalogInfoCol = new System.Collections.ObjectModel.ObservableCollection<CatalogInfo>() 
            {
                new CatalogInfo(){CatalogName="ComplateTestChanged",CatalogComment="TestData"}
            };
            Assert.IsTrue(isPropertyChanged);
        }

        [TestMethod]
        public void DataCatalogTitle_CatalogTitle_Test()
        {
            bool isEventChanged = false;
            MainPage_ViewModel currentViewModel = new MainPage_ViewModel();  
            currentViewModel.PropertyChanged += (x, se) => 
            {
                if(currentViewModel.catalogTitle.Equals("newTitle"))
                    isEventChanged=true;
            };
            currentViewModel.CatalogTitle = "newTitle";
            Assert.IsTrue(isEventChanged);
        }

        //[TestMethod]
        //[Description("This test always fails intentionally")]
        //public void AllwaysWrong()
        //{
        //    Assert.IsTrue(false,"Test Method For Wrong Case!");
        //}
    }
}
