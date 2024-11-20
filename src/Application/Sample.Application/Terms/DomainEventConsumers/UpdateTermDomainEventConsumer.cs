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
	public class UpdateTermDomainEventConsumer : DomainEventHandler<UpdateTermDomainEvent>
	{
		public UpdateTermDomainEventConsumer(ILogger<UpdateTermDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(UpdateTermDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
