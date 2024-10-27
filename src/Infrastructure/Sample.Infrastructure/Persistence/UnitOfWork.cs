using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CourseManagementDbContext _dbContext;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;
        public UnitOfWork(CourseManagementDbContext dbContext,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            _dbContext = dbContext;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync(CancellationToken.None))
            {
                try
                {
                    var result = await _dbContext.SaveChangesAsync(cancellationToken);
                    await _domainEventsDispatcher.DispatchEventsAsync();

                    //ignore cancellation token
                    await transaction.CommitAsync(CancellationToken.None);
                    return result;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(CancellationToken.None);
                    throw;
                }
            }
        }
    }
}
