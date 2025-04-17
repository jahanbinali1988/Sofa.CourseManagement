using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Queries
{
	public class GetAllCoursePlacementQuestionsQuery : GetListQueryBase, IQuery<Pagination<CoursePlacementQuestionDto>>
	{
		public GetAllCoursePlacementQuestionsQuery(string instituteId, string fieldId, string courseId, string placementId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id PlacementId { get; }
	}
}
