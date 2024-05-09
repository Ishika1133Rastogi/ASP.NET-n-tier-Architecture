
using Microsoft.EntityFrameworkCore;
using OrderProducts.Dal.Data;
using OrderProducts.Dal.Repositories.Interface;

namespace OrderProducts.Dal.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
          private readonly ApplicationDbContext _dbContext;
        

            public GenericRepository(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<TEntity> GetByIdAsync(int id)
            {
            
                return await _dbContext.Set<TEntity>().FindAsync(id);
            }

            public async Task<List<TEntity>> GetAsync()
            {
                return await _dbContext.Set<TEntity>().ToListAsync();
            }

            public async Task<TEntity> AddAsync(TEntity entity)
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }

            public async Task<TEntity> UpdateAsync(TEntity entity)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var entity = await _dbContext.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

    }

    