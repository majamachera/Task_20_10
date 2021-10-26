using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Data;
using Task_20_10.Dtos;
using Task_20_10.Models;

namespace Task_20_10.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceRepository _repo;
        private readonly IMapper _mapper;

        public RaceController(IRaceRepository repo, IMapper mapper)
        {

            _mapper = mapper;
            _repo = repo;
        }
            [HttpGet("races")]
            public async Task<IActionResult> GetRacesAsync()
            {
                var races = await _repo.GetRacesAsync();
                var mappedraces = _mapper.Map<IEnumerable<RaceDto>>(races);
                return Ok(mappedraces);
            }

            [HttpGet("rece/{id}")]
            public async Task<IActionResult> GetRaceAsync(Guid id)
            {
                var thisRace = await _repo.GetRaceAsync(id);
                var mappedThisRace = _mapper.Map<RaceDto>(thisRace);
                return Ok(mappedThisRace);
            }
            [HttpDelete("race/{id}")]
            public async Task<IActionResult> DeleteRaceAsync(Guid id)
            {
                var thisRace = await _repo.GetRaceAsync(id);
                _repo.DelateAsync(thisRace);
                if (await _repo.SaveAllAsync())
                    return Ok();
                return BadRequest("błąd w usunięciu");
            }
        [HttpPost("/race")]
        public async Task<IActionResult> AddRaceAsync([FromBody] RaceForAdd RaceForAddDto)
            {
                RaceForAddDto.Name = RaceForAddDto.Name.ToLower();
                var RacetoCreate = new Race();
                var CreatedRace = await _repo.AddRaceAsync(RacetoCreate, RaceForAddDto.Name, RaceForAddDto.Location);
                return Ok(CreatedRace);

            }
        
    }
}
