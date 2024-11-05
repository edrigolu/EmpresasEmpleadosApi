using EmpresasEmpleadosApi.Data.DBContext;
using EmpresasEmpleadosApi.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmpresasEmpleadosApi.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly EmpresaEmpleadosDbContext _dbContext;

        public GenericRepository(EmpresaEmpleadosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<TEntity>> Consult(Expression<Func<TEntity, bool>> filter = null!)
        {
            try
            {
                IQueryable<TEntity> queryEntity = filter == null ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().Where(filter);
                return queryEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TEntity> Obtain(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                TEntity? entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(filter);
                return entity!;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext!.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
