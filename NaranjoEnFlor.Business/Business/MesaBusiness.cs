using Microsoft.EntityFrameworkCore;
using NaranjoEnFlor.Business.Abstract;
using NaranjoEnFlor.Business.Dtos.Mesas;
using NaranjoEnFlor.DAL;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Business
{
    public class MesaBusiness : IMesaBusiness
    {
        private readonly AppDbContext _context;

        public MesaBusiness(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<IEnumerable<MesaDetalleGestionarDto>> ObtenerMesas()
        {
            List<MesaDetalleGestionarDto> listaMesaDetalleGestionarDto = new();

            var mesas = await _context.mesas.ToListAsync();
            mesas.ForEach(x =>
            {
                MesaDetalleGestionarDto mesaDetalleGestionarDto = new()
                {
                    Id = x.Id,
                    Asientos = x.Asientos,
                    Reserva = ObtenerReservaMesa(x.Reserva),
                    Estado = ObtenerEstado(x.Estado)
                };
                listaMesaDetalleGestionarDto.Add(mesaDetalleGestionarDto);
            });
            return listaMesaDetalleGestionarDto;
        }
        private string ObtenerReservaMesa(bool estadoReserva)
        {
            if (estadoReserva)
                return "Reservada";
            else
                return "No Reservada";
        }
        private string ObtenerEstado(bool estado)
        {
            if (estado)
                return "Activo";
            else
                return "Deshabilitado";
        }

        public void CrearMesa(RegistroMesaDto registroMesaDto)
        {
            if (registroMesaDto == null)
                throw new ArgumentNullException(nameof(registroMesaDto));
                registroMesaDto.Estado = true;
                Mesa mesa = new()
            {
                Id = registroMesaDto.Id,
                Asientos = registroMesaDto.Asientos.Value,
                Reserva = registroMesaDto.Reserva,
                Estado = registroMesaDto.Estado
            };
            _context.Add(mesa);
        }

        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Mesa> ObtenerMesaId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _context.mesas.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Editar(Mesa mesa)
        {
            if (mesa == null)
                throw new ArgumentNullException(nameof(mesa));
            _context.Update(mesa);
        }

        public async Task<IEnumerable<MesaDetalleGestionarDto>> ObtenerMesasDisponibles()
        {
            List<MesaDetalleGestionarDto> listaMesaDetalleGestionarDto = new();

            var mesas = await _context.mesas.Where(m => !m.Reserva).ToListAsync();
            mesas.ForEach(x =>
            {
                MesaDetalleGestionarDto mesaDetalleGestionarDto = new()
                {
                    Id = x.Id,
                    Asientos = x.Asientos,
                    Reserva = ObtenerReservaMesa(x.Reserva),
                    Estado = ObtenerEstado(x.Estado)
                };
                listaMesaDetalleGestionarDto.Add(mesaDetalleGestionarDto);
            });
            return listaMesaDetalleGestionarDto;
        }
    }
}

