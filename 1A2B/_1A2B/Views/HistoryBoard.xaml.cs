using _1A2B._1A2B.Views;
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
    public sealed partial class HistoryBoard : UserControl
    {
        private int count;
        public int Count { get => count; set => count = value; }
            
        public HistoryBoard()
        {
            this.InitializeComponent();
        }


        public void Clear() {
            List1.Items.Clear();
            List2.Items.Clear();
            count = 0;
        }


        public void Add(InputControl.InputType[] inputInfo) {
            if (count >= 10) { return; }

            HistoryItem newItem = new HistoryItem();
            newItem.TheNumber.MyContent = inputInfo;

            if (count < 5) {
                List1.Items.Add(newItem);
            } else {
                List2.Items.Add(newItem);
            }

            count++;

        }


    }
}
