using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly DefaultContext _context;

        public RepositoryBase(DefaultContext dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public async Task AddRange<T>(IEnumerable<T> entities) where T : class
        {
            await _context.AddRangeAsync(entities);
        }


        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
