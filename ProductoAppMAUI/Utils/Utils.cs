using ProductoAppMAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoAppMAUI.Utils
{
    internal class Utils
    {

        static public ObservableCollection<Producto> ListaProductos = new ObservableCollection<Producto>()
        {
            new Producto{
                IdProducto = 1,
                Nombre = "Mouse",
                Descripcion = "Mouse inalámbrico",
                Precio = 100,
                Stock = 10,
                Imagen = "https://maxitec.vteximg.com.br/arquivos/ids/191618-1000-1000/maxitec-logitech-mouse-inalambrico-ergonomico-ergo-m575-910-005869-1.jpg?v=638304390883630000e"
            },
            new Producto
            {
                IdProducto = 2,
                Nombre = "Teclado",
                Descripcion = "Teclado inalámbrico",
                Precio = 100,
                Stock = 10,
                Imagen = "https://i0.wp.com/www.tecnosmart.com.ec/wp-content/uploads/2021/08/TECLADO-RAZER-HUNTSMAN-MINI-60-OPTICAL-CHROMA-RGB-BLACK-PURPLE-SWITCH-RZ03-03390500-R3U1_TECLADOS_1237_1-1.jpeg?fit=1024%2C526&ssl=1"
            }

        };
    }
}
