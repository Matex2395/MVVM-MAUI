using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;

namespace ProductoAppMAUI
{
    public partial class NuevoProductoPage : ContentPage
    {
        private readonly APIService _APIService;
        
        //private readonly Producto _producto;
        public NuevoProductoPage(APIService apiservice)
        {
            InitializeComponent();
            _APIService = apiservice;

        }


        private async void OnClickSeleccionarImagen(object sender, EventArgs e)
        {
            var imagenBase64 = await OnClickSeleccionarImagenLogic();
            // Haz algo con la imagenBase64 si es necesario...
        }

        private async Task<string> OnClickSeleccionarImagenLogic()
        {
            var file = await MediaPicker.PickPhotoAsync();
            if (file != null)
            {
                using (var stream = await file.OpenReadAsync())
                {
                    byte[] buffer = new byte[stream.Length];
                    await stream.ReadAsync(buffer, 0, (int)stream.Length);
                    return Convert.ToBase64String(buffer);
                }
            }
            return null;
        }
        private async void OnClickGuardarProducto(object sender, EventArgs e)
        {

            //Verificar que el formulario no está vacío
            if (string.IsNullOrEmpty(NombreEntry.Text) || string.IsNullOrEmpty(DescripcionEntry.Text) || string.IsNullOrEmpty(PrecioEntry.Text))
            {
                await DisplayAlert("Error", "Debe completar todos los campos.", "OK");
                return;
            }
            
            //random foto
            Random rnd = new Random();
            int num = rnd.Next(1, 15);
            string foto="vinilo1.png";
            switch (num)
            {
                    case 1:
                        foto = "vinilo1.png";
                    break;
                    case 2:
                        foto = "vinilo2.png";
                        break;
                    case 3:
                        foto = "vinilo3.png";
                    break;
                    case 4:
                        foto = "vinilo4.png";
                    break;
                    case 5:
                        foto = "vinilo5.png";
                    break;
                    case 6:
                        foto = "vinilo6.png";
                    break;
                    case 7:
                        foto = "vinilo7.png";
                    break;
                    case 8:
                        foto = "vinilo8.png";
                    break;
                    case 9:
                        foto = "vinilo9.png";
                    break;
                    case 10:
                        foto = "vinilo10.png";
                    break;
                    case 11:
                        foto = "vinilo11.png";
                    break;
                    case 12:
                        foto = "vinilo12.png";
                    break;
                    case 13:
                        foto = "vinilo13.png";
                    break;
                    case 14:
                        foto = "vinilo14.png";
                    break;                
            }

            Producto producto = new Producto()
            {
                IdProducto = 0,
                Nombre = NombreEntry.Text,
                Descripcion = DescripcionEntry.Text,
                Precio = Convert.ToDecimal(PrecioEntry.Text),
                Stock = Convert.ToInt32(StockEntry.Text),
                Imagen = foto,
            };

            await _APIService.PostProducto(producto);
            await DisplayAlert("Producto agregado", "El producto se agregó correctamente.", "OK");
            await Navigation.PopAsync();
          
        }
        

        



    }
}
