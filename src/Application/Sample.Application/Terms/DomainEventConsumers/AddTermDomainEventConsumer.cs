using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Terms;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Terms.DomainEventConsumers
{
	public class AddTermDomainEventConsumer : DomainEventHandler<AddTermDomainEvent>
	{
		public AddTermDomainEventConsumer(ILogger<AddTermDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(AddTermDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
