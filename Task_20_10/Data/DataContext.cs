using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_20_10.Models;

namespace Task_20_10.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        public DbSet<Race> Races { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Result> Results { get; set; }


    }
}
