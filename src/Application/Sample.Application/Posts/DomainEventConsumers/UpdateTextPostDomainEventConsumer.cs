using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class UpdateTextPostDomainEventConsumer : DomainEventHandler<UpdateTextPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateTextPostDomainEvent> _publisher;
		public UpdateTextPostDomainEventConsumer(ILogger<UpdateTextPostDomainEventConsumer> logger, IRabbitMQPublisher<UpdateTextPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateTextPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
