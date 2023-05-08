using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Application.Interfaces;

namespace Vk.UserManagementSystem.Persistence.Repositories.Base;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    private readonly DbContext _context;

    private readonly DbSet<TEntity> _dbSet;

    public bool AutoSaveChanges { get; set; } = true;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public void GetAll() => _dbSet.ToList();
    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

    public virtual TEntity Add(TEntity item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        _context.Entry(item).State = EntityState.Added;
        if (AutoSaveChanges)
            _context.SaveChanges();
        return item;
    }

    public virtual async Task<TEntity> AddAsync(TEntity item, CancellationToken cancel = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        _context.Entry(item).State = EntityState.Added;
        if (AutoSaveChanges)
            await _context.SaveChangesAsync(cancel);
        return item;
    }


    public virtual void Delete(object id)
    {
        var item = _dbSet.Find(id);
        _context.Remove(item);

        if (AutoSaveChanges)
            _context.SaveChanges();
    }
    public virtual async Task DeleteAsync(object id, CancellationToken cancel = default)
    {
        var item = _dbSet.FindAsync(id);

        _context.Remove(item);

        if (AutoSaveChanges)
            await _context.SaveChangesAsync(cancel);
    }


    public virtual TEntity Get(object id) => _dbSet.Find(id);
    public async Task<TEntity> GetAsync(object id, CancellationToken cancel = default) => await _dbSet.FindAsync(id);


    public virtual void Update(TEntity item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        _context.Entry(item).State = EntityState.Modified;

        if (AutoSaveChanges)
            _context.SaveChanges();
    }
    public virtual async Task UpdateAsync(TEntity item, CancellationToken cancel = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        _context.Entry(item).State = EntityState.Modified;

        if (AutoSaveChanges)
            await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
    }
}