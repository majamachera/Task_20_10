using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Data
{
    public interface IParticipantRepository : IGenericRepository
    {
        Task<Participant> GetParticipantAsync(Guid id);
        Task<Participant> GetThisParticipantAsync(Guid id);
        Task<IEnumerable<Participant>> GetParticipantsAsync(Guid idRace);
        Task<int> GenerateNumber();
        Task<bool> ParticipantNumberExist(int number);
        Task<bool> ParticipantIdExist(Guid id);
    }
}
