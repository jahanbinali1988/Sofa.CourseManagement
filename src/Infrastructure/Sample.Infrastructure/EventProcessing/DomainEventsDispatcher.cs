using System.Linq;
using MediatR;
using System.Threading.Tasks;
using Sofa.CourseManagement.Infrastructure.Persistence;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Sofa.CourseManagement.Infrastructure.EventProcessing
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly CourseManagementDbContext _dbContext;

        public DomainEventsDispatcher(IMediator mediator, CourseManagementDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task DispatchEventsAsync()
		{
			var domainEntities = _dbContext.ChangeTracker
                .Entries<Entity<Guid>>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

			var tasks = domainEvents.Select(e => _mediator.Publish(e));

            await Task.WhenAll(tasks);
        }
    }
}
