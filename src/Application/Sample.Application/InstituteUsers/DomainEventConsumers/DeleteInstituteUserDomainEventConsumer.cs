using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.InstituteUsers;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.InstituteUsers.DomainEventConsumers
{
	public class DeleteInstituteUserDomainEventConsumer : DomainEventHandler<DeleteInstituteUserDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteInstituteUserDomainEvent> _publisher;
		public DeleteInstituteUserDomainEventConsumer(ILogger<DeleteInstituteUserDomainEventConsumer> logger, IRabbitMQPublisher<DeleteInstituteUserDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteInstituteUserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
