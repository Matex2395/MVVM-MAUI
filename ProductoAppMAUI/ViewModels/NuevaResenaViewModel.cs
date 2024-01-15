using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoAppMAUI.ViewModels
{
    public class NuevaResenaViewModel
    {
        private readonly APIService _APIService;
        public string IdViniloText { get; set; }
        public string UsernameText { get; set; }
        public string ComentarioText {  get; set; }
        public Producto _producto { get; set; }
        public NuevaResenaViewModel(Producto producto)
        {
            _APIService = new APIService();
            _producto = producto;
            IdViniloText = _producto.IdProducto.ToString();
            UsernameText = Preferences.Get("username", "0");
            ComentarioText = "";
        }
        public ICommand EnviarResena =>
            new Command(async () =>
            {
                //Verificar que el formulario no está vacío
                if (string.IsNullOrWhiteSpace(ComentarioText))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Debe completar todos los campos.", "OK");
                    return;
                }
                else
                {
                    Resena resena = new Resena()
                    {
                        ViniloId = Convert.ToInt32(IdViniloText),
                        Usuario = UsernameText,
                        Texto = ComentarioText
                    };

                    await _APIService.PostResena(resena);
                    await App.Current.MainPage.DisplayAlert("Reseña Agregada", "Su reseña se publicó correctamente.", "OK");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });
    }
    
}
