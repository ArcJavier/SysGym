using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysGym.Domain.Entities;
using SysGym.Domain.Repositories;
using SysGym.Infraestructure.Data;

namespace SysGym.Infraestructure.Repositories
{
    public class SuscripcionRepository : ISuscripcionRepository
    {
        private readonly AppDBContext _context;

        public SuscripcionRepository(AppDBContext context)
        {
            _context = context;
        }   
        public async Task<IEnumerable<Suscripcion>> GetSuscripcionesAsync()
        {
            return await _context.Suscripciones.ToListAsync();
        }
        public async Task<Suscripcion> GetSuscripcionById(int id)
        {
            return await _context.Suscripciones.FindAsync(id);
        }
        public async Task<Suscripcion>AddSuscripcionAsync(Suscripcion suscripcion)
        {
            suscripcion.Estado = 1; // Activo por defecto
            await _context.Suscripciones.AddAsync(suscripcion);
            await _context.SaveChangesAsync();
            return suscripcion;
        }

        public async Task<Suscripcion> UpdateSuscripcionAsync(Suscripcion suscripcion)
        {
            var existing = await _context.Suscripciones.FindAsync(suscripcion.IdSuscripcion);
            if (existing == null)
                throw new KeyNotFoundException($"Suscripción con Id={suscripcion.IdSuscripcion} no encontrada.");

            // Actualizar campos
            existing.IdCliente = suscripcion.IdCliente;
            existing.IdPlan = suscripcion.IdPlan;
            existing.FechaInicio = suscripcion.FechaInicio;
            existing.FechaFin = suscripcion.FechaFin;
            existing.Estado = suscripcion.Estado;

            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteSuscripcionAsync(int id)
        {
            var existing = await _context.Suscripciones.FindAsync(id);
            if (existing == null)
                return false;

            _context.Suscripciones.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Suscripcion>> GetSuscripcionesByClienteIdAsync(int clienteId)
        {
            return await _context.Suscripciones
                                 .Where(s => s.IdCliente == clienteId)
                                 .ToListAsync();
        }
    }
}
