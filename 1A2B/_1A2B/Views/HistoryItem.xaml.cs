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
        }

        /// <summary>
        /// 显示内容 数字部分 刷新内容
        /// </summary>
        /// <param name="textView"></param>
        /// <param name="num"></param>
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

        /// <summary>
        /// 显示内容 数字部分 记录
        /// </summary>
        private InputControl.InputType[] Buff = new InputControl.InputType[4];

        /// <summary>
        /// 显示内容 数字部分
        /// </summary>
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

        /// <summary>
        /// 显示内容 反馈部分 记录
        /// </summary>
        private GameLogic.Response status;

        /// <summary>
        /// 显示内容 反馈部分
        /// </summary>
        public GameLogic.Response Status {
            get => status;
            set {
                status = value;
                Result.Text = (char)(status.nA + 48) + "A" + (char)(status.nB + 48) + "B";
            }
        }

        /// <summary>
        /// 高亮执行
        /// </summary>
        /// <param name="button">按钮对象</param>
        /// <param name="textblock">文本框对象</param>
        /// <param name="position">文本框位数对象 0千 1百 2十 3位</param>
        /// <param name="Digital">欲高亮数码</param>
        /// <param name="pos">欲高亮位置  0千 1百 2十 3位</param>
        private void LightUp(Button button, TextBlock textblock, int position, InputControl.InputType Digital, int pos) {
            if (Buff[position] == Digital)
            {
                textblock.Foreground = new SolidColorBrush(Colors.Red);
            }
            else {
                textblock.Foreground = new SolidColorBrush((Color)Application.Current.Resources["SystemBaseHighColor"]);
            }


            if (position == pos)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(0x7F, 0x00, 0xFF, 0xFF)); //高亮
            }
            else {
                button.Background = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF)); //透明
            }
        }


        /// <summary>
        /// 高亮
        /// </summary>
        /// <param name="Digital">欲高亮的数码</param>
        /// <param name="pos">欲高亮位置  0千 1百 2十 3位</param>
        public void LightUp(InputControl.InputType Digital, int pos) {
            LightUp(ButtonThousand, NumThousand, 0, Digital, pos);
            LightUp(ButtonHundred, NumHundred, 1, Digital, pos);
            LightUp(ButtonTen, NumTen, 2, Digital, pos);
            LightUp(ButtonUnit, NumUnit, 3, Digital, pos);
        }

        /// <summary>
        /// 按钮点击触发高亮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
