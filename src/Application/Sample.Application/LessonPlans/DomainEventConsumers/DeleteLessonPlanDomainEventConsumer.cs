using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.DomainEventConsumers
{
	public class DeleteLessonPlanDomainEventConsumer : DomainEventHandler<DeleteLessonPlanDomainEvent>
	{
		public DeleteLessonPlanDomainEventConsumer(ILogger<DeleteLessonPlanDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(DeleteLessonPlanDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
