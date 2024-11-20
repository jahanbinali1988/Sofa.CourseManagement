using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.SharedKernel.Shared
{
    public interface IRepository<TEntity, Tkey> where TEntity : Entity<Tkey>, IAggregateRoot
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity> GetAsync(Tkey id, CancellationToken cancellationToken);

		Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, int offset, int count);

		Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task SaveAsync();
	}

    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : Entity<Guid>, IAggregateRoot
    {

    }
}
