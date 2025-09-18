using Microsoft.EntityFrameworkCore;
using SysGym.Domain.Entities;
using SysGym.Domain.Repositories;
using SysGym.Infraestructure.Data;

namespace SysGym.Infrastructure.Repositories
{
    public class AccesoRepository : IAccesoRepository
    {
        private readonly AppDBContext _context;

        public AccesoRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Acceso>> GetAllAccesos()
        {
            return await _context.Accesos
                .Include(a => a.IdClienteNavigation)
                .Include(a => a.IdSucursalNavigation)
                .ToListAsync();
        }

        public async Task<Acceso?> GetAccesoById(int id)
        {
            return await _context.Accesos
                .Include(a => a.IdClienteNavigation)
                .Include(a => a.IdSucursalNavigation)
                .FirstOrDefaultAsync(a => a.IdAcceso == id);
        }

        public async Task<List<Acceso>> FoundAcceso(int? clienteId)
        {
            var query = _context.Accesos.AsQueryable();

            if (clienteId.HasValue)
                query = query.Where(a => a.IdCliente == clienteId.Value);

            return await query
                .Include(a => a.IdClienteNavigation)
                .Include(a => a.IdSucursalNavigation)
                .ToListAsync();
        }

        public async Task<Acceso> AddAcceso(Acceso acceso)
        {
            acceso.Estado = 1;
            await _context.Accesos.AddAsync(acceso);
            await _context.SaveChangesAsync();
            return acceso;
        }

        public async Task<Acceso> UpdateAcceso(int id, Acceso acceso)
        {
            Acceso? existing = await _context.Accesos.FindAsync(id);

            if (existing == null)
                throw new KeyNotFoundException($"Acceso con Id={id} no encontrado.");

            existing.IdCliente = acceso.IdCliente;
            existing.IdSucursal = acceso.IdSucursal;
            existing.FechaEntrada = acceso.FechaEntrada;
            existing.FechaSalida = acceso.FechaSalida;
            existing.Fuente = acceso.Fuente;
            existing.Estado = acceso.Estado;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAcceso(int id)
        {
            Acceso? acceso = await _context.Accesos.FindAsync(id);
            if (acceso == null)
                return false;

            acceso.Estado = 0; // Estado "false"
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
