using Microsoft.EntityFrameworkCore;
using NaranjoEnFlor.Business.Abstract;
using NaranjoEnFlor.Business.Dtos.Facturas;
using NaranjoEnFlor.DAL;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Business
{
    public class FacturaBusiness: IFacturaBusiness
    {
        private readonly AppDbContext _context;

        public FacturaBusiness(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FacturaDetalleGestionarDto>> ObtenerFacturas()
        {
            List<FacturaDetalleGestionarDto> listaFacturaDetalleGestionarDto = new();

            var factura = await _context.facturas.Include(x => x.MetodosPago).Include(x => x.Mesas).Include(x => x.Producto).ToListAsync();
            factura.ForEach(f =>
            {
                FacturaDetalleGestionarDto facturaDetalleGestionarDto = new()
                {
                    Codigo = f.Codigo,
                    Fecha = f.Fecha,
                    producto = f.Producto.Nombre,
                    MesaId = f.MesaId,
                    mesa = f.Mesas.Asientos,
                    MetodoPagoId = f.MetodoPagoId,
                    metodoDePago = f.MetodosPago.Nombre,
                    Total = f.Total,
                    Estado = ObtenerEstado(f.Estado)
                };
                listaFacturaDetalleGestionarDto.Add(facturaDetalleGestionarDto);
            });
            return listaFacturaDetalleGestionarDto;
        }

        private string ObtenerEstado(bool estado)
        {
            if (estado)
                return "Activo";
            else
                return "Deshabilitado";
        }

        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Factura> ObtenerFacturaId(int? codigo)
        {
            if (codigo == null)
                throw new ArgumentNullException(nameof(codigo));
            return await _context.facturas.Include(r => r.MetodosPago).Include(r => r.Mesas).Include(r => r.Producto).FirstOrDefaultAsync(r => r.Codigo == codigo);

        }

        public void CrearFactura(RegistroFacturaDto registroFacturaDto)
        {
            if (registroFacturaDto == null)
                throw new ArgumentNullException(nameof(registroFacturaDto));
            registroFacturaDto.Estado = true;
            Factura factura = new()
            {
                Codigo = registroFacturaDto.Codigo,
                Fecha = registroFacturaDto.Fecha,
                ProductoId = registroFacturaDto.ProductoId,
                MetodoPagoId = registroFacturaDto.MetodoPagoId,
                MesaId = registroFacturaDto.MesaId,
                Total = registroFacturaDto.Total,
                Estado = registroFacturaDto.Estado
            };
            _context.Add(factura);
        }

        public void Editar(Factura factura)
        {
            if (factura == null)
                throw new ArgumentNullException(nameof(factura));
            _context.Update(factura);
        }
    }
}
