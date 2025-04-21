using Sofa.CourseManagement.Application.Contract.CoursePlacements.Dtos;
using Sofa.CourseManagement.Application.Contract.CoursePlacements.Queries;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CoursePlacements.Queries
{
	public class GetCoursePlacementByIdQueryHandler : IQueryHandler<GetCoursePlacementByIdQuery, CoursePlacementDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetCoursePlacementByIdQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}
		public async Task<CoursePlacementDto> Handle(GetCoursePlacementByIdQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);

			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (course == null)
				return null;

			var coursePlacement = course.Placements.SingleOrDefault(c => c.Id == request.Id);

			return new CoursePlacementDto()
			{
				Id = coursePlacement.Id,
				Title = coursePlacement.Title.Value,
			};
		}
	}
}
