using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using System.Collections.ObjectModel;

namespace ProductoAppMAUI;

public partial class ResenaViewPage : ContentPage
{
    private readonly APIService _APIService;
    public ResenaViewPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Resena> ListaResena = await _APIService.GetResenas(Preferences.Default.Get("ProductId", "0").ToString());
        if (ListaResena != null && ListaResena.Count > 0)
        {
            var resenas = new ObservableCollection<Resena>(ListaResena);
            ListaResenas.ItemsSource = resenas;
            //ListaResenas.IsVisible = true;
            //NoResenasLabel.IsVisible = false;
        }
        else
        {
            //ListaResenas.IsVisible = false;
            //NoResenasLabel.IsVisible = true;
        }
    }
}