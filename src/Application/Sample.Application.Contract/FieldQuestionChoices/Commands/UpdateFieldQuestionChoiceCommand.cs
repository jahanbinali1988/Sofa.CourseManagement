using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Commands
{
	public class UpdateFieldQuestionChoiceCommand : CommandBase
	{
		public UpdateFieldQuestionChoiceCommand(string instituteId, string fieldId, string fieldQuestionId, string fieldQuestionChoiceId, string content, bool isAnswer)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			FieldQuestionId = fieldQuestionId;
			FieldQuestionChoiceId = fieldQuestionChoiceId;
			Content = content;
			IsAnswer = isAnswer;
		}
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id FieldQuestionId { get; set; }
		public Id FieldQuestionChoiceId { get; set; }
		public string Content { get; set; }
		public bool IsAnswer { get; set; }
	}
}
