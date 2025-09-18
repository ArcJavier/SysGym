using SysGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGym.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        //Obtener todos los Usuario
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
        //Obtener un Usuario por su id
        Task<Usuario> GetUsuarioByIdAsync(int id);
        //Agregar un nuevo Usuario
        Task<Usuario> AddUsuarioAsync(Usuario usuario);
        //Actualizar un Usuario existente
        Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
        //Eliminar un Usuario por su id
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
