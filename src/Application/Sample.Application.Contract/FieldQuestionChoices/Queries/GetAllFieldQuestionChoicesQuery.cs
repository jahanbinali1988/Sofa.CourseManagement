using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Queries
{
	public class GetAllFieldQuestionChoicesQuery : GetListQueryBase, IQuery<Pagination<FieldQuestionChoiceDto>>
	{
		public GetAllFieldQuestionChoicesQuery(string instituteId, string fieldId, string fieldQuestionId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			FieldQuestionId = fieldQuestionId;
		}
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id FieldQuestionId { get; set; }
	}
}
