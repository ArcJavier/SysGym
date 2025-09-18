using SysGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGym.Domain.Repositories
{
    public interface IClienteRepository
    {
        //Obtener todos los Usuario
        Task<IEnumerable<Cliente>> GetClienteAsync();
        //Obtener un Usuario por su id
        Task<Cliente> GetClienteByIdAsync(int id);
        //Agregar un nuevo Usuario
        Task<Cliente> AddClienteAsync(Cliente cliente);
        //Actualizar un Usuario existente
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        //Eliminar un Usuario por su id
        Task<bool> DeleteClienteAsync(int id);
    }
}
