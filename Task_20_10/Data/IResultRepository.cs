using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Data
{
    interface IResultRepository : IGenericRepository
    {
        Task<Result> GetResultAsync(int id);
        Task <IEnumerable<Participant>> GetResultsFromThatIdRaceAsync(Guid idRace);
    }
}
