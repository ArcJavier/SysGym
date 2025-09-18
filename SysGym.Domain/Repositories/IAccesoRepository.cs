using SysGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGym.Domain.Repositories
{
    public interface IAccesoRepository
    {
        /// <summary>
        /// Obtiene todos los Accesos registrados
        /// </summary>
        /// <returns></returns>
        Task<List<Acceso>> GetAllAccesos();
        /// <summary>
        /// Obtiene un acceso especifico por su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Acceso?> GetAccesoById(int id);
        /// <summary>
        /// Busca un Acceso por el clienteId y rango de tiempo en que ocurrieron ingresos.
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        Task<List<Acceso>> FoundAcceso(int? clienteId);
        /// <summary>
        /// Agrega un acceso a la base de datos
        /// </summary>
        /// <param name="acceso"></param>
        /// <returns></returns>
        Task<Acceso> AddAcceso(Acceso acceso);
        /// <summary>
        /// Actualiza un acceso de datos por su Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="acceso"></param>
        /// <returns></returns>
        Task<Acceso> UpdateAcceso(int id, Acceso acceso);
        /// <summary>
        /// Cambia un Acceso a <see cref="Acceso.Estado"/> falso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAcceso(int id);
    }
}
