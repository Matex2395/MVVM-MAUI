using ProductoAppMAUI.Models;

namespace ProductoAppMAUI
{
    public partial class NuevoProductoPage : ContentPage
    {
        public NuevoProductoPage()
        {
            InitializeComponent();
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

            Utils.Utils.ListaProductos.Add(new Producto
            {
                IdProducto = id,
                Nombre = NombreEntry.Text,
                Descripcion = DescripcionEntry.Text,
                Precio = Convert.ToDecimal(PrecioEntry.Text),
                Stock = 10,
                Imagen = "gazelle.png"
            });

            // Limpiar los campos de entrada después de agregar el producto
            NombreEntry.Text = string.Empty;
            DescripcionEntry.Text = string.Empty;
            PrecioEntry.Text = string.Empty;

            // Mostrar una alerta indicando que el producto se agregó correctamente
            await DisplayAlert("Éxito", "El producto se agregó correctamente.", "OK");

            await Navigation.PopAsync();
            
            
          
        }

    }
}
