using Sofa.CourseManagement.Application.Contract.CourseUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CourseUsers.Commands
{
	public class AddCourseUserCommand : CommandBase<CourseUserDto>
	{
		public AddCourseUserCommand(string courseId, string userId)
		{
			CourseId = courseId;
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
