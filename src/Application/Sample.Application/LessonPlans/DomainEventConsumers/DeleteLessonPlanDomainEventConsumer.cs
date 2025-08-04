using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans;
using Sofa.SharedKernel.EventProcessing.DomainEvent;
using Sofa.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.DomainEventConsumers
{
	public class DeleteLessonPlanDomainEventConsumer : DomainEventHandler<DeleteLessonPlanDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteLessonPlanDomainEvent> _publisher;
		public DeleteLessonPlanDomainEventConsumer(ILogger<DeleteLessonPlanDomainEventConsumer> logger, IRabbitMQPublisher<DeleteLessonPlanDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteLessonPlanDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
