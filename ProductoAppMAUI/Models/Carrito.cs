using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoAppMAUI.Models
{
    public class Carrito
    {
        public int IdProductoEnCarrito { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
