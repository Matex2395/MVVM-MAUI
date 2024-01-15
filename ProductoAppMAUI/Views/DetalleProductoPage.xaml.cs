using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace ProductoAppMAUI;

public partial class DetalleProductoPage : ContentPage
{

    private Producto _producto;

    public DetalleProductoPage(Producto producto)
	{
		_producto = producto;
        InitializeComponent();
        BindingContext = new DetalleProductoViewModel(_producto);
    }







    private async void OnClickAddCart(object sender, EventArgs E)
    {
        string IdUsuario = Preferences.Default.Get("IdUser", "0");
        string IdProducto = _producto.IdProducto.ToString();


        await _APIService.PostProductoEnCarrito(IdUsuario, IdProducto);
        await DisplayAlert("Producto Agregado al Carrito", "El producto se agregó correctamente a tu Carrito.", "OK");
        var toast = Toast.Make("Producto Agregado a tu Carrito", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PopAsync();

    }
}