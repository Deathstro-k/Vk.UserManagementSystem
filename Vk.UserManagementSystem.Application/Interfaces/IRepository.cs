namespace Vk.UserManagementSystem.Application.Interfaces;
public interface IRepository<TEntity> where TEntity : class, new()
{
    void GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync();

    TEntity Get(Guid id);
    Task<TEntity> GetAsync(Guid id, CancellationToken cancel = default);

    TEntity Add(TEntity item);
    Task<TEntity> AddAsync(TEntity item, CancellationToken cancel = default);

    void Update(TEntity item);
    Task UpdateAsync(TEntity item, CancellationToken cancel = default);

    void Delete(Guid id);
    Task DeleteAsync(Guid id, CancellationToken cancel = default);
}