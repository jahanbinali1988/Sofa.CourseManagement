using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;
using Sofa.CourseManagement.Application.Contract.Sessions.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Sessions.Queries
{
	internal class GetAllSessionsQueryHandler : IQueryHandler<GetAllSessionsQuery, Pagination<SessionDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllSessionsQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public Task<Pagination<SessionDto>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
