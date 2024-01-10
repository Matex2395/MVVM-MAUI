using ProductoAppMAUI.Handlers;
using ProductoAppMAUI.Service;
using Microsoft.Maui.Graphics;

namespace ProductoAppMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService aPIService = new APIService();

//            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
//            {
//                if (view is BorderlessEntry)
//                {
//#if __ANDROID__
//                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToNative());
//#elif __IOS__
//                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
//#endif
//                }
//            });

            MainPage = new NavigationPage(new HomePage(aPIService));
            Preferences.Set("username", "0");
            //MainPage = new AppShell();
            
        }
    }
}