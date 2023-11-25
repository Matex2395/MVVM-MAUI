using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;

namespace ProductoAppMAUI;

public partial class ProductoPage : ContentPage
{

	public ProductoPage()
	{
		InitializeComponent();
		ListaProductos.ItemsSource = Utils.Utils.ListaProductos;
	}

	private async void OnClickAgregar(object sender, EventArgs E)
	{
        var toast = Toast.Make("Producto agregado", ToastDuration.Short, 14);
        await toast.Show();
    }

    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetalleProductoPage()
        {
            BindingContext = producto,
        });
    }
}   