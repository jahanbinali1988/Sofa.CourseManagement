using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Terms;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Terms.DomainEventConsumers
{
	public class DeleteTermDomainEventConsumer : DomainEventHandler<DeleteTermDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteTermDomainEvent> _publisher;
		public DeleteTermDomainEventConsumer(ILogger<DeleteTermDomainEventConsumer> logger, IRabbitMQPublisher<DeleteTermDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteTermDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
