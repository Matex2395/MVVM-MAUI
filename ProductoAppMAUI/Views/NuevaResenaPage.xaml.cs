using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductoAppMAUI;

public partial class NuevaResenaPage : ContentPage
{
    private Producto _producto;
    private readonly APIService _APIService;
    public NuevaResenaPage(Producto producto)
	{
        _producto = producto;
        InitializeComponent();
        BindingContext = new NuevaResenaViewModel(_producto);
    }
}