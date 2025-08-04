using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Commands
{
	public class DeleteFieldQuestionChoiceCommand : CommandBase
	{
		public DeleteFieldQuestionChoiceCommand(string instituteId, string fieldId, string fieldQuestionId, string fieldQuestionChoiceId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			FieldQuestionId = fieldQuestionId;
			FieldQuestionChoiceId = fieldQuestionChoiceId;
		}
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id FieldQuestionId { get; set; }
		public Id FieldQuestionChoiceId { get; set; }
	}
}
