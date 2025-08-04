using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;
using Sofa.CourseManagement.Domain.Institutes.Entities.Users;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using Sofa.SharedKernel.Generators;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.InstituteUsers.Commands
{
	internal class AddInstituteUserCommandHandler : ICommandHandler<AddInstituteUserCommand, InstituteUserDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddInstituteUserCommandHandler(IIdGenerator idGenerator, ICourseManagementUnitOfWork unitOfWork)
		{
			_idGenerator = idGenerator;
			_unitOfWork = unitOfWork;
		}

		public async Task<InstituteUserDto> Handle(AddInstituteUserCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var user = await _unitOfWork.UserRepository.GetAsync(request.UserId, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Could not find User entity with Id {request.UserId}");

			var instituteUser = InstituteUser.CreateInstance(_idGenerator.GetNewId(), user.Id, institute.Id);
			institute.AddUser(instituteUser);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new InstituteUserDto()
			{
				Id = instituteUser.Id,
				FirstName = user.FirstName.Value,
				LastName = user.LastName.Value,
				InstituteId = instituteUser.Id,
				InstituteTitle = institute.Title.Value,
				UserId = user.Id,
				UserName = user.UserName.Value,
				UserPhoneNumber = user.PhoneNumber.Value
			};
		}
	}
}
