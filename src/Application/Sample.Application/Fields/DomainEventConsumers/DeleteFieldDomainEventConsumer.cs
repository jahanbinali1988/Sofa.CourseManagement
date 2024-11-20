using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Fields;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Fields.DomainEventConsumers
{
	public class DeleteFieldDomainEventConsumer : DomainEventHandler<DeleteFieldDomainEvent>
	{
		public DeleteFieldDomainEventConsumer(ILogger<DeleteFieldDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(DeleteFieldDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
