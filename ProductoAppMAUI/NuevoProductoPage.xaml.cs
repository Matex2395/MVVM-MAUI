using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;

namespace ProductoAppMAUI
{
    public partial class NuevoProductoPage : ContentPage
    {
        private readonly APIService _APIService;
        private readonly Producto _producto;
        public NuevoProductoPage()
        {
            InitializeComponent();
            _APIService = new APIService();
        }



        private async void OnClickGuardarProducto(object sender, EventArgs e)
        {

            //Verificar que el formulario no está vacío
            if (string.IsNullOrEmpty(NombreEntry.Text) || string.IsNullOrEmpty(DescripcionEntry.Text) || string.IsNullOrEmpty(PrecioEntry.Text))
            {
                await DisplayAlert("Error", "Debe completar todos los campos.", "OK");
                return;
            }
            int id = Utils.Utils.ListaProductos.Count + 1;

            Producto producto = new Producto()
            {
                IdProducto = id,
                Nombre = NombreEntry.Text,
                Descripcion = DescripcionEntry.Text,
                Precio = Convert.ToDecimal(PrecioEntry.Text)               
            };

            await _APIService.PostProducto(producto);
          
        }

    }
}
