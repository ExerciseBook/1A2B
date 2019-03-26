using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Core;


// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace _1A2B
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private source.InputControl inputControl; 
        private source.GameLogic gameControl;
        private source.DisplayControl displayControl;


        public MainPage()
        {
            this.InitializeComponent();

            inputControl = new source.InputControl();
            gameControl = new source.GameLogic();
            displayControl = new source.DisplayControl(TextTest);

            inputControl.setDisplayControl(displayControl);
            inputControl.setGameControl(gameControl);

            //临时
            inputControl.historyBoard = historyBoard;



            
        }

        private void NumberPad_Loaded(object sender, RoutedEventArgs e)
        {
            NumberPad.setInputControl(inputControl);
        }
    }
}
