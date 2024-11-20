using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Institutes.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.Commands
{
	internal class UpdateInstituteCommandHandler : ICommandHandler<UpdateInstituteCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public UpdateInstituteCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(UpdateInstituteCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.Id, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.Id}");

			institute.Update(request.Title, request.Code, request.WebsiteUrl);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
