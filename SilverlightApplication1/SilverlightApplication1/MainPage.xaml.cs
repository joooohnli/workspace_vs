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
using LicenseManage.Classes;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        private string _InitCheckCodeString = "";//存放生成的验证码，字符串的形式
        public MainPage()
        {
            InitializeComponent();
            IndentifyCodeClass inc = new IndentifyCodeClass();
            _InitCheckCodeString = inc.CreateIndentifyCode(6);
            inc.CreatImage(_InitCheckCodeString, image1, 120, 30);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IndentifyCodeClass inc = new IndentifyCodeClass();
            _InitCheckCodeString = inc.CreateIndentifyCode(6);
            inc.CreatImage(_InitCheckCodeString, image1, 120, 30);
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.ToLower() == _InitCheckCodeString.ToLower())
            {
                messageBox.Text = "right";
            }
            else
            {
                messageBox.Text = "wrong";
            }

        }
    }
}
