using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Users.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Users.Commands
{
	internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteUserCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _unitOfWork.UserRepository.GetAsync(request.Id, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Could not find User with Id {request.Id}");

			user.Delete();

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
