using Sofa.CourseManagement.Application.Contract.CourseLanguages.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CourseLanguageViewModel : ViewModelBase
	{
		public string InstituteId { set; get; }
		public string FieldId { set; get; }
		public string CourseId { set; get; }
		public LanguageEnum Language { set; get; }
		public string CourseTitle { set; get; }

		internal static CourseLanguageViewModel Create(CourseLanguageDto course)
		{
			return new CourseLanguageViewModel()
			{
				CourseId = course.CourseId,
				CourseTitle = course.CourseTitle,
				FieldId = course.FieldId,
				Id = course.Id,
				InstituteId = course.InstituteId,
				Language = course.Language
			};
		}
	}
	public static class CourseLanguageMapper
	{
		public static Pagination<CourseLanguageViewModel> Map(this Pagination<CourseLanguageDto> pagination)
		{
			return new Pagination<CourseLanguageViewModel>()
			{
				Items = pagination.Items.Select(s => CourseLanguageViewModel.Create(s)),
				TotalItems = pagination.TotalItems
			};
		}
	}
}
