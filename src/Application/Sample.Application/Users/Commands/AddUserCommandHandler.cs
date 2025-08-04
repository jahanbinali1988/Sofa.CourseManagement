using Sofa.CourseManagement.Application.Contract.Users.Commands;
using Sofa.CourseManagement.Application.Contract.Users.Dtos;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.Domain.Users;
using Sofa.SharedKernel.Application;
using Sofa.SharedKernel.Generators;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.Commands
{
	internal class AddUserCommandHandler : ICommandHandler<AddUserCommand, UserDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddUserCommandHandler(ICourseManagementUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<UserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			var user = User.CreateInstance(_idGenerator.GetNewId(), request.FirstName, request.LastName, request.Password, request.Email, request.UserName, request.PhoneNumber, request.Role, request.Level);

			await _unitOfWork.UserRepository.AddAsync(user, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new UserDto()
			{
				Email = user.Email.Value,
				FirstName = user.FirstName.Value,
				Id = user.Id,
				LastName = user.LastName.Value,
				Level = user.Level.Value,
				PhoneNumber = user.PhoneNumber.Value,
				Role = user.Role.Value,
				UserName = user.UserName.Value
			};
		}
	}
}
