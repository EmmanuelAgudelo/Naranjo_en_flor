using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.Mesas
{
    public class MesaDetalleDto
    {
        public int Id { get; set; }
        public int Asientos { get; set; }
        public bool Reserva { get; set; }
        public bool Estado { get; set; }
    }
}
