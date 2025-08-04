using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Queries
{
	public class GetAllInstitutesQuery : GetListQueryBase, IQuery<Pagination<InstituteDto>>
	{
		public GetAllInstitutesQuery(string keyword, int offset, int count) : base(offset, count, keyword)
		{
		}
	}
}
