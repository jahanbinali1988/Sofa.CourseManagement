using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Commands
{
	public class DeleteLessonPlanCommand : CommandBase
	{
		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id SessionId { get; }
		public Id LessonPlanId { get; }

		public DeleteLessonPlanCommand(string instituteId, string fieldId, string courseId, string sessionId, string lessonPlanId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			SessionId = sessionId;
			LessonPlanId = lessonPlanId;
		}
	}
}
