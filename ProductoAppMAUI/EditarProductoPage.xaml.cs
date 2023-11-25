using ProductoAppMAUI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductoAppMAUI
{
    public partial class EditarProductoPage : ContentPage
    {
        private Producto _producto;
        public EditarProductoPage()
        {
            InitializeComponent();
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
                _producto.Precio = Int32.Parse(PrecioEntry.Text);
                _producto.Descripcion = DescripcionEntry.Text;
            }
            else
            {

                Producto producto = new Producto
                {
                    IdProducto = 0,
                    Nombre = NombreEntry.Text,
                    Descripcion = DescripcionEntry.Text,
                    Precio = Int32.Parse(PrecioEntry.Text)
                };

                Utils.Utils.ListaProductos.Add(producto);
            }
            await Navigation.PopAsync();

        }

    }
}
