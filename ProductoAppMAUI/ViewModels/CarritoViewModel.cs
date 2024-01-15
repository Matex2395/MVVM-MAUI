using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
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
    public class CarritoViewModel
    {
        private APIService _APIService;
        public ObservableCollection<Carrito> ListaCarrito { get; set; }
        public CarritoViewModel()
        {
            _APIService = new APIService();
        }

        public async void LoadCarrito()
        {
            ListaCarrito = new ObservableCollection<Carrito>();
            var carrito = await _APIService.GetProductosCarrito(Preferences.Get("IdUser", "0"));
            foreach (var c in carrito)
            {
                ListaCarrito.Add(c);
            }
        }

        public ICommand Comprar =>
            new Command(async () =>
            {
                List<Carrito> carrito = await _APIService.GetProductosCarrito(Preferences.Get("IdUser", "0"));
                if (carrito.Count == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No tiene productos agregados al carrito.", "OK");
                    return;
                }
                else
                {
                    await _APIService.DeleteCarrito(Preferences.Get("IdUser", "0"));
                    await App.Current.MainPage.DisplayAlert("Felicidades", "Su compra ha sido realizada", "OK");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });

        public ICommand TappedDeleteFromCart =>
            new Command(async () =>
            {
                if (Preferences.Get("ProductCarritoId", "0").Equals("0"))
                {
                    await App.Current.MainPage.DisplayAlert("Atención", "Primero presione el producto que desea borrar, luego presione el botón de 'Borrar'", "OK");
                }
                else if (await _APIService.DeleteProductoCarrito(Preferences.Get("ProductCarritoId", "0")) == true)
                {
                    Preferences.Set("ProductCarritoId", "0");
                    await App.Current.MainPage.DisplayAlert("Éxito", "Producto eliminado del carrito", "OK");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Asegúrese que el producto que quiere borrar coincida con el que seleccionó", "OK");
                    return;
                }
            });
    }
}
