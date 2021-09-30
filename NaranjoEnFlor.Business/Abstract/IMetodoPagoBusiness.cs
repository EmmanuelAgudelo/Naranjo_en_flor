using NaranjoEnFlor.Business.Dtos.MetodosPago;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Abstract
{
    public interface IMetodoPagoBusiness
    {
        Task<IEnumerable<MetodoPagoDetalleGestionarDto>> ObtenerMetodoPago();
        void crearMetodoPago(RegistroMetodoPagoDto registroMetodoPagoDto);

        Task<bool> GuardarCambios();

        Task<MetodoPago> ObtenerMetodoPagoId(int? id);

        void Editar(MetodoPago MetodoPago);

    }
}
