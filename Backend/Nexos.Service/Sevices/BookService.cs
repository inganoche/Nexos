using Nexos.Core.Entities;
using Nexos.Core.Exceptions;
using Nexos.Core.Interfaces;
using Nexos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Service.Sevices
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IEditorialRepository editorialRepository;

        public BookService(IBookRepository _bookRepository, IAuthorRepository _authorRepository, IEditorialRepository _editorialRepository)
        {
            bookRepository = _bookRepository;
            authorRepository = _authorRepository;
            editorialRepository = _editorialRepository;

        }
        public async Task<Book> GetBook(int id)
        {
            try
            {
                return await bookRepository.GetBook(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            try
            {
                return await bookRepository.GetBooks();
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task InsertBook(Book model)
        {
            try
            {

                var author = await authorRepository.GetAuthor(model.IdAuthor);
                var editorial = await editorialRepository.GetEditorial(model.IdEditorial);

                //Validation
                if (author == null)
                {
                    throw new GlobalException("El autor no está registrado");
                }

                if (editorial == null)
                {
                    throw new GlobalException("La editorial no está registrada");
                }

                var counBook = await bookRepository.CountBooksEditorial(editorial.Id);
                if (counBook + 1 >= editorial.MaxBook)
                {
                    throw new GlobalException("No es posible registrar el libro, se alcanzó el máximo permitido.");
                }

                await bookRepository.InsertBook(model);

            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }

        }
        public async Task<bool> UpdateBook(Book model)
        {
            try
            {

                return await bookRepository.UpdateBook(model);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                return await bookRepository.DeleteBook(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }

    }
}
