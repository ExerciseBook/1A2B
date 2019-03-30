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

        

        public class TNoticeBlock        {
            private TextBlock noticeBlock;
            //public TextBlock NoteBlock{ get => noteBlock; private set { noteBlock = value; } }

            

            public TNoticeBlock(TextBlock aNoticeBlock) {
                noticeBlock = aNoticeBlock;
            }

            public void Print(string key) {
                noticeBlock.Text=  Core.resourceLoader.GetString(key);
            }

            public void PrintPlain(string MSG)
            {
                noticeBlock.Text = MSG;
            }
        }
        public TNoticeBlock NoticeBlock;


        public DisplayControl(DigitalView aInputScreen,HistoryBoard ahistoryBoard,TextBlock aNoticeBlock) {
            inputScreen = aInputScreen;
            historyBoard = ahistoryBoard;
            NoticeBlock = new TNoticeBlock(aNoticeBlock);
        }


        
    }
}