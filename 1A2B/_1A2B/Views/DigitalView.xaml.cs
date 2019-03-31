using _1A2B.source;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class DigitalView : UserControl
    {

        /// <summary>
        /// 输入屏幕数码更新
        /// </summary>
        /// <param name="textView">文本框</param>
        /// <param name="num">数码</param>
        static void ContentUpdate(TextBlock textView, InputControl.InputType num ) {
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
        /// 输入屏幕数码记录
        /// </summary>
        private InputControl.InputType[] Buff = new InputControl.InputType[4];

        /// <summary>
        /// 输入屏幕数码记录 属性
        /// </summary>
        public InputControl.InputType[] MyContent  {
            get => Buff;
            set {
                Buff = value;
                if (value.Length == 4) {
                    ContentUpdate((TextBlock)NumThousand.Content , value[0]);
                    ContentUpdate((TextBlock)NumHundred.Content , value[1]);
                    ContentUpdate((TextBlock)NumTen.Content , value[2]);
                    ContentUpdate((TextBlock)NumUnit.Content , value[3]);

                }
            }

        }

        public DigitalView()
        {
            this.InitializeComponent();
        }
    }
}
