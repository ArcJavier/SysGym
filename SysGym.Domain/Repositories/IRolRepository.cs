using SysGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGym.Domain.Repositories
{
    public interface IRolRepository
    {
        //Obtener todos los Rol
        Task<IEnumerable<Rol>> GetRolsAsync();
        //Obtener un Rol por su id
        Task<Rol> GetRolByIdAsync(int id);
        //Agregar un nuevo Rol
        Task<Rol> AddRolAsync(Rol rol);
        //Actualizar un Rol existente
        Task<Rol> UpdateRolAsync(Rol rol);
        //Eliminar un Rol por su id
        Task<bool> DeleteRolAsync(int id);
    }
}
