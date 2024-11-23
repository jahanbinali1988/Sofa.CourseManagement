using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Courses;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.DomainEventConsumers
{
	public class AddCourseDomainEventConsumer : DomainEventHandler<AddCourseDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddCourseDomainEvent> _publisher;
		public AddCourseDomainEventConsumer(ILogger<AddCourseDomainEventConsumer> logger, IRabbitMQPublisher<AddCourseDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddCourseDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
