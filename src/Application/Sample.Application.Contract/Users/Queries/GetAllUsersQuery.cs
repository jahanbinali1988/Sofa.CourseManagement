using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Application.Contract.Users.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Users.Queries
{
	public class GetAllUsersQuery : GetListQueryBase, IQuery<Pagination<UserDto>>
	{
		public GetAllUsersQuery(int offset, int count, string keyword) : base(offset, count, keyword)
		{
		}
	}
}
