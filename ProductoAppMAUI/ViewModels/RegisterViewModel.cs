using CommunityToolkit.Mvvm.ComponentModel;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductoAppMAUI.ViewModels
{
    public partial class RegisterViewModel
    {
        private readonly APIService _APIService;
        private User _newUser;
        public string NombreText { get; set; }
        public string ApellidosText {  get; set; }
        public string CorreoText {  get; set; }
        public string PasswordText {  get; set; }

        public RegisterViewModel()
        {
            _APIService = new APIService();
            _newUser = new User();
            //CorreoText = _newUser.Correo;
            //PasswordText = _newUser.Password;
        }

        public ICommand LoginView =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopAsync();
            });

        public ICommand RegistrarUsuario =>
                new Command(async () =>
                {
                    //Verificar que el formulario no está vacío
                    if (string.IsNullOrEmpty(NombreText) || string.IsNullOrEmpty(ApellidosText) || string.IsNullOrEmpty(CorreoText) || string.IsNullOrEmpty(PasswordText))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Debe completar todos los campos.", "OK");
                        return;
                    } else
                    {
                        User usuario = new User()
                        {
                            Nombre = NombreText,
                            Apellidos = ApellidosText,
                            Correo = CorreoText,
                            Contrasenia = PasswordText,
                            Rol = "usuario"
                        };
                        User user2 = await _APIService.PostUser(usuario);
                        if (user2 != null)
                        {
                            await App.Current.MainPage.DisplayAlert("Usuario Agregado", "El registro fue exitoso.", "OK");
                            await App.Current.MainPage.Navigation.PopAsync();
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "No se pudo registrar el usuario", "OK");
                            return;
                        }
                    }
                });
    }
}
