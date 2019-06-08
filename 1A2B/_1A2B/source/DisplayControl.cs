using _1A2B.Views;
using System;
using Windows.UI.Xaml.Controls;

namespace _1A2B.source
{
    /// <summary>
    /// 界面显示模块
    /// </summary>
    public class DisplayControl
    {
        /// <summary>
        /// 输入屏幕控件 记录
        /// </summary>
        private DigitView inputScreen;

        /// <summary>
        /// 输入屏幕控件
        /// </summary>
        public DigitView InputScreen { get => inputScreen; private set => inputScreen = value; }

        /// <summary>
        /// 历史记录控件 记录
        /// </summary>
        private HistoryBoard historyBoard;

        /// <summary>
        /// 历史记录控件
        /// </summary>
        public HistoryBoard HistoryBoard { get => historyBoard; private set => historyBoard = value; }


        /// <summary>
        /// 游戏提示文本框控制类
        /// </summary>
        public class TNoticeBlock
        {
            /// <summary>
            /// 游戏提示文本框
            /// </summary>
            private TextBlock noticeBlock;
            //public TextBlock NoteBlock{ get => noteBlock; private set { noteBlock = value; } }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="aNoticeBlock">游戏提示文本框</param>
            public TNoticeBlock(TextBlock aNoticeBlock)
            {
                noticeBlock = aNoticeBlock;
            }

            /// <summary>
            /// 从资源字段中按照 key 取一端出来显示在游戏提示文本框中
            /// </summary>
            /// <param name="key">资源字段</param>
            public void Print(string key)
            {
                noticeBlock.Text = Core.resourceLoader.GetString(key);
            }

            /// <summary>
            /// 将一段内容显示在游戏提示文本框中
            /// </summary>
            /// <param name="MSG">欲显示内容</param>
            public void PrintPlain(string MSG)
            {
                noticeBlock.Text = MSG;
            }
        }

        /// <summary>
        /// 游戏提示文本框控制
        /// </summary>
        public TNoticeBlock NoticeBlock { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="aInputScreen">输入屏幕控件</param>
        /// <param name="ahistoryBoard">历史记录控件</param>
        /// <param name="aNoticeBlock">游戏提示文本框</param>
        public DisplayControl(DigitView aInputScreen, HistoryBoard ahistoryBoard, TextBlock aNoticeBlock)
        {
            inputScreen = aInputScreen;
            historyBoard = ahistoryBoard;
            NoticeBlock = new TNoticeBlock(aNoticeBlock);
        }



    }
}