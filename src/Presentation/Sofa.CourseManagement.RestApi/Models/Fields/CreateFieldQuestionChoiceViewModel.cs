using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Fields
{
	public class CreateFieldQuestionChoiceViewModel : ViewModelBase
	{
		public string Content { get; set; }
		public bool IsAnswer { get; set; }
		internal UpdateFieldQuestionChoiceCommand ToCommand(string instituteId, string fieldId, string questionId, string choiceId)
		{
			return new UpdateFieldQuestionChoiceCommand(instituteId, fieldId, questionId, choiceId, Content, IsAnswer);
		}

		internal AddFieldQuestionChoiceCommand ToCommand(string instituteId, string fieldId, string questionId)
		{
			return new AddFieldQuestionChoiceCommand(instituteId, fieldId, questionId, Content, IsAnswer);
		}
	}
}
