using MediatR;
using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.CourseUsers.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CreateCourseUserViewModel : ViewModelBase
	{
		public string UserId { get; set; }

		internal AddCourseUserCommand ToCommand(string instituteId, string fieldId, string courseId)
		{
			return new AddCourseUserCommand(instituteId, fieldId, courseId, UserId);
		}
	}
}
