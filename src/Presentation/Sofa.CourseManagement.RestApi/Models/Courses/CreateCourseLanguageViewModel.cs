using Sofa.CourseManagement.Application.Contract.CourseLanguages.Commands;
using Sofa.SharedBusinessEntities;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CreateCourseLanguageViewModel : ViewModelBase
	{
		public LanguageEnum Language { get; set; }
		public string CourseTitle { get; set; }

		internal AddCourseLanguageCommand ToCommand(string instituteId, string fieldId, string courseId)
		{
			return new AddCourseLanguageCommand(instituteId, fieldId, courseId, Language, CourseTitle);
		}
	}
}
