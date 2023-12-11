using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using System.Collections.ObjectModel;

namespace ProductoAppMAUI;

public partial class DetalleProductoPage : ContentPage
{

    private Producto _producto;
    private readonly APIService _APIService;

    public DetalleProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        Nombre.Text = _producto.Nombre;
        Cantidad.Text = _producto.Stock.ToString();
        Descripcion.Text = _producto.Descripcion;
    }

    private async void OnClickResena(object sender, EventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make(_producto.Nombre, ToastDuration.Short, 14);

        await toast.Show();
        await Navigation.PushAsync(new NuevaResenaPage(_APIService)
        {
            BindingContext = _producto,
        });
    }

    private async void OnClickResenaView(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ResenaViewPage(_APIService));
    }
}