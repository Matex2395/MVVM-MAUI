using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace ProductoAppMAUI;

public partial class ProductoPage : ContentPage
{
    private readonly APIService _APIService;
    public ProductoPage(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
        BindingContext = new ProductoViewModel(_APIService);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        string username = Preferences.Get("username", "0");
        User.Text = username;
        //List<Producto> ListaProducto = await _APIService.GetProductos();
        //var productos = new ObservableCollection<Producto>(ListaProducto);
        //ListaProductos.ItemsSource = productos;
    }


    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Producto producto = e.SelectedItem as Producto;
        Preferences.Default.Set("ProductId", producto.IdProducto.ToString());
        await Navigation.PushAsync(new DetalleProductoPage(_APIService)
        {
            BindingContext = new DetalleProductoViewModel(producto),
        });
    }
}   