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
		//ListaProductos.ItemsSource = Utils.Utils.ListaProductos;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Producto> ListaProducto = await _APIService.GetProductos();
        var productos = new ObservableCollection<Producto>(ListaProducto);
        ListaProductos.ItemsSource = productos;
    }
    
    private async void OnClickAgregarProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProductoPage(_APIService));
    }
    private async void OnClickAgregar(object sender, EventArgs E)
	{
        var toast = Toast.Make("Producto agregado", ToastDuration.Short, 14);
        await toast.Show();
    }
    private async void OnClickBuy(object sender, EventArgs E)
    {
        var toast = Toast.Make("Producto comprado", ToastDuration.Short, 14);
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