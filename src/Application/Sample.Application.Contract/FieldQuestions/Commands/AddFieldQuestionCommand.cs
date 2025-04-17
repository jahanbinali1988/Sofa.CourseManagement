using Sofa.CourseManagement.Application.Contract.FieldQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestions.Commands
{
	public class AddFieldQuestionCommand : CommandBase<FieldQuestionDto>
	{
		public AddFieldQuestionCommand(string instituteId, string fieldId, string title, string content, LevelEnum level, QuestionType type)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			Title = title;
			Content = content;
			Level = level;
			Type = type;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public string Title { get; }
		public string Content { get; }
		public LevelEnum Level { get; }
		public QuestionType Type { get; }
	}
}
