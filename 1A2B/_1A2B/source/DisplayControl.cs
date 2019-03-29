using _1A2B.Views;
using System;
using Windows.UI.Xaml.Controls;

namespace _1A2B.source
{
    public class DisplayControl
    {

        private DigitalView inputScreen;
        public DigitalView InputScreen { get => inputScreen; private set => inputScreen = value; }

        private HistoryBoard historyBoard;
        public HistoryBoard HistoryBoard { get => historyBoard; private set => historyBoard = value; }


        public DisplayControl(DigitalView aInputScreen,HistoryBoard ahistoryBoard) {
            inputScreen = aInputScreen;
            historyBoard = ahistoryBoard;
        }
    }
}