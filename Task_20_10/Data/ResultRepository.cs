using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Data
{
    public class ResultRepository : GenericRepository, IResultRepository
    {
        private readonly DataContext _context;
        public ResultRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Result> GetResultAsync(int id)
        {
            var result = await _context.Results.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<Participant>> GetResultsFromThatIdRaceAsync(Guid idRace)
        {
            var results = await _context.Participants.Include(x => x.Result).Where(x => x.RaceId == idRace).ToListAsync();
            return results;
        }

        public async Task<Result> GetThisResultAsync(int id)
        {
            var result = await _context.Results.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
