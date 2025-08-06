using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseUser;
using Sofa.SharedKernel.EventProcessing.DomainEvent;
using Sofa.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CourseUsers.DomainEventConsumers
{
	public class DeleteCourseUserDomainEventConsumer : DomainEventHandler<DeleteCourseUserDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteCourseUserDomainEvent> _publisher;
		public DeleteCourseUserDomainEventConsumer(ILogger<DeleteCourseUserDomainEventConsumer> logger, IRabbitMQPublisher<DeleteCourseUserDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteCourseUserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
