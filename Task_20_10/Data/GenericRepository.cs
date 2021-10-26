using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_20_10.Data
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public void DelateAsync<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAllAsync() 
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
    }
}
