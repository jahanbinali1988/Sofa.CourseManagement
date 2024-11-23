using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class AddSoundPostDomainEventConsumer : DomainEventHandler<AddSoundPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddSoundPostDomainEvent> _publisher;
		public AddSoundPostDomainEventConsumer(ILogger<AddSoundPostDomainEventConsumer> logger, IRabbitMQPublisher<AddSoundPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddSoundPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
