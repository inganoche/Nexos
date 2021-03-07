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
using System.Threading.Tasks;

namespace Nexos.Api.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await bookService.GetBooks();
            var booksDto = mapper.Map<IEnumerable<BookDto>>(books);
            var response = new ResponseApi<IEnumerable< BookDto>>(booksDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await bookService.GetBook(id);
            var bookDto = mapper.Map<BookDto>(book);
            var response = new ResponseApi<BookDto>(bookDto);
            return Ok(response);
        }

        [HttpPost]
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
           var result =  await bookService.UpdateBook(book);
            var response = new ResponseApi<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           var result =  await bookService.DeleteBook(id);
            var response = new ResponseApi<bool>(result);
            return Ok(response);
        }


    }
}
