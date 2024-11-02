using Sofa.CourseManagement.Application.Contract.Institutes.Commands;
using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Application.Contract.Institutes.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.Queries
{
	internal class GetInstituteByIdQueryHandler : IQueryHandler<GetInstituteByIdQuery, InstituteDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetInstituteByIdQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<InstituteDto> Handle(GetInstituteByIdQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.Id, cancellationToken);

			return InstituteDto.CreateDto(institute);
		}
	}
}
