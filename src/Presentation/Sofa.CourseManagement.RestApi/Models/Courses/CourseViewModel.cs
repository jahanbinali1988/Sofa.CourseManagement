using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CourseViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public AgeRangeEnum AgeRange { get; set; }
		public string FieldId { get; set; }

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
	public static class CourseMapper
	{
		public static Pagination<CourseViewModel> Map(this Pagination<CourseDto> dto)
		{
			return new Pagination<CourseViewModel>
			{
				TotalItems = dto.TotalItems,
				Items = dto.Items.Select(s=> CourseViewModel.Create(s))
			};
		}
	}
}
