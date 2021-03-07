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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly NexosContext dbc;
        public AuthorRepository(NexosContext context)
        {
            dbc = context;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var Authors = await dbc.Author.ToListAsync();
            return Authors;
        }

        public async Task<Author> GetAuthor(int id)
        {
            var Author = await dbc.Author.FirstOrDefaultAsync(x => x.id == id);
            return Author;
        }

        public async Task InsertAuthor(Author model)
        {
            dbc.Author.Add(model);
            await dbc.SaveChangesAsync();

        }
        public async Task<bool> UpdateAuthor(Author model)
        {
            var Author = await GetAuthor(model.id);
            Author.FullName = model.FullName;
            Author.BirthDate = model.BirthDate;
            Author.BirthTown = model.BirthTown;
            Author.Email = model.Email;
            int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var Author = await GetAuthor(id);
            dbc.Author.Remove(Author);
            int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }
    }
}
