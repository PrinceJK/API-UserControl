using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Data.Abstraction
{
    public interface IGenericRepository<T> where T : class
    {
        int TotalNumberOfItems { get; set; }
        int TotalNumberOfPages { get; set; }
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetPaginated(int page, int per_page, IQueryable<T> items);
        Task<bool> Add(T model);
        Task<T> GetById(object Id);
        Task<bool> Modify(T entity);
        Task<bool> DeleteById(object Id);
    }
}
