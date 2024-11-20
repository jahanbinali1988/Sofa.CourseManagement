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
	public class AddCourseDomainEventConsumer : DomainEventHandler<AddCourseDomainEvent>
	{
		public AddCourseDomainEventConsumer(ILogger<AddCourseDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(AddCourseDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
