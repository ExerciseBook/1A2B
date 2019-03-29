﻿using _1A2B.source;
using _1A2B.Views;
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

namespace _1A2B._1A2B.Views
{
    public sealed partial class HistoryItem : UserControl
    {
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
                    ContentUpdate((TextBlock)NumThousand.Content, value[0]);
                    ContentUpdate((TextBlock)NumHundred.Content, value[1]);
                    ContentUpdate((TextBlock)NumTen.Content, value[2]);
                    ContentUpdate((TextBlock)NumUnit.Content, value[3]);

                }
            }

        }

        //public DigitalView TheNumber;

        private GameLogic.Response status;
        public GameLogic.Response Status {
            get => status;
            set {
                status = value;
                Result.Text = (char)(status.nA + 48) + "A" + (char)(status.nB + 48) + "B";
            }
        }

        public HistoryItem()
        {
            this.InitializeComponent();

            //TheNumber = Number;
        }

    }
}
