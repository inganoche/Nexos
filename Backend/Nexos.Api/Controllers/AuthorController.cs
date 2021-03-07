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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService AuthorService;
        private readonly IMapper mapper;
        public AuthorController(IAuthorService _AuthorService, IMapper _mapper)
        {
            AuthorService = _AuthorService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var Authors = await AuthorService.GetAuthors();
            var AuthorsDto = mapper.Map<IEnumerable<AuthorDto>>(Authors);
            var response = new ResponseApi<IEnumerable< AuthorDto>>(AuthorsDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var Author = await AuthorService.GetAuthor(id);
            var AuthorDto = mapper.Map<AuthorDto>(Author);
            var response = new ResponseApi<AuthorDto>(AuthorDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AuthorDto model)
        {
            var Author = mapper.Map<Author>(model);
            await AuthorService.InsertAuthor(Author);
            model = mapper.Map<AuthorDto>(Author);
            var response = new ResponseApi<AuthorDto>(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, AuthorDto model)
        {
            var Author = mapper.Map<Author>(model);
            Author.id = id;
           var result =  await AuthorService.UpdateAuthor(Author);
            var response = new ResponseApi<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           var result =  await AuthorService.DeleteAuthor(id);
            var response = new ResponseApi<bool>(result);
            return Ok(response);
        }


    }
}
