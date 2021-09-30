using Microsoft.EntityFrameworkCore;
using NaranjoEnFlor.Business.Abstract;
using NaranjoEnFlor.Business.Dtos.ReservaDeMesa;
using NaranjoEnFlor.DAL;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Business
{
    public class ReservaDeMesaBusiness: IReservaDeMesaBusiness
    {
        private readonly AppDbContext _context;

        public ReservaDeMesaBusiness(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservaDeMesaDetalleGestionarDto>> ObtenerReservasDeMesas()
        {
            List<ReservaDeMesaDetalleGestionarDto> listaReservaDeMesaDetalleGestionarDto = new();

            var Reservas = await _context.reservaDeMesas.Include(x => x.usuario).Include(x => x.mesa).ToListAsync();
            Reservas.ForEach(x =>
            {
                ReservaDeMesaDetalleGestionarDto ReservaDeMesaDetalleGestionarDto = new()
                {
                    Id = x.Id,
                    UsuarioId = x.UsuarioId,
                    MesaId = x.MesaId,
                    nombreUsuario = x.usuario.nombre,
                    cantidadAsientos = x.mesa.Asientos
                };
                listaReservaDeMesaDetalleGestionarDto.Add(ReservaDeMesaDetalleGestionarDto);
            });
            return listaReservaDeMesaDetalleGestionarDto;
        }

        public void CrearReserva(RegistroReservaDeMesaDto registroReservaDeMesaDto)
        {
            if (registroReservaDeMesaDto == null)
                throw new ArgumentNullException(nameof(registroReservaDeMesaDto));

            ReservaDeMesa reservaDeMesa = new()
            {
                Id = registroReservaDeMesaDto.Id,
                UsuarioId = registroReservaDeMesaDto.UsuarioId,
                MesaId = registroReservaDeMesaDto.MesaId
            };
            
            _context.Add(reservaDeMesa);
        }

        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReservaDeMesa> ObtenerReservaId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _context.reservaDeMesas.Include(r => r.usuario).Include(r => r.mesa).FirstOrDefaultAsync(r => r.Id == id);
        }

        public void Eliminar(ReservaDeMesa reservaDeMesa)
        {
            if (reservaDeMesa == null)
                throw new ArgumentNullException(nameof(reservaDeMesa));
            _context.Remove(reservaDeMesa);
        }
    }
}
