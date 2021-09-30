using Microsoft.EntityFrameworkCore;
using NaranjoEnFlor.Business.Abstract;
using NaranjoEnFlor.Business.Dtos.Productos;
using NaranjoEnFlor.DAL;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Business
{
    public class ProductoBusiness: IProductoBusiness
    {
        private readonly AppDbContext _context;

        public ProductoBusiness(AppDbContext AppDbContext)
        {
            _context = AppDbContext;
        }

        public async Task<IEnumerable<ProductoDetalleGestionarDto>> ObtenerProductos()
        {
            List<ProductoDetalleGestionarDto> listaProductoDetalleGestionarDto = new();

            var productos = await _context.productos.ToListAsync();
            productos.ForEach(c =>
            {
                ProductoDetalleGestionarDto productoDetalleGestionarDto = new()
                {
                    IdProducto = c.IdProducto,
                    Nombre = c.Nombre,
                    Cantidad = c.Cantidad,
                    Estado = ObtenerEstado(c.Estado)

                };
                listaProductoDetalleGestionarDto.Add(productoDetalleGestionarDto);
            });
            return listaProductoDetalleGestionarDto;
        }

        private string ObtenerEstado(bool estado)
        {
            if (estado)
                return "Activo";
            else
                return "Deshabilitado";
        }

        public void CrearProducto(RegistroProductoDto registroProductoDto)
        {
            if (registroProductoDto == null)
                throw new ArgumentNullException(nameof(registroProductoDto));
            registroProductoDto.Estado = true;
            Producto producto = new() 
            {
                IdProducto = registroProductoDto.IdProducto,
                Nombre = registroProductoDto.Nombre,
                Cantidad = registroProductoDto.Cantidad,
                Estado = registroProductoDto.Estado
            };
            _context.Add(producto);
        }

        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Producto> ObtenerProductoId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _context.productos.FirstOrDefaultAsync(p => p.IdProducto == id);
        }

        public void Editar(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));
            _context.Update(producto);
        }
    }
}
