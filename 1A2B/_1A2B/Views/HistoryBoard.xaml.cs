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
        public int Count { get => count; private set => count = value; }

        struct TLightUp {
            public InputControl.InputType Digital;
            public int Pos;
        }
        TLightUp LightUpStatus;

        public HistoryBoard()
        {
            this.InitializeComponent();
        }
        

        public void ClearHistory() {
            List1.Items.Clear();
            List2.Items.Clear();
            count = 0;
        }


        public void AddHistory(InputControl.InputType[] inputInfo,GameLogic.Response AResponse) {
            if (count >= 10) { return; }

            HistoryItem newItem = new HistoryItem();
            newItem.MyContent = inputInfo;
            newItem.Status = AResponse;
            newItem.LightUp(LightUpStatus.Digital, LightUpStatus.Pos);

            if (count < 5) {
                List1.Items.Add(newItem);
            } else {
                List2.Items.Add(newItem);
            }

            count++;
        }


        public void LightUp(InputControl.InputType Digital, int pos) {
            for (int i = 0; i < List1.Items.Count; i++)
            {
                ((HistoryItem)List1.Items[i]).LightUp(Digital, pos);
            }
            for (int i = 0; i < List2.Items.Count; i++)
            {
                ((HistoryItem)List2.Items[i]).LightUp(Digital, pos);
            }
            LightUpStatus.Digital = Digital;
            LightUpStatus.Pos = pos;
        }

        public void ClearLightUp() {
            LightUp(InputControl.InputType.NONE, -1);
        }

    }
}
