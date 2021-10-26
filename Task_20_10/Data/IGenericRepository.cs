using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_20_10.Data
{
    public interface IGenericRepository
    {
        void DelateAsync<T>(T entity);
        Task<bool> SaveAllAsync();
        void Add<T>(T entity) where T : class;
    }
}
