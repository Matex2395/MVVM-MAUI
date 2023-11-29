//using Java.Lang;
using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
//using static Android.Util.EventLogTags;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductoAppMAUI
{
    public partial class EditarProductoPage : ContentPage
    {
        private Producto _producto;

        private readonly APIService _APIService;
        public EditarProductoPage(APIService apiservice)
        {
            InitializeComponent();
            _APIService = apiservice;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _producto = BindingContext as Producto;
            if (_producto != null)
            {
                NombreEntry.Text = _producto.Nombre;
                PrecioEntry.Text = _producto.Precio.ToString();
                DescripcionEntry.Text = _producto.Descripcion;
            }
        }


        private async void OnClickEditarProducto(object sender, EventArgs e)
        {
            if (_producto != null)
            {
                _producto.Nombre = NombreEntry.Text;
                _producto.Descripcion = DescripcionEntry.Text;
                _producto.Precio = Convert.ToDecimal(PrecioEntry.Text);
                await _APIService.PutProducto(_producto.IdProducto, _producto);
            }
            else
            {

                Producto producto = new Producto
                {
                    IdProducto = 0,
                    Nombre = NombreEntry.Text,
                    Descripcion = DescripcionEntry.Text,
                    Precio = Convert.ToDecimal(PrecioEntry.Text),
                };

                await _APIService.PostProducto(producto);

                //Utils.Utils.ListaProductos.Add(producto);
            }
            await Navigation.PopAsync();


        }

    }
}
