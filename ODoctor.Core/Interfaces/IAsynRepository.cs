using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODoctor.Core.Interfaces
{
    public interface IAsynRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetEntityAsync(ISpecification<T> specification);
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> specification);
    }
}
