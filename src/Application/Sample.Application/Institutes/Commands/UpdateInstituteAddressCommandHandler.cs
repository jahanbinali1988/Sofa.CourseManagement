using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Institutes.Commands;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.Commands
{
	internal class UpdateInstituteAddressCommandHandler : ICommandHandler<UpdateInstituteAddressCommand>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		public UpdateInstituteAddressCommandHandler(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork)
		{
			_instituteRepository = instituteRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(UpdateInstituteAddressCommand request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.Id, cancellationToken);

			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.Id}");

			var address = Address.CreateInstance(request.Street, request.City, request.State, request.Country, request.ZipCode);

			institute.AssignAddress(address);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
