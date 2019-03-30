using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace _1A2B.source
{
    class Core
    {

        static public ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView();

        static public source.InputControl inputControl;
        static public source.GameLogic gameControl;
        static public source.DisplayControl displayControl;

        public class TCoreControl {

            public void Start() {
                displayControl.HistoryBoard.Clear();
                inputControl.ClearBuff();
                gameControl.Start();
                displayControl.NoticeBlock.Print("NoticeBlock_Info_Game_Start");

            }
        }
        static public TCoreControl CoreControl = new TCoreControl();

    }
}
