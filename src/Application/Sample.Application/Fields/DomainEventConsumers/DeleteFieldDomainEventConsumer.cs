using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Fields;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Fields.DomainEventConsumers
{
	public class DeleteFieldDomainEventConsumer : DomainEventHandler<DeleteFieldDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteFieldDomainEvent> _publisher;
		public DeleteFieldDomainEventConsumer(ILogger<DeleteFieldDomainEventConsumer> logger, IRabbitMQPublisher<DeleteFieldDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteFieldDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
