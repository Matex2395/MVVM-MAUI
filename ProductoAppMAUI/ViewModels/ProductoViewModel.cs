using CommunityToolkit.Mvvm.ComponentModel;
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
        private APIService _APIService;
        public ObservableCollection<Producto> ListaProductos { get; set; }

        public ProductoViewModel()
        {
            _APIService = new APIService();
        }

        public async void LoadProducts()
        {
            ListaProductos = new ObservableCollection<Producto>();
            var productos = await _APIService.GetProductos();
            foreach (var p in productos)
            {
                ListaProductos.Add(p);
            }
        }

        public ICommand OnClickShowDetails =>
            new Command<Producto>(async (producto) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new DetalleProductoPage(producto));
            });

        public ICommand Logout =>
            new Command(async () =>
            {
                Preferences.Set("username", "0");
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            });
        public ICommand CarritoView =>
            new Command(async () =>
            {
                //await App.Current.MainPage.Navigation.PushAsync(new CarritoPage());
            });
    }
}
