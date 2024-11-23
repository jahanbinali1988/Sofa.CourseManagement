using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class UpdateImagePostDomainEventConsumer : DomainEventHandler<UpdateImagePostDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateImagePostDomainEvent> _publisher;
		public UpdateImagePostDomainEventConsumer(ILogger<UpdateImagePostDomainEventConsumer> logger, IRabbitMQPublisher<UpdateImagePostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateImagePostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
