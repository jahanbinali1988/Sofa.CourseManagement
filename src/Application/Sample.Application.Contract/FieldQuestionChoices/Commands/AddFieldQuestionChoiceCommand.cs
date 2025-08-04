using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Commands
{
	public class AddFieldQuestionChoiceCommand : CommandBase<FieldQuestionChoiceDto>
	{
		public AddFieldQuestionChoiceCommand(string instituteId, string fieldId, string fieldQuestionId, string content, bool isAnswer)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			FieldQuestionId = fieldQuestionId;
			Content = content;
			IsAnswer = isAnswer;
		}
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id FieldQuestionId { get; set; }
		public string Content { get; set; }
		public bool IsAnswer { get; set; }
	}
}
