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

namespace _1A2B
{
    public sealed partial class KeyBoard : UserControl
    {

        private _1A2B.source.InputControl inputControl = null;

        public void setInputControl(_1A2B.source.InputControl aInputControl) {
            inputControl = aInputControl;
        }

        public KeyBoard()
        {
            this.InitializeComponent();
        }

        private void NumButton_Click(object sender, RoutedEventArgs e)
        {
            Button thisButton = (Button)sender;
            TextBlock content = (TextBlock)thisButton.Content;
            //throw new Exception(thisButton.Content.GetType().ToString());
            inputControl.input((_1A2B.source.InputControl.InputType)((int)content.Text[0]-48+1));
        }

    }
}
