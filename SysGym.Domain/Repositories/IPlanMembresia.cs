using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysGym.Domain.Entities;

namespace SysGym.Domain.Repositories
{
    public interface IPlanMembresia
    {
        /// <summary>
        /// Obtiene todos los Planes de Membresías registrados.
        /// </summary>
        /// <returns>Una colección de objetos <see cref="PlanMembresia"/>.</returns>
        Task<IEnumerable<PlanMembresia>> GetPlanMembresiasAsync();

        /// <summary>
        /// Obtiene un Plan de Membresía por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del plan.</param>
        /// <returns>Un objeto <see cref="PlanMembresia"/> si existe; de lo contrario, null.</returns>
        Task<PlanMembresia> GetPlanMembresiaById(int id);

        /// <summary>
        /// Agrega un nuevo Plan de Membresía.
        /// </summary>
        /// <param name="planMembresia">El objeto <see cref="PlanMembresia"/> a registrar.</param>
        /// <returns>El objeto <see cref="PlanMembresia"/> registrado con su Id asignado.</returns>
        Task<PlanMembresia> AddPlanMembresiaAsync(PlanMembresia planMembresia);

        /// <summary>
        /// Actualiza la información de un Plan de Membresía existente.
        /// </summary>
        /// <param name="planMembresia">El objeto <see cref="PlanMembresia"/> con los cambios a aplicar.</param>
        /// <returns>El objeto <see cref="PlanMembresia"/> actualizado.</returns>
        Task<PlanMembresia> UpdatePlanembresiaAsync(PlanMembresia planMembresia);

        /// <summary>
        /// Elimina un Plan de Membresía existente por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del plan a eliminar.</param>
        /// <returns><c>true</c> si el plan fue eliminado correctamente; en caso contrario, <c>false</c>.</returns>
        Task<bool> DeletePlanMembresiaAsync(int id);
    }

}
