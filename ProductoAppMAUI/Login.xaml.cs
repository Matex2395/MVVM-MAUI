using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;

namespace ProductoAppMAUI;

public partial class Login : ContentPage
{
    private readonly APIService _APIService;

    public Login(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }

    private async void OnClickLogIn(object sender, EventArgs e)
    {
        //Verificar que el formulario no está vacío
        if (string.IsNullOrEmpty(Correo.Text) || string.IsNullOrEmpty(Contrasenia.Text))
        {
            await DisplayAlert("Error", "Debe completar todos los campos.", "OK");
            return;
        }

        string username = Correo.Text;
        string password = Contrasenia.Text;
        User user = new User
        {
            Correo = username,
            Contrasenia = password,
        };


        User user2 = await _APIService.GetUser(user);
        if (user2 != null)
        {
            Preferences.Set("username", user2.Nombre);
            Preferences.Set("IdUser", user2.IdUsuario);
            await Navigation.PushAsync(new ProductoPage(_APIService));
        }
        else 
        {
            await DisplayAlert("Error", "Usuario o Contraseña no encontrados, verifique que los ingresó correctamente", "OK");
            return;
        }
    }

    private async void OnClickRegisterView(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Register(_APIService));
    }
}