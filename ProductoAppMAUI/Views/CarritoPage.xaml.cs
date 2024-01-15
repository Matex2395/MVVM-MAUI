using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProductoAppMAUI;

public partial class CarritoPage : ContentPage
{
    public CarritoPage()
	{
		InitializeComponent();
        BindingContext = new CarritoViewModel();
        (BindingContext as CarritoViewModel).LoadCarrito();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async void OnClickDetails(object sender, SelectedItemChangedEventArgs e)
    {
        Carrito objeto = e.SelectedItem as Carrito;
        Preferences.Set("ProductCarritoId", objeto.IdProductoEnCarrito.ToString());
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en producto del carrito", ToastDuration.Short, 14);
        await toast.Show();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        (BindingContext as CarritoViewModel).TappedDeleteFromCart.Execute(null);
    }
}