using System.Linq.Expressions;

namespace EmpresasEmpleadosApi.Data.Repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Obtain(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> Create(TEntity entity);
        Task<bool> Edit(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<IQueryable<TEntity>> Consult(Expression<Func<TEntity, bool>> filter = null!);
    }
}
