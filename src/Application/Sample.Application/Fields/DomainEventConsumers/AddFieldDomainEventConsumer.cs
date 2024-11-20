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
	public class AddFieldDomainEventConsumer : DomainEventHandler<AddFieldDomainEvent>
	{
		public AddFieldDomainEventConsumer(ILogger<AddFieldDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(AddFieldDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
