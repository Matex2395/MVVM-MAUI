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
        public string PrecioText { get; set; }
        public DetalleProductoViewModel(Producto producto)
        {
            _APIService = new APIService();
            _producto = producto;
            ViniloId = _producto.IdProducto.ToString();
            ImagenSource = _producto.Imagen;
            NombreText = _producto.Nombre;
            CantidadText = _producto.Stock.ToString();
            DescripcionText = _producto.Descripcion;
            PrecioText = _producto.Precio.ToString();
        }

        public ICommand DejarResena =>
            new Command(async () =>
            {
                Producto producto2 = new Producto()
                {
                    IdProducto = Convert.ToInt32(ViniloId),
                    Nombre = NombreText,
                    Descripcion = DescripcionText,
                    Precio = Convert.ToDecimal(PrecioText),
                    Stock = Convert.ToInt32(CantidadText),
                    Imagen = ImagenSource
                };
                await App.Current.MainPage.Navigation.PushAsync(new NuevaResenaPage(producto2));
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

                await _APIService.PostProductoEnCarrito(IdUsuario, ViniloId);
                await App.Current.MainPage.DisplayAlert("Producto Agregado al Carrito", "El producto se agregó correctamente a tu Carrito.", "OK");
                var toast = Toast.Make("Producto Agregado a tu Carrito", ToastDuration.Short, 14);
                await toast.Show();
                await App.Current.MainPage.Navigation.PopAsync();
            });
    }

}
