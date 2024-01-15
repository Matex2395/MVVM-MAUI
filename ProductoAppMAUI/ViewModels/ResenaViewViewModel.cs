using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoAppMAUI.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ResenaViewViewModel
    {
        private APIService _APIService;
        public ObservableCollection<Resena> ListaResenas { get; set; }
        public ResenaViewViewModel()
        {
            _APIService = new APIService();
        }

        public async void LoadResenas()
        {
            ListaResenas = new ObservableCollection<Resena>();
            var resenas = await _APIService.GetResenas(Preferences.Default.Get("ProductId", "0").ToString());
            foreach (var p in resenas)
            {
                ListaResenas.Add(p);
            }
        }
    }
}
