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
    public class EditorialRepository : IEditorialRepository
    {
        private readonly NexosContext dbc;
        public EditorialRepository(NexosContext context)
        {
            dbc = context;
        }

        public async Task<IEnumerable<Editorial>> GetEditorials()
        {
            var Editorials = await dbc.Editorial.ToListAsync();
            return Editorials;
        }

        public async Task<Editorial> GetEditorial(int id)
        {
            var Editorial = await dbc.Editorial.FirstOrDefaultAsync(x => x.Id == id);
            return Editorial;
        }

        public async Task InsertEditorial(Editorial model)
        {
            dbc.Editorial.Add(model);
            await dbc.SaveChangesAsync();

        }
        public async Task<bool> UpdateEditorial(Editorial model)
        {
            var Editorial = await GetEditorial(model.Id);
            Editorial.Address = model.Address;
            Editorial.Email = model.Email;
            Editorial.MaxBook = model.MaxBook;
            Editorial.Name = model.Name;
            Editorial.Phone = model.Phone;
            int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteEditorial(int id)
        {
            var Editorial = await GetEditorial(id);
            dbc.Editorial.Remove(Editorial);
            int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }
    }
}
