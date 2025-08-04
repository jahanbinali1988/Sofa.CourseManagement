using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Commands
{
	public class AddCoursePlacementQuestionCommand : CommandBase<CoursePlacementQuestionDto>
	{
		public AddCoursePlacementQuestionCommand(string instituteId, string fieldId, string courseId, string placementId, string questionId, string questionTitle, short order)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			PlacementId = placementId;
			QuestionId = questionId;
			QuestionTitle = questionTitle;
			Order = order;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id PlacementId { get; }
		public Id QuestionId { get; }
		public string QuestionTitle { get; }
		public short Order { get; }
	}
}
