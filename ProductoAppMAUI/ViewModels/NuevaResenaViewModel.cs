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
        public Producto Producto { get; set; }
        public NuevaResenaViewModel(Producto producto)
        {
            Producto = producto;
        }
        public ICommand EnviarResenas =>
            new Command(async () =>
            {

                Resena resena = new Resena()
                {
                    ViniloId = Convert.ToInt32(IdViniloEntry.Text),
                    Usuario = UsuarioEntry.Text,
                    Texto = TextoEntry.Text
                };

                await _APIService.PostResena(resena);
                await App.Current.MainPage.Navigation.PopAsync();
            });
    }
    
}
