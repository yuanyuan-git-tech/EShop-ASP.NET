using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Implementation.Repositories;

public class BaseRepository<T>: IBaseRepository<T> where T: class
{
    protected readonly ShippingDbContext _dbContext;
    
    public BaseRepository(ShippingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity =  await _dbContext.Set<T>().FindAsync(id);
        if (entity == null)
        {
            return 0;
        }

        _dbContext.Set<T>().Remove(entity);
        return await _dbContext.SaveChangesAsync();
        // The return value is the number of state entries written to the database
        // (which should be 1 if the delete was successful, or 0 if the entity was not found).
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
       return await _dbContext.Set<T>().FindAsync(id);
    }

    public Task<int> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        return _dbContext.SaveChangesAsync();    
    }

    public Task<int> UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        return _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbContext.Set<T>().Where(filter).ToListAsync();
    }
}