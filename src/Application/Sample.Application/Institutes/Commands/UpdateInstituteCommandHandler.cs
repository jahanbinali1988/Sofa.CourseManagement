using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Institutes.Commands;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.Commands
{
	internal class UpdateInstituteCommandHandler : ICommandHandler<UpdateInstituteCommand>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		public UpdateInstituteCommandHandler(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork)
		{
			_instituteRepository = instituteRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(UpdateInstituteCommand request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.Id, cancellationToken);

			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.Id}");

			institute.Update(request.Title, request.Code, request.WebsiteUrl);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
