using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;

namespace ProductoAppMAUI;

public partial class Register : ContentPage
{
    private readonly APIService _APIService;
    public Register(APIService apiservice)
	{
        InitializeComponent();
        _APIService = apiservice;
    }

    private async void OnClickLogInView(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnClickRegister(object sender, EventArgs e)
    {
        //Verificar que el formulario no está vacío
        if (string.IsNullOrEmpty(Nombre.Text) || string.IsNullOrEmpty(Apellidos.Text) || string.IsNullOrEmpty(Correo.Text) || string.IsNullOrEmpty(Contrasenia.Text))
        {
            await DisplayAlert("Error", "Debe completar todos los campos.", "OK");
            return;
        }

        User usuario = new User()
        {
            Nombre = Nombre.Text,
            Apellidos = Apellidos.Text,
            Correo = Correo.Text,
            Contrasenia = Contrasenia.Text,
            Rol = "usuario"
        };


        await _APIService.PostUser(usuario);
        await DisplayAlert("Usuario Agregado", "El registro fue exitoso.", "OK");
        await Navigation.PopAsync();
    }
}