using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Users.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.Commands
{
	internal class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public UpdateUserCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _unitOfWork.UserRepository.GetAsync(request.Id, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Could not find User with Id {request.Id}");

			user.Update(request.FirstName, request.LastName, request.Email, request.UserName, request.PhoneNumber, request.Role, request.Level);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
