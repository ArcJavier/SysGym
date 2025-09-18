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
    public class RolRepository : IRolRepository
    {
        private readonly AppDBContext _context;
        public RolRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Rol> AddRolAsync(Rol rol)
        {
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }
        public async Task<bool> DeleteRolAsync(int id)
        {
            var rol = await _context.Rols.FindAsync(id);
            if (rol == null)
            {
                return false;
            }
            _context.Rols.Remove(rol);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Rol> GetRolByIdAsync(int id)
        {
            return await _context.Rols.FindAsync(id);
        }
        public async Task<IEnumerable<Rol>> GetRolsAsync()
        {
            return await _context.Rols.ToListAsync();
        }
        public async Task<Rol> UpdateRolAsync(Rol rol)
        {
            var existingRol = await _context.Rols.FindAsync(rol.IdRol);
            if (existingRol == null)
            {
                return null;
            }
            existingRol.Nombre = rol.Nombre;
            existingRol.Estado = rol.Estado;
            await _context.SaveChangesAsync();
            return existingRol;
        }
    }
}
