using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Commands
{
    public class DeletePostCommand : CommandBase
	{
		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id TermId { get; }
		public Id SessionId { get; }
		public Id LessonPlanId { get; }
		public Id PostId { get; }

		public DeletePostCommand(string instituteId, string fieldId, string courseId, string termId, string sessionId, string lessonPlanId, string postId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			SessionId = sessionId;
			LessonPlanId = lessonPlanId;
			PostId = postId;
		}
	}
}
