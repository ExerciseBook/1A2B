using _1A2B.Views;
using System;
using Windows.UI.Xaml.Controls;

namespace _1A2B.source
{
    public class DisplayControl
    {

        private DigitalView inputScreen;
        public DigitalView InputScreen { get => inputScreen; private set => inputScreen = value; }


        public DisplayControl(DigitalView aInputScreen) {
            inputScreen = aInputScreen;
        }
    }
}