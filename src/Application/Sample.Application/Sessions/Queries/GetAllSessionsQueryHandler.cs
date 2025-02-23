using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;
using Sofa.CourseManagement.Application.Contract.Sessions.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Linq;
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

		public async Task<Pagination<SessionDto>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				return null;

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				return null;

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (course == null)
				return null;

			var sessions = course.Sessions.Where(c => c.Title.Value.ToLower().Contains(request.Keyword));
			var sessionsDtos = sessions
				.Skip(request.Offset - 1 * request.Count)
				.Take(request.Count)
				.Select(s => new SessionDto()
				{
					Id = s.Id,
					Title = s.Title.Value,
					InstituteTitle = institute.Title.Value,
					InstituteId = request.InstituteId,
					FieldId = field.Id,
					FieldTitle = field.Title.Value,
					CourseId = course.Id,
					CourseTitle = course.Title.Value,
					OccurredDate = s.OccurredDate.Value,
				});

			return new Pagination<SessionDto>()
			{
				Items = sessionsDtos,
				TotalItems = sessions.Count()
			};
		}
	}
}
