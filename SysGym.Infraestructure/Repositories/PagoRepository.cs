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
    public class PagoRepository : IPagoRepository
    {
        private readonly AppDBContext _context;
        public PagoRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Pago> AddPagoAsync(Pago pago)
        {
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<bool> DeletePagoAsync(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return false;
            }
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Pago?> GetPagoByIdAsync(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }

        public async Task<IEnumerable<Pago>> GetPagosAsync()
        {
            return await _context.Pagos.ToListAsync();
        }

        public async Task<Pago?> UpdatePagoAsync(Pago pago)
        {
            var existingPago = await _context.Pagos.FindAsync(pago.IdPago);
            if (existingPago == null)
            {
                return null;
            }

            existingPago.IdSuscripcion = pago.IdSuscripcion;
            existingPago.Monto = pago.Monto;
            existingPago.MetodoPago = pago.MetodoPago;
            existingPago.Referencia = pago.Referencia;
            existingPago.FechaPago = pago.FechaPago;
            existingPago.Estado = pago.Estado;

            await _context.SaveChangesAsync();
            return existingPago;
        }
    }
}
