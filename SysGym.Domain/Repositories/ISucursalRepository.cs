using SysGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGym.Domain.Repositories
{
    public interface ISucursalRepository
    {
        //Obtener todos los Usuario
        Task<IEnumerable<Sucursal>> GetSucursalAsync();
        //Obtener un Usuario por su id
        Task<Sucursal> GetSucursalByIdAsync(int id);
        //Agregar un nuevo Usuario
        Task<Sucursal> AddSucursalAsync(Sucursal sucursal);
        //Actualizar un Usuario existente
        Task<Sucursal> UpdateSucursalAsync(Sucursal sucursal);
        //Eliminar un Usuario por su id
        Task<bool> DeleteSucursalAsync(int id);
    }
}
