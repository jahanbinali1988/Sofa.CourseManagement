using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.UserTerms;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.UserTerms.DomainEventConsumers
{
	public class DeleteCourseUserDomainEventConsumer : DomainEventHandler<DeleteUserTermDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteUserTermDomainEvent> _publisher;
		public DeleteCourseUserDomainEventConsumer(ILogger<DeleteCourseUserDomainEventConsumer> logger, IRabbitMQPublisher<DeleteUserTermDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteUserTermDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
