using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NaranjoEnFlor.Models.Entities
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(40, ErrorMessage = "El {0} debe ser minimo de {2} y maximo {1} caracteres", MinimumLength = 5)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La cantidad es requerida")]
        
        [Display(Name = "cantidad")]
        public string Cantidad { get; set; }

        public bool Estado { get; set; }
    }
}
