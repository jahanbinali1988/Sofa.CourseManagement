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
using System.Collections.Generic;

namespace Sofa.CourseManagement.Infrastructure.Persistence
{
	public abstract class RepositoryBase<TEntity, Tkey> : IRepository<TEntity, Tkey> where TEntity : Entity<Tkey>, IAggregateRoot
	{
		protected readonly DbContext DbContext;

		protected DbSet<TEntity> DbSet;

		protected RepositoryBase(DbContext context)
		{
			DbSet = context.Set<TEntity>();
			DbContext = context;
		}

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
			EntityEntry<TEntity> entry = DbContext.Attach(entity);

			DbContext.Update(entity);

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
				.Apply(ConfigureInclude)
				.SingleOrDefaultAsync(x => x.Id.Equals(id) && !x.IsDeleted, cancellationToken);
		}

		public virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, int offset, int count)
		{
			return DbContext.Set<TEntity>()
				.Apply(ConfigureInclude)
				.Where(predicate)
				.Where(c=> !c.IsDeleted)
				.Skip((offset - 1) * count)
				.Take(count)
				.ToListAsync();
		}

		public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return DbContext.Set<TEntity>()
				.AsNoTracking()
				.Apply(ConfigureInclude)
				.Where(c => !c.IsDeleted)
				.Where(predicate)
				.CountAsync();
		}

		public async Task SaveAsync()
		{
			await DbContext.SaveChangesAsync();
		}
	}

	public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, Guid> where TEntity : Entity<Guid>, IAggregateRoot
	{
		public RepositoryBase(CourseManagementDbContext dbContext) : base(dbContext)
		{
		}
	}
}
