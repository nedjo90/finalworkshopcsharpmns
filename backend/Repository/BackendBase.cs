using System.Linq.Expressions;
using backend.Contract;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class BackendBase<T> : IBackendBase<T> where T : class
{
    protected BackendContext BackendContext;

    public BackendBase(BackendContext repositoryContext)
    {
        BackendContext = repositoryContext;
    }
    
    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges
            ? BackendContext.Set<T>().AsNoTracking()
            : BackendContext.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges
            ? BackendContext.Set<T>().Where(expression).AsNoTracking()
            : BackendContext.Set<T>().Where(expression);
    }

    public void Create(T entity)
    {
        BackendContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        BackendContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        BackendContext.Set<T>().Remove(entity);
    }
}