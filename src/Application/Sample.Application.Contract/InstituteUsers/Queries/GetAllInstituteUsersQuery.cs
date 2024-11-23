using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.InstituteUsers.Queries
{
	public class GetAllInstituteUsersQuery : GetListQueryBase, IQuery<Pagination<InstituteUserDto>>
	{
		public GetAllInstituteUsersQuery(int offset, int count, string keyword, string? userId, string? instituteId) : base(offset, count, keyword)
		{
			UserId = userId;
			InstituteId = instituteId;
		}

		public Id? UserId { get; set; }
		public Id? InstituteId { get; set; }
	}
}
