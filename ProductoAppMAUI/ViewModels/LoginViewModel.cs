using ProductoAppMAUI.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductoAppMAUI.Models;
using System.Windows.Input;
using PropertyChanged;

namespace ProductoAppMAUI.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        private APIService _APIService;
        public string CorreoText { get; set; }
        public string PasswordText { get; set; }
        public LoginViewModel()
        {
            _APIService = new APIService();
            CorreoText = "";
            PasswordText = "";
        }

        public ICommand LoginButton =>
            new Command(async () =>
            {
                //Verificar que el formulario no está vacío
                if (string.IsNullOrWhiteSpace(CorreoText) || string.IsNullOrWhiteSpace(PasswordText))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Debe completar todos los campos.", "OK");
                    return;
                }
                else
                {
                    User user2 = await _APIService.GetUser(CorreoText, PasswordText);
                    if (user2 != null)
                    {
                        Preferences.Set("username", user2.Nombre);
                        Preferences.Set("IdUser", user2.IdUsuario.ToString());
                        await App.Current.MainPage.Navigation.PushAsync(new ProductoPage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña no encontrados, verifique que los ingresó correctamente", "OK");
                        return;
                    }
                }
            });

        public ICommand RegisterButton =>
                new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new Register());
                });
    }
}
