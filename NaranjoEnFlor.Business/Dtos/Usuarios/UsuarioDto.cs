using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Dtos.Usuarios
{
    public class UsuarioDto
    {
        public string nombre { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
    }
}
