using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace _1A2B.source
{
    /// <summary>
    /// 辅助类
    /// </summary>
    class Core
    {

        /// <summary>
        /// 资源加载器
        /// </summary>
        static public ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView();

        /// <summary>
        /// 输入控制
        /// </summary>
        static public InputControl inputControl;

        /// <summary>
        /// 游戏控制
        /// </summary>
        static public GameLogic gameControl;

        /// <summary>
        /// 显示控制
        /// </summary>
        static public DisplayControl displayControl;

        /// <summary>
        /// 游戏核心控制类
        /// </summary>
        public class TCoreControl
        {

            /// <summary>
            /// 游戏开始 初始化流程
            /// </summary>
            public void Start()
            {
                displayControl.HistoryBoard.ClearHistory();
                displayControl.HistoryBoard.ClearLightUp();
                inputControl.ClearBuff();
                gameControl.Start();
                displayControl.NoticeBlock.Print("NoticeBlock_Info_Game_Start");

            }
        }

        /// <summary>
        /// 游戏核心控制
        /// </summary>
        static public TCoreControl CoreControl = new TCoreControl();

    }
}
