using Microsoft.EntityFrameworkCore;
using NaranjoEnFlor.Business.Abstract;
using NaranjoEnFlor.Business.Dtos.MetodosPago;
using NaranjoEnFlor.DAL;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Business
{
    public class MetodoPagoBusiness:IMetodoPagoBusiness
    {
        private readonly AppDbContext _context;

        public MetodoPagoBusiness(AppDbContext AppDbContext)
        {
            _context = AppDbContext;
        }

        public async Task<IEnumerable<MetodoPagoDetalleGestionarDto>> ObtenerMetodoPago()
        {
            List<MetodoPagoDetalleGestionarDto> listametodoPagoDetalleGestionarDto = new();

            var metodoPago = await _context.metodosPago.ToListAsync();
            metodoPago.ForEach(c =>
            {
                MetodoPagoDetalleGestionarDto metodoPagoDetalleGestionarDto = new()
                {
                    IdMetodoPago = c.IdMetodoPago,
                    Nombre = c.Nombre,
                    Estado = ObtenerEstado(c.Estado)

                };
                listametodoPagoDetalleGestionarDto.Add(metodoPagoDetalleGestionarDto);
            });
            return listametodoPagoDetalleGestionarDto;
        }

        private string ObtenerEstado(bool estado)
        {
            if (estado)
                return "Activo";
            else
                return "Deshabilitado";
        }

        public void crearMetodoPago(RegistroMetodoPagoDto registroMetodoPagoDto)
        {
            if (registroMetodoPagoDto == null)
                throw new ArgumentNullException(nameof(registroMetodoPagoDto));
            registroMetodoPagoDto.Estado = true;
            MetodoPago metodoPago = new()
            {
                IdMetodoPago = registroMetodoPagoDto.IdMetodoPago,
                Nombre = registroMetodoPagoDto.Nombre,
                Estado = registroMetodoPagoDto.Estado
            };
            _context.Add(metodoPago);
        }

        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<MetodoPago> ObtenerMetodoPagoId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _context.metodosPago.FirstOrDefaultAsync(m => m.IdMetodoPago == id);
        }

        public void Editar(MetodoPago metodoPago)
        {
            if (metodoPago == null)
                throw new ArgumentNullException(nameof(metodoPago));
            _context.Update(metodoPago);
        }

        public void Eliminar(MetodoPago metodoPago)
        {
            if (metodoPago == null)
                throw new ArgumentNullException(nameof(metodoPago));
            _context.Remove(metodoPago);
        }

        public Task<IEnumerable<MetodoPago>> ObtenerMetodosPago()
        {
            throw new NotImplementedException();
        }

        public void CrearMetodoPago(MetodoPago MetodoPago)
        {
            throw new NotImplementedException();
        }
    }
}
