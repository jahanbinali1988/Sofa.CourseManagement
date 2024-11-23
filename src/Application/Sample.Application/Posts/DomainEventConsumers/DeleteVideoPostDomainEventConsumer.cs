using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class DeleteVideoPostDomainEventConsumer : DomainEventHandler<DeleteVideoPostDomainEvent>
	{
		private readonly IRabbitMQPublisher<DeleteVideoPostDomainEvent> _publisher;
		public DeleteVideoPostDomainEventConsumer(ILogger<DeleteVideoPostDomainEventConsumer> logger, IRabbitMQPublisher<DeleteVideoPostDomainEvent> publisher) : base(logger)
		{
			_publisher = publisher;
		}

		protected override async Task HandleEvent(DeleteVideoPostDomainEvent notification, CancellationToken cancellationToken)
		{
			await _publisher.PublishMessageAsync(notification, "");
		}
	}
}
