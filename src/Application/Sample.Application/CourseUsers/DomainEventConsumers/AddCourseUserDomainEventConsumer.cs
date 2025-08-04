using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.UserTerms;
using Sofa.SharedKernel.EventProcessing.DomainEvent;
using Sofa.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CourseUsers.DomainEventConsumers
{
	public class AddCourseUserDomainEventConsumer : DomainEventHandler<AddUserTermDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddUserTermDomainEvent> _publisher;
		public AddCourseUserDomainEventConsumer(ILogger<AddCourseUserDomainEventConsumer> logger, IRabbitMQPublisher<AddUserTermDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddUserTermDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
