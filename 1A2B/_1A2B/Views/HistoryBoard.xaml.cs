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
        /// <summary>
        /// 当前记录数量
        /// </summary>
        private int count;

        /// <summary>
        /// 当前记录数量
        /// </summary>
        public int Count { get => count; private set => count = value; }

        /// <summary>
        /// 高亮记录类型
        /// </summary>
        private struct TLightUp {
            public InputControl.InputType Digital;
            public int Pos;
        }

        /// <summary>
        /// 当前高亮状态
        /// </summary>
        TLightUp LightUpStatus;

        /// <summary>
        /// 普通的构造函数
        /// </summary>
        public HistoryBoard()
        {
            this.InitializeComponent();
        }
        
        /// <summary>
        /// 清理历史记录
        /// </summary>
        public void ClearHistory() {
            List1.Items.Clear();
            List2.Items.Clear();
            ListAll.Items.Clear();
            count = 0;
        }

        /// <summary>
        /// 增加历史记录
        /// </summary>
        /// <param name="inputInfo">数字部分</param>
        /// <param name="AResponse">反馈部分</param>
        public void AddHistory(InputControl.InputType[] inputInfo,GameLogic.Response AResponse) {
            if (count >= 10) { return; }
            count++;

            HistoryItem newItem = new HistoryItem();
            newItem.MyContent = inputInfo;
            newItem.Status = AResponse;
            newItem.LightUp(LightUpStatus.Digital, LightUpStatus.Pos);

            if (count <= 5) {
                List1.Items.Add(newItem);
            } else {
                List2.Items.Add(newItem);
            }


            newItem = new HistoryItem();
            newItem.MyContent = inputInfo;
            newItem.Status = AResponse;
            newItem.LightUp(LightUpStatus.Digital, LightUpStatus.Pos);

            ListAll.Items.Add(newItem);
        }

        /// <summary>
        /// 高亮
        /// </summary>
        /// <param name="Digital">欲高亮的数码</param>
        /// <param name="pos">欲高亮位置  0千 1百 2十 3位</param>
        public void LightUp(InputControl.InputType Digital, int pos) {
            for (int i = 0; i < List1.Items.Count; i++)
            {
                ((HistoryItem)List1.Items[i]).LightUp(Digital, pos);
            }
            for (int i = 0; i < List2.Items.Count; i++)
            {
                ((HistoryItem)List2.Items[i]).LightUp(Digital, pos);
            }
            for (int i = 0; i < ListAll.Items.Count; i++)
            {
                ((HistoryItem)ListAll.Items[i]).LightUp(Digital, pos);
            }


            LightUpStatus.Digital = Digital;
            LightUpStatus.Pos = pos;
        }

        /// <summary>
        /// 清理高亮
        /// </summary>
        public void ClearLightUp() {
            LightUp(InputControl.InputType.NONE, -1);
        }

    }
}
