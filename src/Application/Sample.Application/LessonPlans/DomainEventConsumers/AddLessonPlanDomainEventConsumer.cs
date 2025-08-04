using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans;
using Sofa.SharedKernel.EventProcessing.DomainEvent;
using Sofa.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.DomainEventConsumers
{
	public class AddLessonPlanDomainEventConsumer : DomainEventHandler<AddLessonPlanDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddLessonPlanDomainEvent> _publisher;
		public AddLessonPlanDomainEventConsumer(ILogger<AddLessonPlanDomainEventConsumer> logger, IRabbitMQPublisher<AddLessonPlanDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddLessonPlanDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
