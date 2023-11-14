using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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


}   