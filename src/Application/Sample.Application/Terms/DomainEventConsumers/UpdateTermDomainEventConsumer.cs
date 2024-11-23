using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Terms;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Terms.DomainEventConsumers
{
	public class UpdateTermDomainEventConsumer : DomainEventHandler<UpdateTermDomainEvent>
	{
		private readonly IRabbitMQPublisher<UpdateTermDomainEvent> _publisher;
		public UpdateTermDomainEventConsumer(ILogger<UpdateTermDomainEventConsumer> logger, IRabbitMQPublisher<UpdateTermDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(UpdateTermDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
