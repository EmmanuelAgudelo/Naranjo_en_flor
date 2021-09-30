using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.ReservaDeMesa
{
    public class RegistroReservaDeMesaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El usuario es requerido")]
        [Display(Name = "Usuario")]
        public string UsuarioId { get; set; }

        [Required(ErrorMessage = "La mesa es requerido")]
        [Display(Name = "Mesa")]
        public int MesaId { get; set; }
    }
}
