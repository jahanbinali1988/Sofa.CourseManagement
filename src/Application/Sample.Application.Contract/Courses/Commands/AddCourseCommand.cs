using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Courses.Commands
{
	public class AddCourseCommand : CommandBase<CourseDto>
	{
		public string Title { get; set; }
		public AgeRangeEnum AgeRange { get; set; }
		public Id FieldId { get; set; }
		public Id InstituteId { get; set; }
	}
}
