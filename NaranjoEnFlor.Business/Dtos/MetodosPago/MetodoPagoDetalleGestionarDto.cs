﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.MetodosPago
{
    public class MetodoPagoDetalleGestionarDto
    {
        public int IdMetodoPago { get; set; }

        public string Nombre { get; set; }

        public string Estado { get; set; }
    }
}
