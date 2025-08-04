using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Institutes;
using Sofa.SharedKernel.EventProcessing.DomainEvent;
using Sofa.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.DomainEventConsumers
{
	public class DeleteInstituteDomainEventConsumer : DomainEventHandler<DeleteInstituteDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteInstituteDomainEvent> _publisher;
		public DeleteInstituteDomainEventConsumer(ILogger<DeleteInstituteDomainEventConsumer> logger, IRabbitMQPublisher<DeleteInstituteDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteInstituteDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
