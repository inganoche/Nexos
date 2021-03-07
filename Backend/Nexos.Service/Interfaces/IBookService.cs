using Nexos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Service.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task InsertBook(Book model);
        Task<bool> UpdateBook(Book model);
        Task<bool> DeleteBook(int id);
    }
}