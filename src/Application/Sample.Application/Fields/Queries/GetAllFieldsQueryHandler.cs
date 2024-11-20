using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.Fields.Queries;
using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Linq;
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

		public async Task<Pagination<FieldDto>> Handle(GetAllFieldsQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				return null;

			var fields = institute.Fields.Where(c => c.Title.Value.Contains(request.Keyword));
			var fieldDtos = fields
				.Skip(request.Offset - 1 * request.Count)
				.Take(request.Count)
				.Select(s => new FieldDto()
				{
					Id = s.Id,
					InstituteId = s.InstituteId,
					Title = s.Title.Value,
					InstituteTitle = institute.Title.Value
				});

			return new Pagination<FieldDto>()
			{
				Items = fieldDtos,
				TotalItems = fields.Count()
			};
		}
	}
}
