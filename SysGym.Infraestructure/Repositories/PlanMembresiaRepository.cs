using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysGym.Domain.Entities;
using SysGym.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SysGym.Infraestructure.Data;
namespace SysGym.Infraestructure.Repositories
{
    public class PlanMembresiaRepository : IPlanMembresia
    {
      private readonly AppDBContext _context;
        public PlanMembresiaRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<PlanMembresia> AddPlanMembresiaAsync(PlanMembresia planMembresia)
        {
            planMembresia.Estado = 1; // Activo por defecto
            await _context.PlanMembresias.AddAsync(planMembresia);
            await _context.SaveChangesAsync();
            return planMembresia;
        }
        public async Task<bool> DeletePlanMembresiaAsync(int id)
        {
            var existing = await _context.PlanMembresias.FindAsync(id);
            if (existing == null)
                return false;
            _context.PlanMembresias.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<PlanMembresia> GetPlanMembresiaById(int id)
        {
            return await _context.PlanMembresias.FindAsync(id);
        }
        public async Task<IEnumerable<PlanMembresia>> GetPlanMembresiasAsync()
        {
            return await _context.PlanMembresias.ToListAsync();
        }
        public async Task<PlanMembresia> UpdatePlanembresiaAsync(PlanMembresia planMembresia)
        {
            var existing = await _context.PlanMembresias.FindAsync(planMembresia.IdPlan);
            if (existing == null)
                throw new KeyNotFoundException($"PlanMembresia con Id={planMembresia.IdPlan} no encontrado.");
            existing.Nombre = planMembresia.Nombre;
            existing.DuracionDias = planMembresia.DuracionDias;
            existing.Precio = planMembresia.Precio;
            existing.Acceso24h = planMembresia.Acceso24h;
            existing.Estado = planMembresia.Estado;
            _context.PlanMembresias.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
