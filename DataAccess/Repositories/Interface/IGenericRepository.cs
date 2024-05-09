
namespace OrderProducts.Dal.Repositories.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
            Task<TEntity> GetByIdAsync(int id);
            Task<List<TEntity>> GetAsync();
            Task<TEntity> AddAsync(TEntity entity);
            Task<TEntity> UpdateAsync(TEntity entity);
            Task<bool> DeleteAsync(int id);
    }
   
}
