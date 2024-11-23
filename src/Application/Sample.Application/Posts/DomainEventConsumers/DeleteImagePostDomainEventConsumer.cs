using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class DeleteImagePostDomainEventConsumer : DomainEventHandler<DeleteImagePostDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteImagePostDomainEvent> _publisher;
		public DeleteImagePostDomainEventConsumer(ILogger<DeleteImagePostDomainEventConsumer> logger, IRabbitMQPublisher<DeleteImagePostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteImagePostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
