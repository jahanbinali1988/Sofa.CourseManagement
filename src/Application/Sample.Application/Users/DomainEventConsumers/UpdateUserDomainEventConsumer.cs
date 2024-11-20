using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Users.Events;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.DomainEventConsumers
{
	public class UpdateUserDomainEventConsumer : DomainEventHandler<UpdateUserDomainEvent>
	{
		public UpdateUserDomainEventConsumer(ILogger<UpdateUserDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(UpdateUserDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
