using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Models.Entities
{
    public class ReservaDeMesa
    {
        public int Id{ get; set; }
        public string UsuarioId  { get; set; }

        public int MesaId { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual Mesa mesa { get; set; }
    }
}
