using Sofa.CourseManagement.Application.Contract.FieldQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestions.Queries
{
	public class GetFieldQuestionByIdQuery : GetByIdQueryBase, IQuery<FieldQuestionDto>
	{
		public GetFieldQuestionByIdQuery(string instituteId, string fieldId, string questionId) : base(questionId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
		}

		public string InstituteId { get; }
		public string FieldId { get; }
	}
}
