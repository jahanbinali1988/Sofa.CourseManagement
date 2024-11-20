using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Courses;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.DomainEventConsumers
{
	public class UpdateCourseDomainEventConsumer : DomainEventHandler<UpdateCourseDomainEvent>
	{
		public UpdateCourseDomainEventConsumer(ILogger<UpdateCourseDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(UpdateCourseDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
