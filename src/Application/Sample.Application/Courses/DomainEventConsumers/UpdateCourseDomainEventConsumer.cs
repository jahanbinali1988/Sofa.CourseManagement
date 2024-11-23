using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Courses;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.DomainEventConsumers
{
	public class UpdateCourseDomainEventConsumer : DomainEventHandler<UpdateCourseDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateCourseDomainEvent> _publisher;
		public UpdateCourseDomainEventConsumer(ILogger<UpdateCourseDomainEventConsumer> logger, IRabbitMQPublisher<UpdateCourseDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateCourseDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
