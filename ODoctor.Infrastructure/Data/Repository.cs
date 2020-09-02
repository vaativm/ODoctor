using Microsoft.EntityFrameworkCore;
using ODoctor.Core.Entities;
using ODoctor.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODoctor.Infrastructure.Data
{
    public class Repository<T>: IAsynRepository<T> where T: BaseEntity<int>
    {
        protected readonly ODoctorDbContext _oDoctorDbContext;
        public Repository(ODoctorDbContext oDoctorDbContext)
        {
            _oDoctorDbContext = oDoctorDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _oDoctorDbContext.Set<T>().Add(entity);
            await _oDoctorDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _oDoctorDbContext.Set<T>().Remove(entity);
            await _oDoctorDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _oDoctorDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _oDoctorDbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _oDoctorDbContext.Entry(entity).State = EntityState.Modified;
            await _oDoctorDbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_oDoctorDbContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<T> GetEntityAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
    }
}
