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
using System.Diagnostics;

namespace ForTest.NewControl
{
    public class MyButton:Button
    {
        protected override void OnClick()
        {
            base.OnClick();
            Debug.WriteLine("do something common for a click here");
        }
    }
}
