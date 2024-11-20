using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Sessions.DomainEventConsumers
{
	public class AddSessionDomainEventConsumer : DomainEventHandler<AddSessionDomainEvent>
	{
		public AddSessionDomainEventConsumer(ILogger<AddSessionDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(AddSessionDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
