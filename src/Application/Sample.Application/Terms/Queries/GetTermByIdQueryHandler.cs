using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.Application.Contract.Terms.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Terms.Queries
{
	internal class GetTermByIdQueryHandler : IQueryHandler<GetTermByIdQuery, TermDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetTermByIdQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<TermDto> Handle(GetTermByIdQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (course == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {request.CourseId}");

			var term = course.Terms.SingleOrDefault(c => c.Id == request.Id);
			if (term == null)
				throw new EntityNotFoundException($"Could not find Term entity with Id {request.Id}");

			return new TermDto()
			{
				Id = term.Id,
				Title = term.Title.Value,
				CourseId = course.Id,
				CourseTitle = course.Title.Value,
				FieldId = field.Id,
				InstituteId = institute.Id,
				InstituteTitle = institute.Title.Value,
				FieldTitle = field.Title.Value
			};
		}
	}
}
