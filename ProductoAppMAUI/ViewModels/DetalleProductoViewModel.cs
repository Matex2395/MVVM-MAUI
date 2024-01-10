using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;
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
    public class DetalleProductoViewModel
    {
        private readonly APIService _APIService;
        public Producto Producto { get; set; }
        public DetalleProductoViewModel(Producto producto)
        {
            Producto = producto;
        }
        public ICommand DejarResena =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevaResenaPage(_APIService)
                {
                    BindingContext = new NuevaResenaViewModel(Producto),
                });
            });
        public ICommand VerResenas =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new ResenaViewPage(_APIService)
                {
                    BindingContext = new ResenaViewViewModel(Producto),
                });
            });
        public ICommand AddCart =>
            new Command(async () =>
            {
                string IdUsuario = Preferences.Default.Get("IdUser", "0");
                string IdProducto = Producto.IdProducto.ToString();


                await _APIService.PostProductoEnCarrito(IdUsuario, IdProducto);
                var toast = Toast.Make("Producto Agregado a tu Carrito", ToastDuration.Short, 14);
                await toast.Show();
                await App.Current.MainPage.Navigation.PopAsync();
            });
    }

}
