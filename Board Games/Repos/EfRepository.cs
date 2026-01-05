using Microsoft.EntityFrameworkCore;
using Board_Games.Data;
using System.Threading.Tasks;

namespace Board_Games.Repos
{
    public class EfRepository<T> : IEfRepository<T> where T : class
    {

        protected readonly AppDbContext _db;

        public EfRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _db.Set<T>().FindAsync(Id);
        }

        public IQueryable<T> Query()
        {
            return _db.Set<T>().AsQueryable();
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _db.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}
