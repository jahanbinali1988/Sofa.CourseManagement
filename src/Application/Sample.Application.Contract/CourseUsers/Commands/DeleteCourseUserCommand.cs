using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.CourseUsers.Commands
{
	public class DeleteCourseUserCommand : CommandBase
	{
		public Id? UserId { get; set; }
		public Id? InstituteId { get; set; }
		public Id? FieldId { get; set; }
		public Id? CourseId { get; set; }

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
