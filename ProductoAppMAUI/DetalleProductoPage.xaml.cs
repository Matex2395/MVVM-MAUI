using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using System.Collections.ObjectModel;

namespace ProductoAppMAUI;

public partial class DetalleProductoPage : ContentPage
{

    private Producto _producto;
    private Resena _resena;
    private readonly APIService _APIService;

    public DetalleProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        _resena = BindingContext as Resena;
        Nombre.Text = _producto.Nombre;
        Cantidad.Text = _producto.Stock.ToString();
        Descripcion.Text = _producto.Descripcion;
        List<Resena> ListaResena = await _APIService.GetResenas(_producto);
        if (ListaResena != null && ListaResena.Count > 0)
        {
            var resenas = new ObservableCollection<Resena>(ListaResena);
            ListaResenas.ItemsSource = resenas;
            ListaResenas.IsVisible = true;
            NoResenasLabel.IsVisible = false;
        }
        else
        {
            ListaResenas.IsVisible = false;
            NoResenasLabel.IsVisible = true;
        }
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

}