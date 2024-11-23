using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Terms;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Terms.DomainEventConsumers
{
	public class AddTermDomainEventConsumer : DomainEventHandler<AddTermDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddTermDomainEvent> _publisher;
		public AddTermDomainEventConsumer(ILogger<AddTermDomainEventConsumer> logger, IRabbitMQPublisher<AddTermDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddTermDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
