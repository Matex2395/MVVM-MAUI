using ProductoAppMAUI.Service;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoAppMAUI.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class HomeViewModel
    {
        public HomeViewModel()
        {
            
        }
        public ICommand LoginView =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new Login());
            });
    }

}
