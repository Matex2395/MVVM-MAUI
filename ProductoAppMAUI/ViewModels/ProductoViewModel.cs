using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.Utils;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoAppMAUI.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProductoViewModel
    {
        private readonly APIService _APIService;
        public ObservableCollection<Producto> ListaProductos { get; set; }

        public ProductoViewModel(APIService _APIService)
        {
            // Obtén la lista de productos
            List<Producto> productosList = _APIService.GetProductos().Result;

            // Inicializa ObservableCollection con la lista de productos
            ListaProductos = new ObservableCollection<Producto>(productosList);
        }

        public ICommand Logout =>
            new Command(async () =>
            {
                Preferences.Set("username", "0");
                await App.Current.MainPage.Navigation.PushAsync(new HomePage(_APIService));
            });
        public ICommand CarritoView =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new CarritoPage(_APIService));
            });
    }
}
