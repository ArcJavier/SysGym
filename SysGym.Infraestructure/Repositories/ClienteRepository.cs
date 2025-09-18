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
    internal class ClienteRepository : IClienteRepository
    {
        private readonly AppDBContext _context;
        public ClienteRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task<bool> DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return false;
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
        public async Task<IEnumerable<Cliente>> GetClienteAsync()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var existingCliente = await _context.Clientes.FindAsync(cliente.IdCliente);
            if (existingCliente == null)
            {
                return null;
            }
            existingCliente.Nombre = cliente.Nombre;
            existingCliente.Apellido = cliente.Apellido;
            existingCliente.Dui = cliente.Dui;
            existingCliente.CorreoE = cliente.CorreoE;
            existingCliente.Telefono = cliente.Telefono;
            existingCliente.FechaRegistro = cliente.FechaRegistro;
            existingCliente.Estado = cliente.Estado;
            await _context.SaveChangesAsync();
            return existingCliente;
        }
    }
}
