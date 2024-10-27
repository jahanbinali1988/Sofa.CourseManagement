using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.Fields.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Fields.Queries
{
	internal class GetAllFieldsQueryHandler : IQueryHandler<GetAllFieldsQuery, Pagination<FieldDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllFieldsQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public Task<Pagination<FieldDto>> Handle(GetAllFieldsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
