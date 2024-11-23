using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.DomainEventConsumers
{
	public class UpdateLessonPlanDomainEventConsumer : DomainEventHandler<UpdateLessonPlanDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateLessonPlanDomainEvent> _publisher;
		public UpdateLessonPlanDomainEventConsumer(ILogger<UpdateLessonPlanDomainEventConsumer> logger, IRabbitMQPublisher<UpdateLessonPlanDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateLessonPlanDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
