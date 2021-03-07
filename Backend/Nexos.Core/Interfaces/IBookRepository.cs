using Nexos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);

        Task<int> CountBooksEditorial(int IdEditorial);
        Task InsertBook(Book model);
        Task<bool> UpdateBook(Book model);
        Task<bool> DeleteBook(int id);

    }
}
