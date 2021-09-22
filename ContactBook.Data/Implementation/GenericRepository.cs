using ContactBook.Data.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Data.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ContactBookContext _context;
        private readonly DbSet<T> _entities;
        public int TotalNumberOfItems { get; set; }
        public int TotalNumberOfPages { get; set; }

        public GenericRepository(ContactBookContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<bool> Add(T model)
        {
            _entities.Add(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteById(object Id)
        {
            var result = await GetById(Id);
            _entities.Remove(result);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<T> GetAll()
        {
            var result = _entities.AsNoTracking();

            return result;
        }

        public async Task<T> GetById(object Id)
        {
            return await _entities.FindAsync(Id);
        }

        public async Task<ICollection<T>> GetPaginated(int page, int per_page, IQueryable<T> items)
        {
            TotalNumberOfItems = await items.CountAsync();

            TotalNumberOfPages = (int)Math.Ceiling(TotalNumberOfItems / (double)per_page);

            if (page > TotalNumberOfPages || page < 1)
            {
                return null;
            }
            var pagedItems = await items.Skip((page - 1) * per_page).Take(per_page).ToListAsync();
            return pagedItems;
        }

        public async Task<bool> Modify(T entity)
        {
            _entities.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
