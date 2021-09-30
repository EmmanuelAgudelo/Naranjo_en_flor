using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NaranjoEnFlor.Models.Entities
{
    public class MetodoPago
    {
        [Key]
        public int IdMetodoPago { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "El {0} debe ser minimo de {2} y maximo {1} caracteres", MinimumLength = 6)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
