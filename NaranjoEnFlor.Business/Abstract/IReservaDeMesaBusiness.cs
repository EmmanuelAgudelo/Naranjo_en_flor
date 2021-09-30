using NaranjoEnFlor.Business.Dtos.ReservaDeMesa;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Abstract
{
    public interface IReservaDeMesaBusiness
    {
        Task<IEnumerable<ReservaDeMesaDetalleGestionarDto>> ObtenerReservasDeMesas();

        void CrearReserva(RegistroReservaDeMesaDto registroReservaDeMesaDto);

        Task<bool> GuardarCambios();

        Task<ReservaDeMesa> ObtenerReservaId(int? id);

        void Eliminar(ReservaDeMesa reservaDeMesa);
    }
}
