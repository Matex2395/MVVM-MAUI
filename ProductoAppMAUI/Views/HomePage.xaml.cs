using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using System.Windows.Input;

namespace ProductoAppMAUI;

public partial class HomePage : ContentPage
{
    private readonly string _username;
    public HomePage()
    {
        InitializeComponent();
        _username = Preferences.Get("username", "0");
        BindingContext = new HomeViewModel();
    }

    private async void ValidarLogin()
    {
        if (_username.Equals("0"))
        {
            await DisplayAlert("¡Bienvenido!", "Bienvenido a Gliss Vinyls, Inicia Sesión en tu cuenta para continuar", "OK");
        } else
        {
            await App.Current.MainPage.Navigation.PushAsync(new ProductoPage());
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ValidarLogin();
    }
}