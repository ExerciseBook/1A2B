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
        /// <summary>
        /// 用户输入信息
        /// </summary>
        public enum InputType { NONE, Num0, Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9, Num10, Enter, ESC, Backspace };

        /// <summary>
        /// 输入屏幕的内容
        /// </summary>
        private InputType[] inputBuff = new InputType[4];

        private struct KeyStatus
        {
            public int Control;
        };

        private KeyStatus aKeyStatus;

        /// <summary>
        /// 构造函数 : 绑定按键侦听事件
        /// </summary>
        public InputControl() {
            Window.Current.CoreWindow.KeyDown += OnKeydown;
            Window.Current.CoreWindow.KeyUp += OnKeyUp;
            aKeyStatus.Control = 0;
        }
                     
        /// <summary>
        /// 输入事件处理
        /// </summary>
        /// <param name="a">输入的内容</param>
        public void Input(InputType a) {

            // 游戏是否开始
            if (Core.gameControl.GetGameStatus() != 1) {
                //游戏未开始

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

            // 处理输入的内容
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

                    if (Core.gameControl.submit(number) == 0)
                    {
                        Core.displayControl.HistoryBoard.AddHistory(inputBuff, Core.gameControl.LastSubmit);
                        inputBuff = new InputType[4];
                    }
                    else {
                        int status = Core.gameControl.WhyInvalid(number);
                        switch (status) {
                            //case 0:
                            case 1: { Core.displayControl.NoticeBlock.Print("NoticeBlock_Error_Input_StartWithZero"); break; }
                            //case 2: { Core.displayControl.NoticeBlock.Print("NoticeBlock_Error_Input_TooLarge"); break; }
                            case 3: { Core.displayControl.NoticeBlock.Print("NoticeBlock_Error_Input_Duplicate"); break; }
                            default : { Core.displayControl.NoticeBlock.Print("NoticeBlock_Error_Input_Default"); break; }
                        }
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
                    int flag = 1;

                    while (inputBuff[i] != InputType.NONE) {
                        if (inputBuff[i] == a) {
                            flag = 0;
                            break;
                        }
                        i++;
                    }

                    if (flag == 1)
                    {
                        if ((i == 0) && (a == InputType.Num0))
                        {
                            Core.displayControl.NoticeBlock.Print("NoticeBlock_Error_Input_StartWithZero");
                        }
                        else
                        {
                            inputBuff[i] = a;
                        }
                    } else {
                        Core.displayControl.NoticeBlock.Print("NoticeBlock_Error_Input_Duplicate");
                    }
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

        public async void OnKeydown(CoreWindow sender, KeyEventArgs e)
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
                case 17: { aKeyStatus.Control = 1; break; }
                case 82: {
                        if (aKeyStatus.Control == 1) {
                            if (Core.gameControl.GetGameStatus() != 1)
                            {
                                Core.CoreControl.Start();
                            }
                            else
                            {
                                Core.CoreControl.Start();
                                Core.displayControl.NoticeBlock.Print("NoticeBlock_Info_Game_Restart");
                            }
                        }
                        break;
                    }
                //default: throw new Exception(e.VirtualKey.GetHashCode().ToString());

            }

        }


        public async void OnKeyUp(CoreWindow sender, KeyEventArgs e) {
            switch (e.VirtualKey.GetHashCode())
            {
                case 17: { aKeyStatus.Control = 0; break; }
                //default: throw new Exception(e.VirtualKey.GetHashCode().ToString());

            }
        }

        /// <summary>
        /// 清空输入信息
        /// </summary>
        public void ClearBuff() {
            inputBuff = new InputType[4];
            Core.displayControl.InputScreen.MyContent = inputBuff;
        }

    }
}
