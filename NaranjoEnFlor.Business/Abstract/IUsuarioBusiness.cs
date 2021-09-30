using NaranjoEnFlor.Business.Dtos.Usuarios;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Abstract
{
    public interface IUsuarioBusiness
    {
        Task<IEnumerable<UsuarioDto>> ObtenerListaUsuarios();
        Task<string> Crear(RegistrarUsuarioDto registrarUsuarioDto);

        Task<UsuarioDto> ObtenerUsuarioDtoPorEmail(string email);

        Task<Usuario> ObtenerUsuarioId(string id);

        


        Task<string> CambiarEstado(Usuario usuario);
        
    }
}
