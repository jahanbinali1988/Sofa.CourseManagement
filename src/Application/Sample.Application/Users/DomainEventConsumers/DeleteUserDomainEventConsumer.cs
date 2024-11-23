using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Users.Events;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.DomainEventConsumers
{
	public class DeleteUserDomainEventConsumer : DomainEventHandler<DeleteUserDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteUserDomainEvent> _publisher;
		public DeleteUserDomainEventConsumer(ILogger<DeleteUserDomainEventConsumer> logger, IRabbitMQPublisher<DeleteUserDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteUserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
