using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Posts.Commands
{
	public class DeletePostCommand : CommandBase
	{
		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id SessionId { get; }
		public Id LessonPlanId { get; }
		public Id PostId { get; }

		public DeletePostCommand(string instituteId, string fieldId, string courseId, string sessionId, string lessonPlanId, string postId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			SessionId = sessionId;
			LessonPlanId = lessonPlanId;
			PostId = postId;
		}
	}
}
