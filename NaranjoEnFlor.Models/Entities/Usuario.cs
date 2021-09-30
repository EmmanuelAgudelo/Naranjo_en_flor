using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Models.Entities
{
    public class Usuario: IdentityUser
    {
        public string nombre { get; set; }
        public bool Estado { get; set; }
    }
}
