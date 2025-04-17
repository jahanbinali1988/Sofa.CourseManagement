using Sofa.CourseManagement.Application.Contract.CoursePlacements.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CoursePlacements.Queries
{
	public class GetAllCoursePlacementsQuery : GetListQueryBase, IQuery<Pagination<CoursePlacementDto>>
	{
		public GetAllCoursePlacementsQuery(int offset, int count, string keyword) : base(offset, count, keyword)
		{
		}

		public GetAllCoursePlacementsQuery(string instituteId, string fieldId, string courseId, int offset, int count, string keyword) : this(offset, count, keyword)
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
