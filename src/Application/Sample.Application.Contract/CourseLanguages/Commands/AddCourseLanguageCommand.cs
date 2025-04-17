using Sofa.CourseManagement.Application.Contract.CourseLanguages.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CourseLanguages.Commands
{
	public class AddCourseLanguageCommand : CommandBase<CourseLanguageDto>
	{
		public AddCourseLanguageCommand(string instituteId, string fieldId, string courseId, LanguageEnum language, string courseTitle)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			Language = language;
			CourseTitle = courseTitle;
		}

		public string InstituteId { get; }
		public string FieldId { get; }
		public string CourseId { get; }
		public LanguageEnum Language { get; }
		public string CourseTitle { get; }
	}
}
