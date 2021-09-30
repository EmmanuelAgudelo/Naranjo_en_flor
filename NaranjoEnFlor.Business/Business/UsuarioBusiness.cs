using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NaranjoEnFlor.Business.Abstract;
using NaranjoEnFlor.Business.Dtos.Usuarios;
using NaranjoEnFlor.DAL;
using NaranjoEnFlor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaranjoEnFlor.Business.Business
{
    public class UsuarioBusiness: IUsuarioBusiness
    {
        private readonly UserManager<Usuario> _userManager;
        

        public UsuarioBusiness(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
            
        }

        public async Task<IEnumerable<UsuarioDto>> ObtenerListaUsuarios()
        {
            List<UsuarioDto> listaUsuarioDtos = new();
            var usuarios = await _userManager.Users.ToListAsync();
            usuarios.ForEach(usuario =>
            {
                UsuarioDto usuarioDto = new()
                {
                    nombre = usuario.nombre,
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Estado = usuario.Estado
                };
                listaUsuarioDtos.Add(usuarioDto);

            });
            return listaUsuarioDtos;

        }

        public async Task<string> Crear(RegistrarUsuarioDto registrarUsuarioDto)
        {
            if (registrarUsuarioDto == null)
                throw new ArgumentNullException(nameof(registrarUsuarioDto));
            Usuario usuario = new()
            {
                nombre = registrarUsuarioDto.nombre,
                UserName = registrarUsuarioDto.Email,
                Email = registrarUsuarioDto.Email,
                Estado = true,
            };
            var resultado = await _userManager.CreateAsync(usuario, registrarUsuarioDto.Password);
            if (resultado.Errors.Any())
                return "ErrorPassword";
            if (resultado.Succeeded)
                return usuario.Id;
            return null;
        }

        public async Task<UsuarioDto> ObtenerUsuarioDtoPorEmail(string email)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));
            var usuario = await _userManager.FindByEmailAsync(email);
            if (usuario != null)
            {
                UsuarioDto usuarioDto = new()
                {
                    nombre = usuario.nombre,
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Estado = usuario.Estado
                };
                return usuarioDto;
            }
            return null;
        }

        public async Task<Usuario> ObtenerUsuarioId(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _userManager.FindByIdAsync(id);
        }

        

        public async Task<string> CambiarEstado(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));
            var resultado = await _userManager.UpdateAsync(usuario);

            if (resultado.Succeeded)
                return "Ok";
            return "Fallo";
        }

        




    }
}

