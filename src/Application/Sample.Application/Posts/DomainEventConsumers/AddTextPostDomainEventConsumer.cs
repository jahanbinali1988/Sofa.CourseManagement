using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class AddTextPostDomainEventConsumer : DomainEventHandler<AddTextPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddTextPostDomainEvent> _publisher;
		public AddTextPostDomainEventConsumer(ILogger<AddTextPostDomainEventConsumer> logger, IRabbitMQPublisher<AddTextPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddTextPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
