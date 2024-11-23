using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Fields;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Fields.DomainEventConsumers
{
	public class UpdateFieldDomainEventConsumer : DomainEventHandler<UpdateFieldDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateFieldDomainEvent> _publisher;
		public UpdateFieldDomainEventConsumer(ILogger<UpdateFieldDomainEventConsumer> logger, IRabbitMQPublisher<UpdateFieldDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateFieldDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
