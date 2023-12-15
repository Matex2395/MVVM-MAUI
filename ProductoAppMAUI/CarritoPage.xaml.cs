using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using System.Collections.ObjectModel;

namespace ProductoAppMAUI;

public partial class CarritoPage : ContentPage
{
    private readonly APIService _APIService;
    public CarritoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        string IdUsuario = Preferences.Get("IdUser", "0");
        List<Carrito> ListaCarrito = await _APIService.GetProductosCarrito(IdUsuario);
        var carrito = new ObservableCollection<Carrito>(ListaCarrito);
        ListaCarritos.ItemsSource = carrito;
    }

    private async void OnClickComprar(object sender, EventArgs e)
    {
        string IdUsuario = Preferences.Get("IdUser", "0");
        List<Carrito> carrito = await _APIService.GetProductosCarrito(IdUsuario);
        if (carrito.Count==0)
        {
            await DisplayAlert("Error", "No tiene productos agregados al carrito.", "OK");
            return;
        }
        else 
        {
            await _APIService.DeleteCarrito(IdUsuario);
            await DisplayAlert("Felicidades", "Su compra ha sido realizada", "OK");
            await Navigation.PopAsync();
        }
    }

    private async void TappedDeleteFromCart(object sender, TappedEventArgs e)
    {
        if (Preferences.Get("ProductCarritoId", "0").Equals("0"))
        {
            await DisplayAlert("Atención", "Primero presione el producto que desea borrar, luego presione el botón de 'Borrar'", "OK");
        }
        else if (await _APIService.DeleteProductoCarrito(Preferences.Get("ProductCarritoId", "0"))==true)
        {
            Preferences.Set("ProductCarritoId", "0");
            await DisplayAlert("Éxito", "Producto eliminado del carrito", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Asegúrese que el producto que quiere borrar coincida con el que seleccionó", "OK");
            return;
        }
    }

    private async void OnClickDetails(object sender, SelectedItemChangedEventArgs e)
    {
        Carrito objeto = e.SelectedItem as Carrito;
        Preferences.Set("ProductCarritoId", objeto.IdProductoEnCarrito.ToString());
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en producto del carrito", ToastDuration.Short, 14);

        await toast.Show();
    }

}