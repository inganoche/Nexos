using Nexos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Service.Interfaces
{
    public interface IEditorialService
    {
        Task<bool> DeleteEditorial(int id);
        Task<Editorial> GetEditorial(int id);
        Task<IEnumerable<Editorial>> GetEditorials();
        Task InsertEditorial(Editorial model);
        Task<bool> UpdateEditorial(Editorial model);
    }
}