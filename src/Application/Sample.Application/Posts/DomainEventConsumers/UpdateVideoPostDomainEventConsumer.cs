using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class UpdateVideoPostDomainEventConsumer : DomainEventHandler<UpdateVideoPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateVideoPostDomainEvent> _publisher;
		public UpdateVideoPostDomainEventConsumer(ILogger<UpdateVideoPostDomainEventConsumer> logger, IRabbitMQPublisher<UpdateVideoPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateVideoPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
