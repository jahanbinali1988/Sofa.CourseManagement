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
	public class UpdateFieldDomainEventConsumer : DomainEventHandler<UpdateFieldDomainEvent>
	{
		public UpdateFieldDomainEventConsumer(ILogger<UpdateFieldDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(UpdateFieldDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
