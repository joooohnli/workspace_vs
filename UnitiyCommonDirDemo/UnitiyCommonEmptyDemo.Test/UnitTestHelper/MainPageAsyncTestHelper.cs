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
using UnitiyCommon;
using UnitiyCommonDirDemo;
using UnitiyCommonDirDemo.ViewModels;






namespace UnitiyCommonEmptyDemo.Test.UnitTestHelper
{
    [TestClass]
    public class MainPageAsyncTestHelper:SilverlightTest
    {
        [TestMethod]
        [Asynchronous]
        [Description("Test Async Operator .")]
        [Timeout(6000)]
        public void AsyncOperator_ViewModel_Test()
        {
            CommentAPI currentCommentAPI = new CommentAPI();
            bool isAsnycComplated = false;
            CommentAPI.LoadCommentDataComplated += (x, se) => 
            {
                isAsnycComplated = true;
            };            

            //Test Async 
            EnqueueCallback(() => { currentCommentAPI.UpdateAsync(); });
            EnqueueConditional(() => isAsnycComplated);
            EnqueueCallback(() => Assert.IsFalse(CommentAPI.IsComplated));
            EnqueueTestComplete();         
        }


    }
}
