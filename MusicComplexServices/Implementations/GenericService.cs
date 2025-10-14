
using MusicComplexRepositories.Interfaces;
using MusicComplexServices.Interfaces;

namespace MusicComplexServices.Implementations;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _repo;

    public GenericService(IGenericRepository<T> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<T?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    public async Task AddAsync(T entity)
    {
        await _repo.AddAsync(entity);
        await _repo.SaveAsync();
    }
    public async Task UpdateAsync(T entity)
    {
        await _repo.UpdateAsync(entity);
        await _repo.SaveAsync();
    }
    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
        await _repo.SaveAsync();
    }
}
