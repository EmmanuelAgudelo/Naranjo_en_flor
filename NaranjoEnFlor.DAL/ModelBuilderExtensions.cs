using Microsoft.EntityFrameworkCore;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MetodoPago>().HasData(
                new MetodoPago
                {
                    IdMetodoPago = 1,
                    Nombre = "Efectivo"
                },
                new MetodoPago
                {
                    IdMetodoPago = 2,
                    Nombre = "transferencia"
                }
                );
                
        }
    }        
}
