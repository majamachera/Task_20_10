using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Dtos;
using Task_20_10.Models;

namespace Task_20_10.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Race, RaceDto>();
            CreateMap<Participant, ParticipantForAddDto>();
            CreateMap<Participant, ParticipantDto>();
            CreateMap<Result, ResultDto>();
        }
    }
}
