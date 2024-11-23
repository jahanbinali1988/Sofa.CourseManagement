using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Institutes;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.DomainEventConsumers
{
	public class UpdateInstituteDomainEventConsumer : DomainEventHandler<UpdateInstituteDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateInstituteDomainEvent> _publisher;
		public UpdateInstituteDomainEventConsumer(ILogger<UpdateInstituteDomainEventConsumer> logger, IRabbitMQPublisher<UpdateInstituteDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateInstituteDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
