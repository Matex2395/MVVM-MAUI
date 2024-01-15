using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace ProductoAppMAUI;

public partial class ResenaViewPage : ContentPage
{
    public ResenaViewPage()
	{
		InitializeComponent();
        BindingContext = new ResenaViewViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as ResenaViewViewModel).LoadResenas();
    }
}