using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestions.Commands
{
	public class DeleteFieldQuestionCommand : CommandBase
	{
		public DeleteFieldQuestionCommand(string instituteId, string fieldId, string questionId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			QuestionId = questionId;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id QuestionId { get; }
	}
}
