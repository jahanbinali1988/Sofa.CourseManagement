using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.Application.Contract.Terms.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Terms.Queries
{
	internal class GetAllTermsQueryHandler : IQueryHandler<GetAllTermsQuery, Pagination<TermDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllTermsQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public Task<Pagination<TermDto>> Handle(GetAllTermsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
