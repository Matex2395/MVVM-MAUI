using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using System.Windows.Input;

namespace ProductoAppMAUI;

public partial class Login : ContentPage
{
    private readonly APIService _APIService;
    private readonly LoginViewModel _viewModel;
    public Login(APIService APIService)
    {
        InitializeComponent();
        _APIService = APIService;
        _viewModel = new LoginViewModel();
        _viewModel.IniciarAPIService(APIService);
        BindingContext = _viewModel;
    }

    public ICommand LoginButton =>
            new Command(async () =>
            {
                //Verificar que el formulario no está vacío
                if (string.IsNullOrEmpty(Correo.Text) || string.IsNullOrEmpty(Contrasenia.Text))
                {
                    await DisplayAlert("Error", "Debe completar todos los campos.", "OK");
                    return;
                }
                bool res = await _viewModel.IniciarSesion();
                if (res)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ProductoPage(_APIService));
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o Contraseña no encontrados, verifique que los ingresó correctamente", "OK");
                    return;
                }
            });

    public ICommand RegisterButton =>
            new Command(async () =>
            {
                await Navigation.PushAsync(new Register(_APIService));
            });
}