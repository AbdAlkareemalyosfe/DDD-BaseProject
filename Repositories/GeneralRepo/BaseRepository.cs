using Microsoft.EntityFrameworkCore;
using SqlServer;

namespace Repositories.GeneralRepo
{
    public abstract class BaseRepository
    {
        public ApplicationDbContext _context;

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
    public abstract class BaseRepository<TEntity, TDto, Tkey> : BaseRepository, IBaseRepository<TEntity, TDto, Tkey> where TEntity : class where TDto : class
        where Tkey : struct
    {
        protected BaseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var ressult = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return ressult.Entity;
        }


        public IQueryable<TEntity> GetAllAsNoTrackAsync()
        {
            return _context.Set<TEntity>().AsNoTracking();

        }

        public IQueryable<TEntity> GetAllAsync()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(TDto id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var result = _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            if (result != null)
                return true;
            return false;

        }
    }
}
