namespace Board_Games.Repos
{
    public interface IEfRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
        IQueryable<T> Query();
    }
}
