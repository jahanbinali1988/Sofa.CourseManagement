using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Infrastructure.Persistence
{
	public class UnitOfWork : ICourseManagementUnitOfWork
	{
        private readonly CourseManagementDbContext _dbContext;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;
        private IInstituteRepository _instituteRepository;
		private IUserRepository _userRepository;

		public UnitOfWork(CourseManagementDbContext dbContext,
            IInstituteRepository instituteRepository,
            IUserRepository userRepository,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            _dbContext = dbContext;
            _domainEventsDispatcher = domainEventsDispatcher;
            _userRepository = userRepository;
            _instituteRepository = instituteRepository;
        }

		public IInstituteRepository InstituteRepository => _instituteRepository;
		public IUserRepository UserRepository => _userRepository;

		public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync(CancellationToken.None))
            {
                try
				{
					await _domainEventsDispatcher.DispatchEventsAsync();
					var result = await _dbContext.SaveChangesAsync(CancellationToken.None);

					//ignore cancellation token
					await transaction.CommitAsync(CancellationToken.None);
                    return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(CancellationToken.None);
                    throw;
                }
            }
        }
    }
}
