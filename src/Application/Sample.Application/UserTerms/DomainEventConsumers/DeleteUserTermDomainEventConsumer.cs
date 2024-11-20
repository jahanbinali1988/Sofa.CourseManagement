using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.UserTerms;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.UserTerms.DomainEventConsumers
{
	public class DeleteUserTermDomainEventConsumer : DomainEventHandler<DeleteUserTermDomainEvent>
	{
		public DeleteUserTermDomainEventConsumer(ILogger<DeleteUserTermDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(DeleteUserTermDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
