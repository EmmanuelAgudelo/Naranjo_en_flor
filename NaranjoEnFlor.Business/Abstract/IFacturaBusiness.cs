using NaranjoEnFlor.Business.Dtos.Facturas;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Abstract
{
    public interface IFacturaBusiness
    {
        Task<IEnumerable<FacturaDetalleGestionarDto>> ObtenerFacturas();

        Task<bool> GuardarCambios();

        Task<Factura> ObtenerFacturaId(int? codigo);

        void CrearFactura(RegistroFacturaDto registroFacturaDto);

        void Editar(Factura factura);
    }
}
