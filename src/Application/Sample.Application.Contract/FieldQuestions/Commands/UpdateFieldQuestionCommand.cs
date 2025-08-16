using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestions.Commands
{
	public class UpdateFieldQuestionCommand : CommandBase
	{
		public UpdateFieldQuestionCommand(string instituteId, string fieldId, string questionId, string title, string content, LevelEnum level, QuestionTypeEnum type)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			QuestionId = questionId;
			Title = title;
			Content = content;
			Level = level;
			Type = type;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id QuestionId { get; }
		public string Title { get; }
		public string Content { get; }
		public LevelEnum Level { get; }
		public QuestionTypeEnum Type { get; }
	}
}
