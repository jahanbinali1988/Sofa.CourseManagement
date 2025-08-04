using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Application.Contract.Users.Dtos;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Users.Queries
{
	public class GetUserByIdQuery : GetByIdQueryBase, IQuery<UserDto>
	{
        public GetUserByIdQuery(string userId) : base(userId)
		{
		}
	}
}
