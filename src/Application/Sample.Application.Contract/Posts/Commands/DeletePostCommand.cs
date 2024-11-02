using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Commands
{
    public class DeletePostCommand : CommandBase
	{
		public Guid InstituteId { get; }
		public Guid FieldId { get; }
		public Guid CourseId { get; }
		public Guid TermId { get; }
		public Guid SessionId { get; }
		public Guid LessonPlanId { get; }
		public Guid PostId { get; }

		public DeletePostCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid sessionId, Guid lessonPlanId, Guid postId)
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
