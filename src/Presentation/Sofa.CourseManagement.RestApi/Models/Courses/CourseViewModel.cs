using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CourseViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public AgeRangeEnum AgeRange { get; set; }
		public Guid FieldId { get; set; }

		internal static CourseViewModel Create(CourseDto course)
		{
			return new CourseViewModel()
			{
				Title = course.Title,
				Id = course.Id,
				AgeRange = course.AgeRange,
				FieldId = course.FieldId
			};
		}
	}
}
