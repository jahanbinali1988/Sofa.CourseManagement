using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.InstituteUsers;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.InstituteUsers.DomainEventConsumers
{
	public class AddInstituteUserDomainEventConsumer : DomainEventHandler<AddInstituteUserDomainEvent>
	{
		private readonly IRabbitMQPublisher<AddInstituteUserDomainEvent> _publisher;
		public AddInstituteUserDomainEventConsumer(ILogger<AddInstituteUserDomainEventConsumer> logger, IRabbitMQPublisher<AddInstituteUserDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(AddInstituteUserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
