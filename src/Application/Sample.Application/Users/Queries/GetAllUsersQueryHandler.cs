using Sofa.CourseManagement.Application.Contract.Users.Dtos;
using Sofa.CourseManagement.Application.Contract.Users.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Users;
using Sofa.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.Queries
{
	internal class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, Pagination<UserDto>>
	{
		private readonly IUserRepository _userRepository;
		public GetAllUsersQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<Pagination<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
		{
			var users = await _userRepository.GetListAsync(c =>
					string.IsNullOrEmpty(request.Keyword) ||
					c.UserName.Value.Contains(request.Keyword) ||
					c.FirstName.Value.Contains(request.Keyword) ||
					c.LastName.Value.Contains(request.Keyword) ||
					c.Email.Value.Contains(request.Keyword) ||
					c.PhoneNumber.Value.Contains(request.Keyword), request.Offset, request.Count);
			var count = await _userRepository.CountAsync(x => true);

			return new Pagination<UserDto>()
			{
				TotalItems = count,
				Items = users.Select(s => new UserDto()
				{
					Email = s.Email.Value,
					FirstName = s.FirstName.Value,
					Id = s.Id,
					LastName = s.LastName.Value,
					Level = s.Level.Value,
					PhoneNumber = s.PhoneNumber.Value,
					Role = s.Role.Value,
					UserName = s.UserName.Value
				})
			};
		}
	}
}
