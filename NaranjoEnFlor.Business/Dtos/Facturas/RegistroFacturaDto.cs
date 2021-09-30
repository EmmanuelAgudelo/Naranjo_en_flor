using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.Facturas
{
    public class RegistroFacturaDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El producto es requerido")]
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El método de pago es requerido")]
        [Display(Name = "Método de Pago")]
        public int MetodoPagoId { get; set; }

        [Required(ErrorMessage = "El registro de mesa es requerido")]
        [Display(Name = "Mesa")]
        public int MesaId { get; set; }

        [Required(ErrorMessage = "El Total es requerido")]
        [Display(Name = "Valor total")]
        public int Total { get; set; }

        public bool Estado { get; set; }

    }
}
