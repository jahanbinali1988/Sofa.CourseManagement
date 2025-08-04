using Sofa.CourseManagement.Application.Contract.Institutes.Commands;
using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using Sofa.SharedKernel.Generators;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.Commands
{
	internal class AddInstituteCommandHandler : ICommandHandler<AddInstituteCommand, InstituteDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddInstituteCommandHandler(ICourseManagementUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<InstituteDto> Handle(AddInstituteCommand request, CancellationToken cancellationToken)
		{
			var institute = Institute.CreateInstance(_idGenerator.GetNewId(), request.Title, request.Code, request.WebsiteUrl);
			
			await _unitOfWork.InstituteRepository.AddAsync(institute, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			return InstituteDto.CreateDto(institute);
		}
	}
}
