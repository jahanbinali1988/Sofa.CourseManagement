using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class AddPostDomainEventConsumer : DomainEventHandler<AddPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddPostDomainEvent> _publisher;
		public AddPostDomainEventConsumer(ILogger<AddPostDomainEventConsumer> logger, IRabbitMQPublisher<AddPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
