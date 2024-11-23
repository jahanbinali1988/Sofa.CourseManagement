using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Institutes;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.DomainEventConsumers
{
	public class AddInstituteDomainEventConsumer : DomainEventHandler<AddInstituteDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddInstituteDomainEvent> _publisher;
		public AddInstituteDomainEventConsumer(ILogger<AddInstituteDomainEventConsumer> logger, IRabbitMQPublisher<AddInstituteDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddInstituteDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
