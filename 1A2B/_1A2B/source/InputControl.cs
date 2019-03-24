using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _1A2B.source
{
    class InputControl
    {

        private TextBlock TextTest;

        public InputControl(TextBlock textBlock) {
            this.TextTest = textBlock;
            Window.Current.CoreWindow.KeyDown += onKeydown;
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
            switch (e.VirtualKey.GetHashCode())
            {
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

    }
}
