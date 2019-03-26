using System;
using Windows.UI.Xaml.Controls;

namespace _1A2B.source
{
    public class DisplayControl
    {


        public class TInputScreen{

            TextBlock inputScreen;

            public TInputScreen(TextBlock aTextBlock)
            {
                inputScreen = aTextBlock;
            }

            private InputControl.InputType[] text;
            public InputControl.InputType[] Text {
                get => text;
                set {
                    text = value;

                    string tmp = "";
                    for (int i = 0; i<value.Length ; i++)
                    {
                        int b = (int)value[i];
                        if ((1 <= b) && (b <= 10))
                        {
                            tmp += (Char)(b + 48 - 1);
                        }
                    }
                    inputScreen.Text = tmp;
                }
            }


        }

        private TInputScreen inputScreen;
        public TInputScreen InputScreen { get => inputScreen; private set => inputScreen = value; }


        public DisplayControl(TextBlock aInputScreen) {
            inputScreen = new TInputScreen(aInputScreen);
        }
    }
}