using AutoMapper;
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
    public class ParticipantController : ControllerBase
    {
        private readonly IRaceRepository _reporace;
        private readonly IParticipantRepository _repo;
        private readonly IMapper _mapper;

        public ParticipantController(IParticipantRepository repo, IMapper mapper, IRaceRepository reporace)
        {
            _reporace = reporace;
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet("participants/{id}")]
        public async Task<IActionResult> GetParticipantsAsync(Guid id)
        {
            var participants = await _repo.GetParticipantsAsync(id);
            var mappedparticipants = _mapper.Map<IEnumerable<ParticipantDto>>(participants);
            return Ok(mappedparticipants);
        }

        [HttpGet("participant/{id}")]
        public async Task<IActionResult> GetParticipantAsync(Guid id)
        {
            var thisParticipant = await _repo.GetParticipantAsync(id);
            var mappedThisParticipant = _mapper.Map<ParticipantDto>(thisParticipant);
            return Ok(mappedThisParticipant);
        }
        [HttpDelete("participant/{id}")]
        public async Task<IActionResult> DeleteParticipantAsync(Guid id)
        {
            var thisParticipant = await _repo.GetParticipantAsync(id);
            _repo.DelateAsync(thisParticipant);
            if (await _repo.SaveAllAsync())
                return Ok();
            return BadRequest("błąd w usunięciu");
        }
        
        [HttpPost("/participant")]
        public async Task<IActionResult> AddParticipantAsync(ParticipantForAddDto ParticipantForAddDto)
        {


            //Sprawdzenie czy jest wydarzenie o takim Id 
            if (!(await _reporace.RaceIdExist(ParticipantForAddDto.RaceId)))
                return BadRequest("That Race Id doesn't exist");

            var raceFromRepo = await _reporace.GetRaceAsync(ParticipantForAddDto.RaceId);
            var ParticipantForAdd = new Participant
            {
               
                Name = ParticipantForAddDto.Name,
                Surname = ParticipantForAddDto.Surname,
                Payed = ParticipantForAddDto.Payed,
                Number = await _repo.GenerateNumber(),
               
            };
            var participantmap = _mapper.Map<Participant>(ParticipantForAdd);
            raceFromRepo.Participants.Add(participantmap);

            if (await _repo.SaveAllAsync())
            {

                return Ok();
               
            }
            return BadRequest("nzapisywanie uzytkownika do wyscigu");
        }
        [HttpPut("participant/{id}")]
        public async Task<IActionResult> UpdateParticipant(Guid id, ParticipantForUpdateDto ParticipantForUpdateDto)
        {
            var Participantfromrepo = await _repo.GetThisParticipantAsync(id);
            var zmapowany = _mapper.Map(ParticipantForUpdateDto, Participantfromrepo);
            if (await _repo.SaveAllAsync())
                return Ok(zmapowany);
            throw new Exception("nie udało sie");
        }
     

    }
}
