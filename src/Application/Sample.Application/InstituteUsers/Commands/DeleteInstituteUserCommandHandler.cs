using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.InstituteUsers.Commands
{
	internal class DeleteInstituteUserCommandHandler : ICommandHandler<DeleteInstituteUserCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteInstituteUserCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteInstituteUserCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var instituteUsers = institute.InstituteUsers.FirstOrDefault(c => c.UserId == request.UserId);
			if (instituteUsers == null)
				throw new EntityNotFoundException($"Could not find InstituteUser entity with User Id {request.UserId}");

			instituteUsers.Delete();
			//institute.DeleteUser(instituteUsers);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
