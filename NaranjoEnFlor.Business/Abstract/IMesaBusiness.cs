using NaranjoEnFlor.Business.Dtos.Mesas;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Abstract
{
    public interface IMesaBusiness
    {
        Task<IEnumerable<MesaDetalleGestionarDto>> ObtenerMesas();

        void CrearMesa(RegistroMesaDto registroMesaDto);

        Task<bool> GuardarCambios();

        Task<Mesa> ObtenerMesaId(int? id);

        void Editar(Mesa mesa);

        Task<IEnumerable<MesaDetalleGestionarDto>> ObtenerMesasDisponibles();
    }
}
