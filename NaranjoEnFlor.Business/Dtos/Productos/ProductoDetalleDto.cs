using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.Productos
{
    public class ProductoDetalleDto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public string Cantidad { get; set; }

        public string Estado { get; set; }
    }
}
