namespace Application.Contracts.Presistence
{
    // IRepository.cs
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> Exists(int d);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }

}