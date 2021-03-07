using Microsoft.EntityFrameworkCore;
using Nexos.Core.Entities;
using Nexos.Core.Interfaces;
using Nexos.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly NexosContext dbc;
        public BookRepository( NexosContext context)
        {
            dbc = context;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await dbc.Book.ToListAsync();
            return books;
        }

        public async Task<int> CountBooksEditorial(int IdEditorial)
        {
            var books = await dbc.Book.Where(x=> x.IdEditorial== IdEditorial).ToListAsync();
            if (books != null)
              return  books.Count();

            return 0;
        }

        public async Task<Book> GetBook( int id)
        {
            var book = await dbc.Book.FirstOrDefaultAsync(x=> x.Id== id);
            return book;
        }

        public async Task InsertBook(Book model)
        {
            dbc.Book.Add(model);
            await dbc.SaveChangesAsync();
            
        }
        public async Task<bool> UpdateBook(Book model)
        {
            var book = await GetBook(model.Id);
            book.Gender = model.Gender;
            book.IdEditorial = model.IdEditorial;
            book.IdAuthor = model.IdAuthor;
            book.Title = model.Title;
            book.Year = model.Year;
            book.PageNumber = model.PageNumber;

           int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await GetBook(id);
            dbc.Book.Remove(book);
            int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }

    }
}
