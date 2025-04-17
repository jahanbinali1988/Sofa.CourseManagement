using Sofa.CourseManagement.Application.Contract.Shared;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Dtos
{
	public class FieldQuestionChoiceDto : EntityBaseDto
	{
		public string Content { get; set; }
		public bool IsAnswer { get; set; }
	}
}
