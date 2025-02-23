using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.UserTerms.Commands
{
	public class DeleteCourseUserCommand : CommandBase
	{
		public Id? UserId { get; }
		public Id? InstituteId { get; }
		public Id? FieldId { get; }
		public Id? CourseId { get; }

		public DeleteCourseUserCommand(string courseId, string userId)
		{
			UserId = userId;
			CourseId = courseId;
		}
		public DeleteCourseUserCommand(string instituteId, string fieldId, string courseId, string userId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			UserId = userId;
		}
	}
}
