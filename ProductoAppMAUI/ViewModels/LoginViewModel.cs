using ProductoAppMAUI.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductoAppMAUI.Models;

namespace ProductoAppMAUI.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private APIService _APIService;
        [ObservableProperty]
        public string correo;
        [ObservableProperty]
        public string password;
        public LoginViewModel()
        {
            
        }
        public void IniciarAPIService(APIService apiservice)
        {
            _APIService = apiservice;
        }

        public async Task<bool> IniciarSesion()
        {
            User user2 = await _APIService.GetUser(Correo,Password);
            if (user2 != null)
            {
                Preferences.Set("username", user2.Nombre);
                Preferences.Set("IdUser", user2.IdUsuario.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
