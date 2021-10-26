using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Data
{
    public class ParticipantRepository : GenericRepository, IParticipantRepository
    {


        private readonly DataContext _context;
        public ParticipantRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Participant> GetParticipantAsync(Guid id)
        {
            var participant = await _context.Participants.Include(x => x.Result).FirstOrDefaultAsync(x => x.ParticipantId == id);
            return participant;
        }

        public async Task<IEnumerable<Participant>> GetParticipantsAsync(Guid idRace)
        {
            var results = await _context.Participants.Where(x => x.RaceId == idRace).ToListAsync();
            return results;
        }

        public async Task<bool> ParticipantNumberExist(int number)
        {
            if (await _context.Participants.AnyAsync(x => x.Number == number))
                return true;
            else
                return false;
        }

        public async Task<bool> ParticipantIdExist(Guid id)
        {
            if (await _context.Participants.AnyAsync(x => x.ParticipantId == id))
                return true;
            else
                return false;
        }
        public async Task<int> GenerateNumber()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 1000);
            while(await ParticipantNumberExist(randomNumber)){
                randomNumber = rand.Next(1, 1000);
            }
            return randomNumber;
        }

    }
}
