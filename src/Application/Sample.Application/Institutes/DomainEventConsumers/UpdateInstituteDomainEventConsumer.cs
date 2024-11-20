using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Institutes;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.DomainEventConsumers
{
	public class UpdateInstituteDomainEventConsumer : DomainEventHandler<UpdateInstituteDomainEvent>
	{
		public UpdateInstituteDomainEventConsumer(ILogger<UpdateInstituteDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(UpdateInstituteDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
