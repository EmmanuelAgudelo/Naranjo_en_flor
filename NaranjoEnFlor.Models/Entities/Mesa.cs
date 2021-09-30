using System;
using System.Collections.Generic;
using System.Text;

namespace NaranjoEnFlor.Models.Entities
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Asientos { get; set; }
        public bool Reserva { get; set; }
        public bool Estado { get; set; }
    }
}
