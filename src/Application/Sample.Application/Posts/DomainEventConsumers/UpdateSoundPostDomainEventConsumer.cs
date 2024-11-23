using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class UpdateSoundPostDomainEventConsumer : DomainEventHandler<UpdateSoundPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateSoundPostDomainEvent> _publisher;
		public UpdateSoundPostDomainEventConsumer(ILogger<UpdateSoundPostDomainEventConsumer> logger, IRabbitMQPublisher<UpdateSoundPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateSoundPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
