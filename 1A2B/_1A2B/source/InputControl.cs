using _1A2B.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _1A2B.source
{
    public class InputControl
    {
        
        public enum InputType { NONE, Num0, Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9, Num10, Enter, ESC, Backspace };

        /// <summary>
        /// 输入屏幕的内容
        /// </summary>
        InputType[] inputBuff = new InputType[4];

        /// <summary>
        /// 构造函数 : 绑定按键侦听事件
        /// </summary>
        public InputControl() {
            Window.Current.CoreWindow.KeyDown += onKeydown;
        }

        public void Input(InputType a) {

            if (Core.gameControl.GetGameStatus() != 1) {
                if (Core.gameControl.GetGameStatus() == 0)
                {
                    Core.displayControl.NoticeBlock.Print("NoticeBlock_Info_HavntStart");
                }
                else if (Core.gameControl.GetGameStatus() == 3)
                {
                    Core.displayControl.NoticeBlock.PrintPlain(Core.resourceLoader.GetString("NoticeBlock_Info_HavntStart_WithAnswer_Lost").Replace("%ANSWER%", "" + Core.gameControl.GetAns()));
                }
                else if (Core.gameControl.GetGameStatus() == 2)
                {
                    Core.displayControl.NoticeBlock.PrintPlain(Core.resourceLoader.GetString("NoticeBlock_Info_HavntStart_WithAnswer_Win").Replace("%ANSWER%", "" + Core.gameControl.GetAns()));
                }
                return;
            }


            if (a == InputType.ESC)
            {
                inputBuff = new InputType[4];
            }
            else if (a == InputType.Enter) {
                if (inputBuff[3] != InputType.NONE)
                {
                    int number = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        number += ((int)inputBuff[i] - 1) * Power(10, (3 - i));
                    }

                    if ((Core.gameControl.GetGameStatus() == 1) && (Core.gameControl.submit(number)==0)) {

                        Core.displayControl.HistoryBoard.AddHistory(inputBuff, Core.gameControl.LastSubmit);
                        inputBuff = new InputType[4];
                    }
                }
            }
            else if (a == InputType.Backspace) {
                int i = 3;
                while ((i >= 0) && (inputBuff[i] == InputType.NONE)) {
                    i--;
                }
                if (i >= 0) {
                    inputBuff[i] = InputType.NONE;
                }
            }
            else {
                if (inputBuff[3] == InputType.NONE)
                {
                    int i = 0;
                    while (inputBuff[i] != InputType.NONE) i++;
                    inputBuff[i] = a;
                }
            }
            Core.displayControl.InputScreen.MyContent=inputBuff;
        }

        private int Power(int Base, int Kick)
        {
            int result = 1;

            for (int i = 1; i <= Kick; i++) {
                result = result * Base;
            }

            return result;
        }

        public async void onKeydown(CoreWindow sender, KeyEventArgs e)
        {
            // TextTest.Text = e.VirtualKey.GetHashCode().ToString();
            /*
             *  NumberPad0 96
             *  Number0 48
             *  Enter 13
             *  Escape 27
             */
            switch (e.VirtualKey.GetHashCode())
            {
                case 96:
                case 48: { Input(InputType.Num0); break; }
                case 97:
                case 49: { Input(InputType.Num1); break; }
                case 98:
                case 50: { Input(InputType.Num2); break; }
                case 99:
                case 51: { Input(InputType.Num3); break; }
                case 100:
                case 52: { Input(InputType.Num4); break; }
                case 101:
                case 53: { Input(InputType.Num5); break; }
                case 102:
                case 54: { Input(InputType.Num6); break; }
                case 103:
                case 55: { Input(InputType.Num7); break; }
                case 104:
                case 56: { Input(InputType.Num8); break; }
                case 105:
                case 57: { Input(InputType.Num9); break; }
                case 10:
                case 13: { Input(InputType.Enter); break; }
                case 27: { Input(InputType.ESC); break; }
                case 8: { Input(InputType.Backspace); break; }
                //default: throw new Exception(e.VirtualKey.GetHashCode().ToString());

            }

        }

        public void ClearBuff() {
            InputType[] inputBuff = new InputType[4];
        }

    }
}
