using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Users.Events;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.DomainEventConsumers
{
	public class UpdateUserDomainEventConsumer : DomainEventHandler<UpdateUserDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateUserDomainEvent> _publisher;
		public UpdateUserDomainEventConsumer(ILogger<UpdateUserDomainEventConsumer> logger, IRabbitMQPublisher<UpdateUserDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateUserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
