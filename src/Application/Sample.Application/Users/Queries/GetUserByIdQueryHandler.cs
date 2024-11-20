using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Users.Dtos;
using Sofa.CourseManagement.Application.Contract.Users.Queries;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.Queries
{
	internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
	{
		private readonly IUserRepository _userRepository;
		public GetUserByIdQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetAsync(request.Id, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Could not find User with Id {request.Id}");

			return new UserDto()
			{
				Id = user.Id,
				Email = user.Email.Value,
				FirstName = user.FirstName.Value,
				LastName = user.LastName.Value,
				Level = user.Level.Value,
				PhoneNumber = user.PhoneNumber.Value,
				Role = user.Role.Value,
				UserName = user.UserName.Value
			};
		}
	}
}
