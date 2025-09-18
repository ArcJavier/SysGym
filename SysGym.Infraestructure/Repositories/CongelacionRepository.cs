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
    public class CongelacionRepository : ICongelacionRepository
    {
        private readonly AppDBContext _context;

        public CongelacionRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Congelacion> AddCongelacionAsync(Congelacion congelacion)
        {
            _context.Congelaciones.Add(congelacion);
            await _context.SaveChangesAsync();
            return congelacion;
        }

        public async Task<bool> DeleteCongelacionAsync(int id)
        {
            var congelacion = await _context.Congelaciones.FindAsync(id);
            if (congelacion == null)
            {
                return false;
            }
            _context.Congelaciones.Remove(congelacion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Congelacion?> GetCongelacionByIdAsync(int id)
        {
            return await _context.Congelaciones.FindAsync(id);
        }

        public async Task<IEnumerable<Congelacion>> GetCongelacionesAsync()
        {
            return await _context.Congelaciones.ToListAsync();
        }

        public async Task<Congelacion?> UpdateCongelacionAsync(Congelacion congelacion)
        {
            var existingCongelacion = await _context.Congelaciones.FindAsync(congelacion.IdCongelacion);
            if (existingCongelacion == null)
            {
                return null;
            }

            // Solo actualizamos las propiedades reales
            existingCongelacion.IdSuscripcion = congelacion.IdSuscripcion;
            existingCongelacion.FechaInicio = congelacion.FechaInicio;
            existingCongelacion.FechaFin = congelacion.FechaFin;
            existingCongelacion.Estado = congelacion.Estado;

            await _context.SaveChangesAsync();
            return existingCongelacion;
        }


    }
}
