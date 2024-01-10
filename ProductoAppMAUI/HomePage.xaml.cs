using ProductoAppMAUI.Service;

namespace ProductoAppMAUI;

public partial class HomePage : ContentPage
{
    private readonly APIService _APIService;
    public HomePage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    private async void ValidarLogin()
    {
        if ((Preferences.Get("username", "0").Equals("0")))
        {
            await DisplayAlert("¡Bienvenido!", "Bienvenido a Gliss Vinyls, Inicia Sesión en tu cuenta para continuar", "OK");
        } else
        {
            await Navigation.PushAsync(new ProductoPage(_APIService));
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ValidarLogin();
        string username = Preferences.Get("username", "0");
    }

    private async void EntrarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login(_APIService));
    }
}