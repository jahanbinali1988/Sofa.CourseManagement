using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class DeleteTextPostDomainEventConsumer : DomainEventHandler<DeleteTextPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteTextPostDomainEvent> _publisher;
		public DeleteTextPostDomainEventConsumer(ILogger<DeleteTextPostDomainEventConsumer> logger, IRabbitMQPublisher<DeleteTextPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteTextPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
