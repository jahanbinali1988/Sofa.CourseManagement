using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class DeleteSoundPostDomainEventConsumer : DomainEventHandler<DeleteSoundPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteSoundPostDomainEvent> _publisher;
		public DeleteSoundPostDomainEventConsumer(ILogger<DeleteSoundPostDomainEventConsumer> logger, IRabbitMQPublisher<DeleteSoundPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteSoundPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
