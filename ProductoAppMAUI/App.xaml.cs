using ProductoAppMAUI.Service;

namespace ProductoAppMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService aPIService = new APIService();

            MainPage = new NavigationPage(new ProductoPage(aPIService));
            MainPage = new AppShell();
            
        }
    }
}