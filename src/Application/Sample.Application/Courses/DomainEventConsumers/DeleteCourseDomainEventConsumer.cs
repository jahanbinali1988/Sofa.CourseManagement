using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Courses;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.DomainEventConsumers
{
	public class DeleteCourseDomainEventConsumer : DomainEventHandler<DeleteCourseDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteCourseDomainEvent> _publisher;
		public DeleteCourseDomainEventConsumer(ILogger<DeleteCourseDomainEventConsumer> logger, IRabbitMQPublisher<DeleteCourseDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteCourseDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
