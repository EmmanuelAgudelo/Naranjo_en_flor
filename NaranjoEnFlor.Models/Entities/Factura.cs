using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NaranjoEnFlor.Models.Entities
{
    public class Factura
    {
        [Key]
        public int Codigo { get; set; }

        public DateTime Fecha { get; set; }

        public int ProductoId { get; set; }

        public int MetodoPagoId { get; set; }

        public int MesaId { get; set; }

        public int Total { get; set; }

        public bool Estado { get; set; }

        //Llaves Foraneas
        public virtual Producto Producto { get; set; }

        public virtual MetodoPago MetodosPago { get; set; }

        public virtual Mesa Mesas { get; set; }
    }
}
