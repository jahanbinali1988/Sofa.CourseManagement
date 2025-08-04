using Sofa.CourseManagement.Application.Contract.CoursePlacements.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

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

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public string Title { get; }
	}
}
