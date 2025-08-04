using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Users.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.Commands
{
	internal class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public ChangePasswordCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
		{
			var user = await _unitOfWork.UserRepository.GetAsync(request.UserId, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Could not find User with Id {request.UserId}");

			user.ChangePassword(request.NewPassword);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
