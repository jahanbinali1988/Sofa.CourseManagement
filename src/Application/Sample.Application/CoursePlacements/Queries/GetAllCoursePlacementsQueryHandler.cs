using Sofa.CourseManagement.Application.Contract.CoursePlacements.Dtos;
using Sofa.CourseManagement.Application.Contract.CoursePlacements.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CoursePlacements.Queries
{
	public class GetAllCoursePlacementsQueryHandler : IQueryHandler<GetAllCoursePlacementsQuery, Pagination<CoursePlacementDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllCoursePlacementsQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}
		public async Task<Pagination<CoursePlacementDto>> Handle(GetAllCoursePlacementsQuery request, CancellationToken cancellationToken)
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

			var placementCounts = course.Placements.Count();
			var coursePlacements = course.Placements.Where(c => string.IsNullOrEmpty(request.Keyword) || request.Keyword.ToLower().Contains(c.Title.Value.ToLower()));
			var coursePlacementDtos = coursePlacements
				.Skip(request.Offset * request.Count)
				.Take(request.Count)
				.Select(s => new CoursePlacementDto()
				{
					Id = s.Id,
					Title = s.Title.Value
				});

			return new Pagination<CoursePlacementDto>()
			{
				Items = coursePlacementDtos,
				TotalItems = placementCounts
			};
		}
	}
}
