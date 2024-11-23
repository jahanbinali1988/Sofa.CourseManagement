using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.UserTerms;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.UserTerms.DomainEventConsumers
{
	public class AddUserTermDomainEventConsumer : DomainEventHandler<AddUserTermDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddUserTermDomainEvent> _publisher;
		public AddUserTermDomainEventConsumer(ILogger<AddUserTermDomainEventConsumer> logger, IRabbitMQPublisher<AddUserTermDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddUserTermDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
