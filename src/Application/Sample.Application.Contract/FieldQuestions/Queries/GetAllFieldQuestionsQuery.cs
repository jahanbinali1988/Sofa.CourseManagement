using Sofa.CourseManagement.Application.Contract.FieldQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestions.Queries
{
	public class GetAllFieldQuestionsQuery : GetListQueryBase, IQuery<Pagination<FieldQuestionDto>>
	{
		public GetAllFieldQuestionsQuery(int offset, int count, string keyword) : base(offset, count, keyword)
		{
		}

		public GetAllFieldQuestionsQuery(string instituteId, string fieldId, int offset, int count, string keyword) : this(offset, count, keyword)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
	}
}
