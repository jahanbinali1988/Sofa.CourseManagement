using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class AddVideoPostDomainEventConsumer : DomainEventHandler<AddVideoPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddVideoPostDomainEvent> _publisher;
		public AddVideoPostDomainEventConsumer(ILogger<AddVideoPostDomainEventConsumer> logger, IRabbitMQPublisher<AddVideoPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddVideoPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
