using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Sessions.Queries
{
	public class GetSessionByIdQuery : GetByIdQueryBase, IQuery<SessionDto>
	{
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id CourseId { get; set; }
		public GetSessionByIdQuery(string instituteId, string fieldId, string courseId, string id) : base(id)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
		}
	}
}
