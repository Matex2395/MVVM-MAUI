using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using System.Collections.ObjectModel;

namespace ProductoAppMAUI;

public partial class ProductoPage : ContentPage
{
    private readonly APIService _APIService;
	public ProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
	}
    private async void validarLogin()
    {
        if (Preferences.Get("username", "0").Equals("0"))
        {
            await Navigation.PushAsync(new Login(_APIService));
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        validarLogin();
        string username = Preferences.Get("username", "0");
        User.Text = username;
        List<Producto> ListaProducto = await _APIService.GetProductos();
        var productos = new ObservableCollection<Producto>(ListaProducto);
        ListaProductos.ItemsSource = productos;
    }

    private async void OnClickLogout(object sender, EventArgs e)
    {
        Preferences.Set("username", "0");
        await Navigation.PushAsync(new Login(_APIService));
    }

    private async void OnClickVerCarrito(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CarritoPage(_APIService));
    }

    private async void OnClickAddCart(object sender, EventArgs E)
    {
        var toast = Toast.Make("Producto Agregado a tu Carrito", ToastDuration.Short, 14);
        await toast.Show();
    }

    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetalleProductoPage(_APIService)
        {
            BindingContext = producto,
        });
    }
}   