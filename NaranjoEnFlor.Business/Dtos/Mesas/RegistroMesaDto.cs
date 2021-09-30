using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.Mesas
{
    public class RegistroMesaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La cantidad de asientos es requerida")]
        [Display(Name = "Asientos de la mesa")]
        [Range(1, 9999, ErrorMessage = "Rango inválido")]
        public int ? Asientos { get; set; }
        public bool Reserva { get; set; }
        public bool Estado { get; set; }
    }
}
