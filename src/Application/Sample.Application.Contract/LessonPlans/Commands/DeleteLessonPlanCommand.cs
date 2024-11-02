using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Commands
{
	public class DeleteLessonPlanCommand : CommandBase
	{
		public Guid InstituteId { get; }
		public Guid FieldId { get; }
		public Guid CourseId { get; }
		public Guid TermId { get; }
		public Guid SessionId { get; }
		public Guid LessonPlanId { get; }

		public DeleteLessonPlanCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid sessionId, Guid lessonPlanId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			SessionId = sessionId;
			LessonPlanId = lessonPlanId;
		}
	}
}
