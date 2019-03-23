using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Core;


// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace _1A2B
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += onKeydown;
            //TextTest.Text = "测试";
        }

        private void TextTest_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        public async void onKeydown(CoreWindow sender, KeyEventArgs e)
        {
            
            // TextTest.Text = e.VirtualKey.GetHashCode().ToString();
            /*
                NumberPad0 96
                Number0 48
                Enter 13
                Escape 27
             */
            switch (e.VirtualKey.GetHashCode()) {
                case 96:
                case 48: { TextTest.Text += "0"; break; }
                case 97:
                case 49: { TextTest.Text += "1"; break; }
                case 98:
                case 50: { TextTest.Text += "2"; break; }
                case 99:
                case 51: { TextTest.Text += "3"; break; }
                case 100:
                case 52: { TextTest.Text += "4"; break; }
                case 101:
                case 53: { TextTest.Text += "5"; break; }
                case 102:
                case 54: { TextTest.Text += "6"; break; }
                case 103:
                case 55: { TextTest.Text += "7"; break; }
                case 104:
                case 56: { TextTest.Text += "8"; break; }
                case 105:
                case 57: { TextTest.Text += "9"; break; }
                case 10:
                case 13: { break; /*按下回车*/ }
                case 27: { break; /*按下ESC*/}


            }

        }

        void onKeyup(object sender, KeyRoutedEventArgs e)
        {
            //handling code here

            //TextTest.Text = (sender as Button).Name;
        }


    }
}
