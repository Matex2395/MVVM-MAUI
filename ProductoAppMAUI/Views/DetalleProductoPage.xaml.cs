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
}