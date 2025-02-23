using Sofa.CourseManagement.Application.Contract.UserTerms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.UserTerms.Commands
{
	public class AddCourseUserCommand : CommandBase<CourseUserDto>
	{
		public AddCourseUserCommand(string termId, string userId)
		{
			CourseId = termId;
			UserId = userId;
		}

		public AddCourseUserCommand(string instituteId, string fieldId, string courseId, string userId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			UserId = userId;
		}

		public Id? InstituteId { get; }
		public Id? FieldId { get; }
		public Id? CourseId { get; }
		public Id? UserId { get; }
	}
}
