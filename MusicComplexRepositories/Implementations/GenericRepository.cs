
using Microsoft.EntityFrameworkCore;
using MusicComplexRepositories.Interfaces;

namespace MusicComplexRepositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly MusicDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MusicDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null) _dbSet.Remove(entity);
    }
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
