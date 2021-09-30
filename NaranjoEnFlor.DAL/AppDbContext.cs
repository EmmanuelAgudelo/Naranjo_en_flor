using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        
        public DbSet<Factura> facturas { get; set; }
        public DbSet<Mesa> mesas { get; set; }
        public DbSet<MetodoPago> metodosPago { get; set; }
        public DbSet<Producto> productos { get; set; }

        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<ReservaDeMesa> reservaDeMesas { get; set; }
    }
}
