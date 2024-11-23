using Sofa.CourseManagement.Application.Contract.Courses.Commands;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CreateCourseViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public AgeRangeEnum AgeRange { get; set; }

		internal AddCourseCommand ToCommand(string instituteId, string fieldId)
		{
			return new AddCourseCommand()
			{
				AgeRange = AgeRange,
				FieldId = fieldId,
				InstituteId = instituteId,
				Title = Title
			};
		}

		internal UpdateCourseCommand ToCommand(string instituteId, string fieldId, string id)
		{
			return new UpdateCourseCommand()
			{
				Id = id,
				AgeRange = AgeRange,
				FieldId = fieldId,
				InstituteId = instituteId,
				Title = Title
			};
		}
	}
}
