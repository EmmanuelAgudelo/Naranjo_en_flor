using NaranjoEnFlor.Business.Dtos.Productos;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Abstract
{
    public interface IProductoBusiness
    {
        Task<IEnumerable<ProductoDetalleGestionarDto>> ObtenerProductos();

        void CrearProducto(RegistroProductoDto registroProductoDto);

        Task<bool> GuardarCambios();

        Task<Producto> ObtenerProductoId(int? id);

        void Editar(Producto producto);

       
    }
}
