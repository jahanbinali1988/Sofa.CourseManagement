using Sofa.CourseManagement.Application.Contract.CoursePlacements.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CoursePlacements.Commands
{
	public class AddCoursePlacementCommand : CommandBase<CoursePlacementDto>
	{
		public AddCoursePlacementCommand()
		{
		}

		public AddCoursePlacementCommand(string instituteId, string fieldId, string courseId, string title)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			Title = title;
		}

		public string InstituteId { get; }
		public string FieldId { get; }
		public string CourseId { get; }
		public string Title { get; }
	}
}
