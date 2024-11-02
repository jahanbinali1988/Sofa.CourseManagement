using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;
using Sofa.CourseManagement.Application.Contract.Sessions.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Sessions.Queries
{
	internal class GetSessionByIdQueryHandler : IQueryHandler<GetSessionByIdQuery, SessionDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetSessionByIdQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<SessionDto> Handle(GetSessionByIdQuery request, CancellationToken cancellationToken)
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

			var term = course.Terms.SingleOrDefault(c => c.Id == request.TermId);
			if (term == null)
				throw new EntityNotFoundException($"Could not find Term entity with Id {request.TermId}");

			var session = term.Sessions.SingleOrDefault(c => c.Id == request.Id);
			if (session == null)
				throw new EntityNotFoundException($"Could not find Session entity with Id {request.Id}");

			return new SessionDto()
			{
				Id = session.Id,
				Title = session.Title.Value,
				OccurredDate = session.OccurredDate.Value,
				InstituteId = institute.Id,
				InstituteTitle = institute.Title.Value,
				FieldId = field.Id,
				FieldTitle = field.Title.Value,
				CourseId = course.Id,
				CourseTitle = course.Title.Value,
				TermId = term.Id,
				TermTitle = term.Title.Value,
			};
		}
	}
}
