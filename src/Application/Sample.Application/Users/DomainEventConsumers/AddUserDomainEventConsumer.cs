using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Users.Events;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.DomainEventConsumers
{
	public class AddUserDomainEventConsumer : DomainEventHandler<AddUserDomainEvent>
	{
		public AddUserDomainEventConsumer(ILogger<AddUserDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(AddUserDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
