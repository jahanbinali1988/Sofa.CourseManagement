using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Fields;
using Sofa.SharedKernel.EventProcessing.DomainEvent;
using Sofa.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Fields.DomainEventConsumers
{
	public class AddFieldDomainEventConsumer : DomainEventHandler<AddFieldDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddFieldDomainEvent> _publisher;
		public AddFieldDomainEventConsumer(ILogger<AddFieldDomainEvent> logger, IRabbitMQPublisher<AddFieldDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddFieldDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
