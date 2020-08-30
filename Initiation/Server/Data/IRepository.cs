using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiation.Server.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }

    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
