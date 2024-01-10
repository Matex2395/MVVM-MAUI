using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductoAppMAUI;

public partial class NuevaResenaPage : ContentPage
{
    private Producto _producto;
    private readonly APIService _APIService;
    public NuevaResenaPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
        BindingContext = new NuevaResenaViewModel(_producto);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        IdViniloEntry.Text = _producto.IdProducto.ToString();
        string name = Preferences.Get("username", "0");
        UsuarioEntry.Text = name;
    }
}