using Sofa.CourseManagement.Application.Contract.FieldQuestions.Commands;
using Sofa.SharedBusinessEntities;

namespace Sofa.CourseManagement.RestApi.Models.Fields
{
	public class CreateFieldQuestionViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public LevelEnum Level { get; set; }
		public QuestionTypeEnum Type { get; set; }

		internal AddFieldQuestionCommand ToCommand(string instituteId, string fieldId)
		{
			return new AddFieldQuestionCommand(instituteId, fieldId, Title, Content, Level, Type);
		}

		internal UpdateFieldQuestionCommand ToCommand(string instituteId, string fieldId, string questionId)
		{
			return new UpdateFieldQuestionCommand(instituteId, fieldId, questionId, Title, Content, Level, Type);
		}
	}
}
