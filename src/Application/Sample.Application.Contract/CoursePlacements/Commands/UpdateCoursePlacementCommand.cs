using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CoursePlacements.Commands
{
	public class UpdateCoursePlacementCommand : CommandBase
	{
		public UpdateCoursePlacementCommand(string instituteId, string fieldId, string courseId, string placementId, string title)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			PlacementId = placementId;
			Title = title;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id PlacementId { get; }
		public string Title { get; }
	}
}
