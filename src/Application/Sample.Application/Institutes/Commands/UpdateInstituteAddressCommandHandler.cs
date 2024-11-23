using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Institutes.Commands;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.Commands
{
	internal class UpdateInstituteAddressCommandHandler : ICommandHandler<UpdateInstituteAddressCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public UpdateInstituteAddressCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(UpdateInstituteAddressCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.UserId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.UserId}");

			var address = Address.CreateInstance(request.Street, request.City, request.State, request.Country, request.ZipCode);
			institute.UpdateAddress(address);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
