namespace Vk.UserManagementSystem.Application.Interfaces;
public interface IRepository<TEntity> where TEntity : class, new()
{
    void GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync();

    TEntity Get(object id);
    Task<TEntity> GetAsync(object id, CancellationToken cancel = default);

    TEntity Add(TEntity item);
    Task<TEntity> AddAsync(TEntity item, CancellationToken cancel = default);

    void Update(TEntity item);
    Task UpdateAsync(TEntity item, CancellationToken cancel = default);

    void Delete(object id);
    Task DeleteAsync(object id, CancellationToken cancel = default);
}