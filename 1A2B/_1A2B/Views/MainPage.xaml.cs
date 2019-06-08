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
using _1A2B.source;
using Windows.System;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace _1A2B
{
    /// <summary>
    /// 主页面
    /// </summary>
    public sealed partial class MainPage : Page
    {

        /// <summary>
        /// 初始化页面
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            InitializeFrostedGlass_All();

            //将三个控件绑定到全局静态变量
            Core.inputControl = new source.InputControl();
            Core.gameControl = new source.GameLogic();
            Core.displayControl = new source.DisplayControl(InputScreen, historyBoard, NoticeBlock);
        }

        /// <summary>
        /// 标题栏特效
        /// </summary>
        private void InitializeFrostedGlass_All()
        {
            Windows.ApplicationModel.Core.CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            Windows.UI.ViewManagement.ApplicationView view = ApplicationView.GetForCurrentView();
            view.TitleBar.ButtonBackgroundColor = Colors.Transparent; //将标题栏的三个键背景设为透明
            view.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent; //失去焦点时，将三个键背景设为透明
            view.TitleBar.ButtonInactiveForegroundColor = Colors.White; //失去焦点时，将三个键前景色设为白色

            InitializeFrostedGlass(GlassHost);
        }

        /// <summary>
        /// 毛玻璃注入灵魂
        /// </summary>
        /// <param name="glassHost"></param>
        private void InitializeFrostedGlass(UIElement glassHost)
        {
            Visual hostVisual = ElementCompositionPreview.GetElementVisual(glassHost);
            Compositor compositor = hostVisual.Compositor;
            Windows.UI.Composition.CompositionBackdropBrush backdropBrush = compositor.CreateHostBackdropBrush();
            Windows.UI.Composition.SpriteVisual glassVisual = compositor.CreateSpriteVisual();
            glassVisual.Brush = backdropBrush;
            ElementCompositionPreview.SetElementChildVisual(glassHost, glassVisual);
            Windows.UI.Composition.ExpressionAnimation bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
            bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);
            glassVisual.StartAnimation("Size", bindSizeAnimation);
        }

        /// <summary>
        /// 游戏开始按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_StartGame(object sender, RoutedEventArgs e)
        {
            if (Core.gameControl.GetGameStatus() != 1)
            {
                Core.CoreControl.Start();
            }
            else {
                Core.displayControl.NoticeBlock.Print("NoticeBlock_Info_AlreadyStart");
            }
        }

        /// <summary>
        /// 游戏重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_RestartGame(object sender, RoutedEventArgs e)
        {
            if (Core.gameControl.GetGameStatus() != 1)
            {
                Core.displayControl.NoticeBlock.Print("NoticeBlock_Info_HavntStart_WithGuide");
            }
            else
            {
                Core.CoreControl.Start();
                Core.displayControl.NoticeBlock.Print("NoticeBlock_Info_Game_Restart");
            }
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_About(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri(@"https://github.com/ExerciseBook/1A2B"));
        }

    }
}
