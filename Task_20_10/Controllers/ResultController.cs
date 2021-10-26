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
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IParticipantRepository _repoparticipant;
        private readonly IResultRepository _repo;
        private readonly IMapper _mapper;

        public ResultController(IParticipantRepository repoparticipant, IMapper mapper, IResultRepository repo)
        {
            _repoparticipant = repoparticipant;
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet("resultsFromRace/{id}")]
        public async Task<IActionResult> GetResultsAsync(Guid id)
        {
            //var thatParticipant = await _repoparticipant.GetParticipantAsync(id);
            var results = await _repo.GetResultsFromThatIdRaceAsync(id);
            var sortedResults = results.OrderBy(x => x.Result.Time.ToString().Length).ThenBy(e => e.Result.Time);
            var mappedresults = _mapper.Map<IEnumerable<ParticipantforResultDto>>(sortedResults);
            return Ok(mappedresults);
        }
        [HttpGet("result/{id}")]
        public async Task<IActionResult> GetResultAsync(int id)
        {
            var thisResult = await _repo.GetResultAsync(id);
            var mappedThisResult = _mapper.Map<ResultDto>(thisResult);
            return Ok(mappedThisResult);
        }
        [HttpDelete("result/{id}")]
        public async Task<IActionResult> DeleteResultAsync(int id)
        {
            var thisResult = await _repo.GetResultAsync(id);
            _repo.DelateAsync(thisResult);
            if (await _repo.SaveAllAsync())
                return Ok();
            return BadRequest("błąd w usunięciu");
        }
        [HttpPost("/result")]
        public async Task<IActionResult> AddResultAsync(ResultForAddDto ResultForAddDto)
        {
            if (!(await _repoparticipant.ParticipantIdExist(ResultForAddDto.ParticipantId)))
                return BadRequest("That Participant Id doesn't exist");

            var participantFromRepo = await _repoparticipant.GetParticipantAsync(ResultForAddDto.ParticipantId);
            var ResultForAdd = new Result
            {

                Status = ResultForAddDto.Status,
                Time = ResultForAddDto.Time

            };
            var resultmap = _mapper.Map<Result>(ResultForAdd);
            participantFromRepo.Result = resultmap;
            if (await _repo.SaveAllAsync())
            {

                return Ok();

            }
            return BadRequest("nzapisywanie uzytkownika do wyscigu");
        }
        [HttpPut("result/{id}")]
        public async Task<IActionResult> UpdateResult(int id, ResultForUpdateDto ResultForUpdateDto)
        {
            var Resultpantfromrepo = await _repo.GetThisResultAsync(id);
            var zmapowany = _mapper.Map(ResultForUpdateDto, Resultpantfromrepo);
            if (await _repo.SaveAllAsync())
                return Ok(zmapowany);
            throw new Exception("nie udało sie");
        }
        /*[HttpGet("id", Name = "GetThisResult")]
        public async Task<IActionResult> GetThisResultAsync(int id)
        {
            var result = await _repo.GetResultAsync(id);
            var ResultforReturn = _mapper.Map<ParticipantForAddDto>(result);
            return Ok(ResultforReturn);
        }*/
    }
}
