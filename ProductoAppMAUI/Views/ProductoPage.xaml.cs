using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace ProductoAppMAUI;

public partial class ProductoPage : ContentPage
{

    public ProductoPage()
    {
        InitializeComponent();
        BindingContext = new ProductoViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        string username = Preferences.Get("username", "0");
        User.Text = username;
        (BindingContext as ProductoViewModel).LoadProducts();
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

        if (e.SelectedItem is Producto producto)
        {
            Preferences.Default.Set("ProductId", producto.IdProducto.ToString());
            (BindingContext as ProductoViewModel)?.OnClickShowDetails.Execute(producto);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}