using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sofa.CourseManagement.Infrastructure.Persistence.Extensions;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using Sofa.CourseManagement.SharedKernel.Shared;

namespace Sofa.CourseManagement.Infrastructure.Persistence
{
    public class RepositoryBase<TEntity, Tkey> : IRepository<TEntity, Tkey> where TEntity : Entity<Tkey>, IAggregateRoot
    {
        protected readonly CourseManagementDbContext DbContext;

        protected virtual IQueryable<TEntity> ConfigureInclude(IQueryable<TEntity> query)
        {
            return query;
        }

        public RepositoryBase(CourseManagementDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            DbContext.Set<TEntity>().Update(entity);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            EntityEntry<TEntity> entry = DbContext.Attach(entity);

            entry.CurrentValues["IsDeleted"] = true;
            entry.CurrentValues["DeletedAt"] = DateTimeOffset.Now;

            DbContext.Update(entity);

            return Task.CompletedTask;
        }

        public Task<TEntity> GetAsync(Tkey id, CancellationToken cancellationToken)
        {
            return DbContext.Set<TEntity>()
                .AsNoTracking()
                .Apply(ConfigureInclude)
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }
    }

    public class RepositoryBase<TEntity> : RepositoryBase<TEntity, Guid> where TEntity : Entity<Guid>, IAggregateRoot
    {
        public RepositoryBase(CourseManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
