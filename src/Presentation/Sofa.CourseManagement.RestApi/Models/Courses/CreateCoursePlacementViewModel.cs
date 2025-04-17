using Sofa.CourseManagement.Application.Contract.CoursePlacements.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CreateCoursePlacementViewModel : ViewModelBase
	{
		public string Title { get; set; }

		internal UpdateCoursePlacementCommand ToCommand(string instituteId, string fieldId, string courseId, string placementId)
		{
			return new UpdateCoursePlacementCommand(instituteId, fieldId, courseId, placementId, Title);
		}

		internal AddCoursePlacementCommand ToCommand(string instituteId, string fieldId, string courseId)
		{
			return new AddCoursePlacementCommand(instituteId, fieldId, courseId, Title);
		}
	}
}
