using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Data
{
    public class RaceRepository : GenericRepository, IRaceRepository
    {
        private readonly DataContext _context;
        public RaceRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Race> AddRaceAsync(Race thisRace, string name, string location)
        {
            thisRace.Name = name;
            thisRace.Location = location;
            await _context.Races.AddAsync(thisRace);
            await _context.SaveChangesAsync();
            return thisRace;
        }

        

        public async Task<Race> GetRaceAsync(Guid id)
        {
            var race = await _context.Races.FirstOrDefaultAsync(x => x.Id == id);
            return race;
        }

        public async Task<IEnumerable<Race>> GetRacesAsync()
        {
            var races = await _context.Races.ToListAsync();
            return races;
        }

        public async Task<bool> RaceIdExist(Guid id)
        {
            if (await _context.Races.AnyAsync(x => x.Id == id))
                return true;
            else
                return false;
        }
    }
}
