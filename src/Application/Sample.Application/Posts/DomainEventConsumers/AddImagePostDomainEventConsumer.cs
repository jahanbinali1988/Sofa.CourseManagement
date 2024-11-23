using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class AddImagePostDomainEventConsumer : DomainEventHandler<AddImagePostDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddImagePostDomainEvent> _publisher;
		public AddImagePostDomainEventConsumer(ILogger<AddImagePostDomainEventConsumer> logger, IRabbitMQPublisher<AddImagePostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddImagePostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
