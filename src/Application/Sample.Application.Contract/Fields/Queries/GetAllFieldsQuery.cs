using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Fields.Queries
{
	public class GetAllFieldsQuery : GetListQueryBase, IQuery<Pagination<FieldDto>>
	{
		public Id InstituteId { get; set; }
		public GetAllFieldsQuery(string instituteId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			InstituteId = instituteId;
		}
	}
}
