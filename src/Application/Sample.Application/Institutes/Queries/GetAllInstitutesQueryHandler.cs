using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Application.Contract.Institutes.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.Queries
{
	internal class GetAllInstitutesQueryHandler : IQueryHandler<GetAllInstitutesQuery, Pagination<InstituteDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllInstitutesQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<Pagination<InstituteDto>> Handle(GetAllInstitutesQuery request, CancellationToken cancellationToken)
		{
			var institutes = await _instituteRepository.GetListAsync(x =>
				string.IsNullOrEmpty(request.Keyword) || x.Title.Value.ToLower().Contains(request.Keyword.ToLower()), request.Offset, request.Count);
			var count = await _instituteRepository.CountAsync(x=> true);

			return new Pagination<InstituteDto>()
			{
				Items = institutes.Select(s => InstituteDto.CreateDto(s)),
				TotalItems = count
			};
		}
	}
}
