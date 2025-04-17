using Sofa.CourseManagement.SharedKernel.Application;

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

		public string InstituteId { get; }
		public string FieldId { get; }
		public string CourseId { get; }
		public string PlacementId { get; }
		public string Title { get; }
	}
}
