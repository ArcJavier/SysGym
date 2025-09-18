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
    public class SucursalRepository : ISucursalRepository
    {
        private readonly AppDBContext _context;

        public SucursalRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Sucursal> AddSucursalAsync(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();
            return sucursal;
        }

        public async Task<bool> DeleteSucursalAsync(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return false;
            }

            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Sucursal> GetSucursalByIdAsync(int id)
        {
            return await _context.Sucursales.FindAsync(id);
        }

        public async Task<IEnumerable<Sucursal>> GetSucursalAsync()
        {
            return await _context.Sucursales.ToListAsync();
        }

        public async Task<Sucursal> UpdateSucursalAsync(Sucursal sucursal)
        {
            var existingSucursal = await _context.Sucursales.FindAsync(sucursal.IdSucursal);
            if (existingSucursal == null)
            {
                return null;
            }

            existingSucursal.Nombre = sucursal.Nombre;
            existingSucursal.Direccion = sucursal.Direccion;
            existingSucursal.Estado = sucursal.Estado;

            await _context.SaveChangesAsync();
            return existingSucursal;
        }
    }
}
