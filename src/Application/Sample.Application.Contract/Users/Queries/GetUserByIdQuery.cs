using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Application.Contract.Users.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Users.Queries
{
	public class GetUserByIdQuery : GetByIdQueryBase, IQuery<UserDto>
	{
        public GetUserByIdQuery(Guid userId) : base(userId)
		{
		}
	}
}
