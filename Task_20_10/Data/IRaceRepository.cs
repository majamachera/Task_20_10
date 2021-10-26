using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Data
{
    public interface IRaceRepository : IGenericRepository
    {
        Task<Race> AddRaceAsync(Race thisRace, string name, string location);
        Task<IEnumerable<Race>> GetRacesAsync();
        Task<Race> GetRaceAsync(Guid id);
        Task<bool> RaceIdExist(Guid id);

    }
}
