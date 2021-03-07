using Nexos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Core.Interfaces
{
    public interface IAuthorRepository
    {
        Task<bool> DeleteAuthor(int id);
        Task<Author> GetAuthor(int id);
        Task<IEnumerable<Author>> GetAuthors();
        Task InsertAuthor(Author model);
        Task<bool> UpdateAuthor(Author model);
    }
}