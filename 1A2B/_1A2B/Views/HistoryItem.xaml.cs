using _1A2B.source;
using _1A2B.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace _1A2B.Views
{
    public sealed partial class HistoryItem : UserControl
    {
        public HistoryItem()
        {
            this.InitializeComponent();

            //TheNumber = Number;
        }


        static void ContentUpdate(TextBlock textView, InputControl.InputType num)
        {
            int i = (int)num;
            if ((1 <= i) && (i <= 10))
            {
                textView.Text = "" + (Char)(i - 1 + 48);
            }
            else
            {
                textView.Text = "";
            };

        }


        private InputControl.InputType[] Buff = new InputControl.InputType[4];
        public InputControl.InputType[] MyContent
        {
            get => Buff;
            set
            {
                Buff = value;
                if (value.Length == 4)
                {
                    ContentUpdate(NumThousand, value[0]);
                    ContentUpdate(NumHundred, value[1]);
                    ContentUpdate(NumTen, value[2]);
                    ContentUpdate(NumUnit, value[3]);

                }
            }

        }


        private GameLogic.Response status;
        public GameLogic.Response Status {
            get => status;
            set {
                status = value;
                Result.Text = (char)(status.nA + 48) + "A" + (char)(status.nB + 48) + "B";
            }
        }

        private void LightUp(Button button, TextBlock textblock, int position, InputControl.InputType Digital, int pos) {
            if (Buff[position] == Digital)
            {
                textblock.Foreground = new SolidColorBrush(Colors.Red);
            }
            else {
                textblock.Foreground = new SolidColorBrush((Color)Application.Current.Resources["SystemChromeWhiteColor"]);
            }


            if (position == pos)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(0x7F, 0x00, 0xFF, 0xFF)); //高亮
            }
            else {
                button.Background = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF)); //透明
            }
        }



        public void LightUp(InputControl.InputType Digital, int pos) {
            LightUp(ButtonThousand, NumThousand, 0, Digital, pos);
            LightUp(ButtonHundred, NumHundred, 1, Digital, pos);
            LightUp(ButtonTen, NumTen, 2, Digital, pos);
            LightUp(ButtonUnit, NumUnit, 3, Digital, pos);
        }


        private void ButtonThousand_Click(object sender, RoutedEventArgs e)
        {
            Core.displayControl.HistoryBoard.LightUp(Buff[0],0);
        }

        private void ButtonHundred_Click(object sender, RoutedEventArgs e)
        {
            Core.displayControl.HistoryBoard.LightUp(Buff[1], 1);
        }

        private void ButtonTen_Click(object sender, RoutedEventArgs e)
        {
            Core.displayControl.HistoryBoard.LightUp(Buff[2], 2);
        }

        private void ButtonUnit_Click(object sender, RoutedEventArgs e)
        {
            Core.displayControl.HistoryBoard.LightUp(Buff[3], 3);
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Core.displayControl.HistoryBoard.LightUp(InputControl.InputType.NONE, -1);
        }
    }
}
