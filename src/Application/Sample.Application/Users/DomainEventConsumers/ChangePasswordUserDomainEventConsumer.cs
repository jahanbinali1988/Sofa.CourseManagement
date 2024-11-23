using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Users.Events;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.DomainEventConsumers
{
	public class ChangePasswordUserDomainEventConsumer : DomainEventHandler<ChangePasswordUserDomainEvent>
	{
		private readonly IRabbitMQPublisher<ChangePasswordUserDomainEvent> _publisher;
		public ChangePasswordUserDomainEventConsumer(ILogger<ChangePasswordUserDomainEventConsumer> logger, IRabbitMQPublisher<ChangePasswordUserDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(ChangePasswordUserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
