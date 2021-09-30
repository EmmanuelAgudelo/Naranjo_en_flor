using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.Facturas
{
    public class FacturaDetalleDto
    {
        public int Codigo { get; set; }

        public DateTime Fecha { get; set; }

        public int ProductoId { get; set; }

        public int MetodoPagoId { get; set; }

        public int MesaId { get; set; }

        public int Total { get; set; }

        public string Estado { get; set; }

        public string producto { get; set; }

        public string metodoDePago { get; set; }

        public int mesa { get; set; }
    }
}
