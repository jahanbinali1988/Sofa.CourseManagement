using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Courses.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.Queries
{
	internal class GetAllCoursesQueryHandler : IQueryHandler<GetAllCoursesQuery, Pagination<CourseDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllCoursesQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<Pagination<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				return null;

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if(field == null)
				return null;

			var courses = field.Courses.Where(c => string.IsNullOrEmpty(request.Keyword) || request.Keyword.ToLower().Contains(c.Title.Value.ToLower()));
			var courseDtos = courses
				.Skip(request.Offset * request.Count)
				.Take(request.Count)
				.Select(s => new CourseDto()
				{
					Id = s.Id,
					InstituteId = request.InstituteId,
					Title = s.Title.Value,
					AgeRange = s.AgeRange.Value,
					FieldId = field.Id,
					FieldTitle = field.Title.Value,
					InstitueTitle = institute.Title.Value
				});

			return new Pagination<CourseDto>()
			{
				Items = courseDtos,
				TotalItems = courses.Count()
			};
		}
	}
}
