using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Commands
{
	public class DeleteCoursePlacementQuestionCommand : CommandBase
	{
		public DeleteCoursePlacementQuestionCommand(string instituteId, string fieldId, string courseId, string placementId, string questionId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			PlacementId = placementId;
			QuestionId = questionId;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id PlacementId { get; }
		public Id QuestionId { get; }
	}
}
