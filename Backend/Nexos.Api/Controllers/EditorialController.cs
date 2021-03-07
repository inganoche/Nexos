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
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialService EditorialService;
        private readonly IMapper mapper;
        public EditorialController(IEditorialService _EditorialService, IMapper _mapper)
        {
            EditorialService = _EditorialService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEditorials()
        {
            var Editorials = await EditorialService.GetEditorials();
            var EditorialsDto = mapper.Map<IEnumerable<EditorialDto>>(Editorials);
            var response = new ResponseApi<IEnumerable< EditorialDto>>(EditorialsDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEditorial(int id)
        {
            var Editorial = await EditorialService.GetEditorial(id);
            var EditorialDto = mapper.Map<EditorialDto>(Editorial);
            var response = new ResponseApi<EditorialDto>(EditorialDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post(EditorialDto model)
        {
            var Editorial = mapper.Map<Editorial>(model);
            await EditorialService.InsertEditorial(Editorial);
            model = mapper.Map<EditorialDto>(Editorial);
            var response = new ResponseApi<EditorialDto>(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, EditorialDto model)
        {
            var Editorial = mapper.Map<Editorial>(model);
            Editorial.Id = id;
           var result =  await EditorialService.UpdateEditorial(Editorial);
            var response = new ResponseApi<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           var result =  await EditorialService.DeleteEditorial(id);
            var response = new ResponseApi<bool>(result);
            return Ok(response);
        }


    }
}
