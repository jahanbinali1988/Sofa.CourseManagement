using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Sessions.DomainEventConsumers
{
	public class UpdateSessionDomainEventConsumer : DomainEventHandler<UpdateSessionDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateSessionDomainEvent> _publisher;
		public UpdateSessionDomainEventConsumer(ILogger<UpdateSessionDomainEventConsumer> logger, IRabbitMQPublisher<UpdateSessionDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateSessionDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
