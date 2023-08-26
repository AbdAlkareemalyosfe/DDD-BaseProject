using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.GeneralRepo
{
    public interface IBaseRepository<TEntity, TDto, Tkey>
    {
        IQueryable<TEntity> GetAllAsNoTrackAsync();
        IQueryable<TEntity> GetAllAsync();
        Task<TEntity> GetByIdAsync(TDto id);
        Task<bool> UpdateAsync(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
    } 
}
