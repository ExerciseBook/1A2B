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
        public int ThisValue { get; set; }

        public string ThisContent { get => MyContent.Text; set {
                MyContent.Text = value;
            } }


        public SingleButton()
        {
            this.InitializeComponent();
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            Core.inputControl.input((source.InputControl.InputType)(ThisValue + 1));
        }
    }
}
