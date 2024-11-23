using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Sessions.DomainEventConsumers
{
	public class AddSessionDomainEventConsumer : DomainEventHandler<AddSessionDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddSessionDomainEvent> _publisher;
		public AddSessionDomainEventConsumer(ILogger<AddSessionDomainEventConsumer> logger, IRabbitMQPublisher<AddSessionDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddSessionDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
