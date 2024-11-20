using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.InstituteUsers.Queries
{
	public class GetAllInstituteUsersQuery : GetListQueryBase, IQuery<Pagination<InstituteUserDto>>
	{
		public GetAllInstituteUsersQuery(int offset, int count, string keyword, Guid? userId, Guid? instituteId) : base(offset, count, keyword)
		{
			UserId = userId;
			InstituteId = instituteId;
		}

		public Guid? UserId { get; set; }
		public Guid? InstituteId { get; set; }
	}
}
