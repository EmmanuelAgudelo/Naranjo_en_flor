using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.Mesas
{
    public class MesaDetalleGestionarDto
    {
        public int Id { get; set; }
        public int Asientos { get; set; }
        public string Reserva { get; set; }
        public string Estado { get; set; }
    }
}
