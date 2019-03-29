using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Composition;
using Windows.UI;

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

            InitializeFrostedGlass_All();
            
            inputControl = new source.InputControl();
            gameControl = new source.GameLogic();
            displayControl = new source.DisplayControl(InputScreen,historyBoard);


            gameControl.Start();

            inputControl.setDisplayControl(displayControl);
            inputControl.setGameControl(gameControl);
            
        }

        private void NumberPad_Loaded(object sender, RoutedEventArgs e)
        {
            NumberPad.setInputControl(inputControl);
        }

        private void InitializeFrostedGlass_All() {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            
            var view = ApplicationView.GetForCurrentView();
            view.TitleBar.ButtonBackgroundColor = Colors.Transparent; //将标题栏的三个键背景设为透明
            view.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent; //失去焦点时，将三个键背景设为透明
            view.TitleBar.ButtonInactiveForegroundColor = Colors.White; //失去焦点时，将三个键前景色设为白色

            InitializeFrostedGlass(GlassHost);
        }

        private void InitializeFrostedGlass(UIElement glassHost)
        {
            Visual hostVisual = ElementCompositionPreview.GetElementVisual(glassHost);
            Compositor compositor = hostVisual.Compositor;
            var backdropBrush = compositor.CreateHostBackdropBrush();
            var glassVisual = compositor.CreateSpriteVisual();
            glassVisual.Brush = backdropBrush;
            ElementCompositionPreview.SetElementChildVisual(glassHost, glassVisual);
            var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
            bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);
            glassVisual.StartAnimation("Size", bindSizeAnimation);
        }
    }
}
