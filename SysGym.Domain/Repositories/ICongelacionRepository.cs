using SysGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGym.Domain.Repositories
{
    public interface ICongelacionRepository
    {
        /// <summary>
        /// Obtener todas las Congelaciones.
        /// </summary>
        Task<IEnumerable<Congelacion>> GetCongelacionesAsync();

        /// <summary>
        /// Obtener una Congelación por su id.
        /// </summary>
        /// <param name="id">Identificador de la Congelación.</param>
        /// <returns>La entidad Congelación encontrada o null si no existe.</returns>
        Task<Congelacion?> GetCongelacionByIdAsync(int id);

        /// <summary>
        /// Agregar una nueva Congelación.
        /// </summary>
        /// <param name="congelacion">Entidad Congelación a agregar.</param>
        /// <returns>La entidad Congelación agregada.</returns>
        Task<Congelacion> AddCongelacionAsync(Congelacion congelacion);

        /// <summary>
        /// Actualizar una Congelación existente.
        /// </summary>
        /// <param name="congelacion">Entidad Congelación con los datos actualizados.</param>
        /// <returns>La entidad Congelación actualizada o null si no existe.</returns>
        Task<Congelacion?> UpdateCongelacionAsync(Congelacion congelacion);

        /// <summary>
        /// Eliminar una Congelación por su id.
        /// </summary>
        /// <param name="id">Identificador de la Congelación a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario.</returns>
        Task<bool> DeleteCongelacionAsync(int id);

    }
}
