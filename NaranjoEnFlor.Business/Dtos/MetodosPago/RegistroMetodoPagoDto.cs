using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.MetodosPago
{
    public class RegistroMetodoPagoDto
    {
        public int IdMetodoPago { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "El {0} debe ser minimo de {2} y maximo {1} caracteres", MinimumLength = 6)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
