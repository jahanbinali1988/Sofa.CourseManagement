using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Fields.Commands;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Fields.Commands
{
	internal class UpdateFieldCommandHandler : ICommandHandler<UpdateFieldCommand>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		public UpdateFieldCommandHandler(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork)
		{
			_instituteRepository = instituteRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(UpdateFieldCommand request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c=> c.Id == request.Id);
			if (field == null)
				throw new EntityNotFoundException($"Could not find field entity with Id {request.Id}");

			field.Update(request.Title);
			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
