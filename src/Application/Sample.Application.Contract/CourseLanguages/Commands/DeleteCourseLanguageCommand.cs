using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CourseLanguages.Commands
{
	public class DeleteCourseLanguageCommand : CommandBase
	{
		public DeleteCourseLanguageCommand(string instituteId, string fieldId, string courseId, string languageId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			LanguageId = languageId;
		}

		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id CourseId { get; set; }
		public Id LanguageId { get; set; }
	}
}
