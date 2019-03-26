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

        private InputControl.InputType[] Buff = new InputControl.InputType[4];

        public InputControl.InputType[] MyContent  {
            get => Buff;
            set {
                Buff = value;
                if (value.Length == 4) {
                    ((TextBlock)NumThousand.Content).Text = "" + (Char)(((int)value[0])-1+48) ;
                    ((TextBlock)NumHundred.Content).Text = "" + (Char)(((int)value[1])-1+48) ;
                    ((TextBlock)NumTen.Content).Text = "" + (Char)(((int)value[2])-1+48) ;
                    ((TextBlock)NumUnit.Content).Text = "" + (Char)(((int)value[3])-1+48) ;
                }
            }

        }

        public DigitalView()
        {
            this.InitializeComponent();
        }
    }
}
