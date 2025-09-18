using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencias
using SysGym.Domain.Entities;
using SysGym.Domain.Repositories;
using SysGym.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SysGym.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDBContext _context;
        public UsuarioRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            var existingUsuario = await _context.Usuarios.FindAsync(usuario.IdUsuario);
            if (existingUsuario == null)
            {
                return null;
            }
            existingUsuario.IdRol = usuario.IdRol;
            existingUsuario.Nombre = usuario.Nombre;
            existingUsuario.CorreoE = usuario.CorreoE;
            existingUsuario.Contrasenia = usuario.Contrasenia;
            existingUsuario.Activo = usuario.Activo;
            existingUsuario.Estado = usuario.Estado;
            await _context.SaveChangesAsync();
            return existingUsuario;
        }
    }
}
