using MasterProject.Infrastructure.Data;
using MasterProject.SharedKernel.Entities;
using MasterProject.SharedKernel.Extension;
using MasterProject.SharedKernel.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterProject.Infrastructure
{
    public class EfRepository : IRepository
    {
        private readonly AppDBContext _dbContext;
        public EfRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity, IAggregate
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync<T>(T entity) where T : BaseEntity, IAggregate
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                //Added code for exception handling. 
                return false;
            }
        }

        public Task<T> GetByID<T>(Guid Id) where T : BaseEntity, IAggregate
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == Id);
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity, IAggregate
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : BaseEntity, IAggregate
        {
            var specificationResult = ApplySpecification(spec);

            return specificationResult.ToListAsync();
        }

        public IQueryable<T> QueryableAsync<T>(ISpecification<T> spec) where T : BaseEntity, IAggregate
        {
            return ApplySpecification(spec);
        }
        public Task UpdateAsync<T>(T entity) where T : BaseEntity, IAggregate
        {
            var updateEntity = _dbContext.Set<T>().Update(entity);
            updateEntity.State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification<T>(ISpecification<T> specification) where T : BaseEntity
        {
            return _dbContext.Set<T>().Specify<T>(specification);
        }
    }
}
