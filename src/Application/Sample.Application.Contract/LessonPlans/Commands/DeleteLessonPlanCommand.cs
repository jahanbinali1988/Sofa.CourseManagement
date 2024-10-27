using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Commands
{
    public class DeleteLessonPlanCommand : CommandBase
    {
        public Guid Id { get; set; }

		public DeleteLessonPlanCommand(Guid id)
		{
			Id = id;
		}
	}
}
