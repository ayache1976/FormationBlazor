using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Initiation.Server.Data;
using Initiation.Server.Helpers;
using Initiation.Server.Helpers.PagedParams;
using Initiation.Server.Models;
using Initiation.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Initiation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Instrument", Description ="Instrument Controller")]
    public class InstrumentController : ControllerBase
    {
        private readonly IInstrumentRepository _repo;
        private readonly IMapper _mapper;

        public InstrumentController(IInstrumentRepository repos, IMapper mapper)
        {
            _repo = repos;
            _mapper = mapper;
        }


        [HttpGet]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<DtoInstrument>), Description = "Ok")]
        public async Task<IActionResult> GetInstruments()
        {
            var items = await _repo.GetInstruments();
            var itemsDto = _mapper.Map<List<DtoInstrument>>(items);
            return Ok(itemsDto);
        }
        [HttpGet("Paged")]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<DtoInstrument>), Description = "Ok")]
        public async Task<IActionResult> GetInstrumentsPaged([FromQuery] InstrumentParams instrumentParams)
        {
            var items = await _repo.GetInstrumentsPaged(instrumentParams);
            var itemsDto = _mapper.Map<List<DtoInstrument>>(items);
            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            return Ok(itemsDto);
        }
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(DtoInstrument), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(DtoInstrument), Description = "Not Found")]
        [Authorize]
        public async Task<IActionResult> GetInstrument(int id)
        {
            var item = await _repo.GetInstrument(id);
            if (item == null)
                return NotFound();
            var itemDto = _mapper.Map<DtoInstrument>(item);
            return Ok(itemDto);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(void), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Impossible d'effacer l'instrument, il n'existe pas")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Impossible d'effacer l'instrument")]
        [Authorize]
        public async Task<IActionResult> DeleteInstrumentById(int id)
        {
            var item = await _repo.GetInstrument(id);
            if (item == null)
                return BadRequest("Impossible d'effacer l'instrument, il n'existe pas");
            _repo.Delete(item);
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest("Impossible d'effacer l'instrument");
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(void), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Impossible d'ajouter l'instrument")]
        [Authorize]
        public async Task<IActionResult> CreateInstrument(DtoInstrument dtoInstrument)
        {
            var item = _mapper.Map<Instrument>(dtoInstrument);
            if (item == null)
                return BadRequest("Impossible d'ajouter l'instrument");
            _repo.Add(item);
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest("Impossible d'ajouter l'instrument");
        }

        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, typeof(void), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(string), Description = "Impossible de modifier l'instrument, il n'existe pas")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Impossible modifier l'instrument")]
        [Authorize]
        public async Task<IActionResult> UpdateInstrument(int id, DtoInstrument dtoInstrument)
        {
            var item = await _repo.GetInstrument(id);
            if (item == null)
                return NotFound("Impossible de modifier l'instrument, il n'existe pas");

            item.Name = dtoInstrument.Name;
            item.Strings = dtoInstrument.Strings;
            item.YearManufacture = dtoInstrument.YearManufacture;
            _repo.Update(item);
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest("Impossible de modifier l'instrument");
        }
    }
}
