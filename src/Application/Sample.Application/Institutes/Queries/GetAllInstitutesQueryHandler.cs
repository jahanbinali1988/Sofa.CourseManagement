using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Application.Contract.Institutes.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
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

		public Task<Pagination<InstituteDto>> Handle(GetAllInstitutesQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
