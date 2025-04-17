using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Queries
{
	public class GetFieldQuestionChoiceByIdQuery : GetByIdQueryBase, IQuery<FieldQuestionChoiceDto>
	{
		public GetFieldQuestionChoiceByIdQuery(Id instituteId, Id fieldId, Id fieldQuestionId, string fieldQuestionChoice) : base(fieldQuestionChoice)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			FieldQuestionId = fieldQuestionId;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id FieldQuestionId { get; }
	}
}
