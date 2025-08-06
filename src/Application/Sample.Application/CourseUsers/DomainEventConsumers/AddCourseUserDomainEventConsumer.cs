using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseUser;
using Sofa.SharedKernel.EventProcessing.DomainEvent;
using Sofa.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CourseUsers.DomainEventConsumers
{
	public class AddCourseUserDomainEventConsumer : DomainEventHandler<AddCourseUserDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddCourseUserDomainEvent> _publisher;
		public AddCourseUserDomainEventConsumer(ILogger<AddCourseUserDomainEventConsumer> logger, IRabbitMQPublisher<AddCourseUserDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddCourseUserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
