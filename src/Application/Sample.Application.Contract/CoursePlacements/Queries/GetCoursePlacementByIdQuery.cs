using Sofa.CourseManagement.Application.Contract.CoursePlacements.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CoursePlacements.Queries
{
	public class GetCoursePlacementByIdQuery : GetByIdQueryBase, IQuery<CoursePlacementDto>
	{
		public GetCoursePlacementByIdQuery(string instituteId, string fieldId, string courseId, string placementId) : base(placementId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
	}
}
