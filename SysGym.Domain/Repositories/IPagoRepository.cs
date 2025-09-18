using SysGym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGym.Domain.Repositories
{
    public interface IPagoRepository
    {
        //Obtener todos los Pago
        Task<IEnumerable<Pago>> GetPagosAsync();
        //Obtener un Pago por su id
        Task<Pago> GetPagoByIdAsync(int id);
        //Agregar un nuevo Pago
        Task<Pago> AddPagoAsync(Pago pago);
        //Actualizar un Pago existente
        Task<Pago> UpdatePagoAsync(Pago pago);
        //Eliminar un Pago por su id
        Task<bool> DeletePagoAsync(int id);
    }
}
