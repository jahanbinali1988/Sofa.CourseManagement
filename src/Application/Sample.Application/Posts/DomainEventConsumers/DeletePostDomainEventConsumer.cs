using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.SharedKernel.EventProcessing.DomainEvent;
using Sofa.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class DeletePostDomainEventConsumer : DomainEventHandler<DeletePostDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeletePostDomainEvent> _publisher;
		public DeletePostDomainEventConsumer(ILogger<DeletePostDomainEventConsumer> logger, IRabbitMQPublisher<DeletePostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeletePostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
