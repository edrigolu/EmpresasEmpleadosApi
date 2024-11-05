using EmpresasEmpleadosApi.Data.Repository.Interface;
using System.Linq.Expressions;

namespace EmpresasEmpleadosApi.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository()
        {
        }

        public Task<IQueryable<TEntity>> Consult(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Obtain(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
