using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TouristHouse.Domain.Entites.Common;

namespace TouristHouse.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

        Task<bool> AddAsync(T model);
        //Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        //bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);

        Task<bool> SaveAsync();
    }
}
