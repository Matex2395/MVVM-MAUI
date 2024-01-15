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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductoAppMAUI.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DetalleProductoViewModel
    {
        private readonly APIService _APIService;
        private Producto _producto;

        public string ViniloId {  get; set; }
        public string ImagenSource { get; set; }
        public string NombreText { get; set; }
        public string CantidadText { get; set; }
        public string DescripcionText { get; set; }
        public DetalleProductoViewModel(Producto producto)
        {
            _APIService = new APIService();
            _producto = producto;
            ViniloId = _producto.IdProducto.ToString();
            ImagenSource = _producto.Imagen;
            NombreText = _producto.Nombre;
            CantidadText = _producto.Stock.ToString();
            DescripcionText = _producto.Descripcion;
        }

        public ICommand DejarResena =>
            new Command<Producto>(async (producto) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevaResenaPage(producto));
            });



        public ICommand VerResenas =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new ResenaViewPage());
            });




        public ICommand AddCart =>
            new Command(async () =>
            {
                string IdUsuario = Preferences.Default.Get("IdUser", "0");
                //string IdProducto = Producto.IdProducto.ToString();


                await _APIService.PostProductoEnCarrito(IdUsuario, IdProducto);
                var toast = Toast.Make("Producto Agregado a tu Carrito", ToastDuration.Short, 14);
                await toast.Show();
                await App.Current.MainPage.Navigation.PopAsync();
            });
    }

}
