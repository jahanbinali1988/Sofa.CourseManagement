using Sofa.CourseManagement.Application.Contract.CourseLanguages.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.SharedKernel.Application;

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

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public LanguageEnum Language { get; }
		public string CourseTitle { get; }
	}
}
