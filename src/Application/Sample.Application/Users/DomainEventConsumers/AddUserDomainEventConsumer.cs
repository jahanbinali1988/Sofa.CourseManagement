using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Users.Events;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.DomainEventConsumers
{
	public class AddUserDomainEventConsumer : DomainEventHandler<AddUserDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddUserDomainEvent> _publisher;
		public AddUserDomainEventConsumer(ILogger<AddUserDomainEventConsumer> logger, IRabbitMQPublisher<AddUserDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddUserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
