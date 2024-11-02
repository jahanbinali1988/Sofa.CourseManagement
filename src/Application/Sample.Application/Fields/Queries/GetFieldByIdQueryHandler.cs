using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.Fields.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Fields.Queries
{
	internal class GetFieldByIdQueryHandler : IQueryHandler<GetFieldByIdQuery, FieldDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetFieldByIdQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<FieldDto> Handle(GetFieldByIdQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);

			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.Id);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.Id}");

			return new FieldDto() { Id = field.Id, InstituteId = field.InstituteId, Title = field.Title.Value, InstituteTitle = institute.Title.Value };
		}
	}
}
