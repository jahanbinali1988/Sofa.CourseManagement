using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Sessions.DomainEventConsumers
{
	public class DeleteSessionDomainEventConsumer : DomainEventHandler<DeleteSessionDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteSessionDomainEvent> _publisher;
		public DeleteSessionDomainEventConsumer(ILogger<DeleteSessionDomainEventConsumer> logger, IRabbitMQPublisher<DeleteSessionDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteSessionDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
