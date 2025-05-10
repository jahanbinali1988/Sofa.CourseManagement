using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class UpdatePostDomainEventConsumer : DomainEventHandler<UpdatePostDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdatePostDomainEvent> _publisher;
		public UpdatePostDomainEventConsumer(ILogger<UpdatePostDomainEventConsumer> logger, IRabbitMQPublisher<UpdatePostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdatePostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
