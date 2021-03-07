using Nexos.Core.Entities;
using Nexos.Core.Exceptions;
using Nexos.Core.Interfaces;
using Nexos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Nexos.Service.Sevices
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository AuthorRepository;

        public AuthorService(IAuthorRepository _AuthorRepository)
        {
            AuthorRepository = _AuthorRepository;

        }
        public async Task<Author> GetAuthor(int id)
        {
            try
            {
                return await AuthorRepository.GetAuthor(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            try
            {
                return await AuthorRepository.GetAuthors();
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }

        public async Task InsertAuthor(Author model)
        {
            try
            {
                await AuthorRepository.InsertAuthor(model);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }

        }

        public async Task<bool> UpdateAuthor(Author model)
        {
            try
            {
                return await AuthorRepository.UpdateAuthor(model);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            try
            {
                return await AuthorRepository.DeleteAuthor(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }

        }
    }
    }
