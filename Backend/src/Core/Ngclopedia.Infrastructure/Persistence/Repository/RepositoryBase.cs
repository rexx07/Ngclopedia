using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected ApplicationDbContext RepositoryContext;

    public RepositoryBase(ApplicationDbContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges
            ? RepositoryContext.Set<T>()
                .AsNoTracking()
            : RepositoryContext.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges)
    {
        return !trackChanges
            ? RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking()
            : RepositoryContext.Set<T>()
                .Where(expression);
    }

    public void Create(T entity)
    {
        RepositoryContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        RepositoryContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        RepositoryContext.Set<T>().Remove(entity);
    }
}