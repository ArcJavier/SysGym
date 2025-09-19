using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysGym.Domain.Entities;

namespace SysGym.Domain.Repositories
{
    /// <summary>
    /// Define los métodos para gestionar las suscripciones en el sistema.
    /// </summary>
    public interface ISuscripcionRepository
    {
        /// <summary>
        /// Obtiene todas las suscripciones registradas.
        /// </summary>
        /// <returns>Una colección de suscripciones.</returns>
        Task<IEnumerable<Suscripcion>> GetSuscripcionesAsync();

        /// <summary>
        /// Obtiene una suscripción por su identificador único.
        /// </summary>
        /// <param name="id">Identificador de la suscripción.</param>
        /// <returns>La suscripción encontrada o null si no existe.</returns>
        Task<Suscripcion> GetSuscripcionById(int id);

        /// <summary>
        /// Agrega una nueva suscripción al sistema.
        /// </summary>
        /// <param name="suscripcion">La suscripción a agregar.</param>
        /// <returns>La suscripción agregada.</returns>
        Task<Suscripcion> AddSuscripcionAsync(Suscripcion suscripcion);

        /// <summary>
        /// Actualiza los datos de una suscripción existente.
        /// </summary>
        /// <param name="suscripcion">La suscripción con los datos actualizados.</param>
        /// <returns>La suscripción actualizada.</returns>
        Task<Suscripcion> UpdateSuscripcionAsync(Suscripcion suscripcion);

        /// <summary>
        /// Elimina una suscripción por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la suscripción a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa; de lo contrario, false.</returns>
        Task<bool> DeleteSuscripcionAsync(int id);

        /// <summary>
        /// Obtiene todas las suscripciones asociadas a un cliente específico.
        /// </summary>
        /// <param name="clienteId">Identificador del cliente.</param>
        /// <returns>Una colección de suscripciones del cliente.</returns>
        Task<IEnumerable<Suscripcion>> GetSuscripcionesByClienteIdAsync(int clienteId);
    }
}
