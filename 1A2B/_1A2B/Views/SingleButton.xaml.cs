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
    public sealed partial class SingleButton : UserControl
    {
        /// <summary>
        /// 按钮值
        /// </summary>
        public InputControl.InputType ThisValue { get; set; }

        /// <summary>
        /// 按钮字体大小
        /// </summary>
        public double ThisFontSize {
            get => MyContent.FontSize;
            set {
                MyContent.FontSize = value;
            } }

        /// <summary>
        /// 按钮显示文本
        /// </summary>
        public string ThisContent { get => MyContent.Text; set {
                MyContent.Text = value;
            } }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SingleButton()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClick(object sender, RoutedEventArgs e)
        {
            Core.inputControl.Input(ThisValue);
        }
    }
}
