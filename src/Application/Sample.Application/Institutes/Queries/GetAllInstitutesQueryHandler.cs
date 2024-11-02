using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Application.Contract.Institutes.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
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
			var institutes = await _instituteRepository.GetListAsync(x=> x.Title.Value == request.Keyword);

			return new Pagination<InstituteDto>()
			{
				Items = institutes.Select(s => InstituteDto.CreateDto(s)).Skip(request.Offset * request.Count).Take(request.Count),
				TotalItems = institutes.Count()
			};
		}
	}
}
