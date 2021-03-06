using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexos.Api.Responses;
using Nexos.Core.DTOs;
using Nexos.Core.Entities;
using Nexos.Core.Interfaces;
using Nexos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nexos.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;
        public BookController(IBookService _bookService, IMapper _mapper)
        {
            bookService = _bookService;
            mapper = _mapper;
        }

        /// <summary>
        /// Retorna todos los libros
        /// </summary>
        /// <returns>Todos los libros</returns>
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await bookService.GetBooks();
            var BooksDtoOut = mapper.Map<IEnumerable<BookDtoOut>>(books);
            //var response = new ResponseApi<IEnumerable<BookDtoOut>>(BooksDtoOut);
            return Ok(BooksDtoOut);
        }
        /// <summary>
        /// Retorna un libro específico
        /// </summary>
        /// <param name="id">Código del libro</param>
        /// <returns>Un libro</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseApi<BookDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await bookService.GetBook(id);
            var bookDto = mapper.Map<BookDto>(book);
            var response = new ResponseApi<BookDto>(bookDto);
            return Ok(response);
        }
        /// <summary>
        /// Inserta un libro
        /// </summary>
        /// <param name="model">Modelos tipo libro</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseApi<BookDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Post(BookDto model)
        {
            var book = mapper.Map<Book>(model);
            await bookService.InsertBook(book);
            model = mapper.Map<BookDto>(book);
            var response = new ResponseApi<BookDto>(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, BookDto model)
        {
            var book = mapper.Map<Book>(model);
            book.Id = id;
            var result = await bookService.UpdateBook(book);
            var response = new ResponseApi<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await bookService.DeleteBook(id);
            var response = new ResponseApi<bool>(result);
            return Ok(response);
        }


    }
}
