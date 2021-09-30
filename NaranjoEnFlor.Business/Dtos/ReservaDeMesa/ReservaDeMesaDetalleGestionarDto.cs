using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.ReservaDeMesa
{
    public class ReservaDeMesaDetalleGestionarDto
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }

        public int MesaId { get; set; }

        public string nombreUsuario { get; set; }

        public int cantidadAsientos { get; set; }
    }
}
