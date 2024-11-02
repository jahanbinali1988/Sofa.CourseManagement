using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Courses.Queries;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.Queries
{
	internal class GetCourseByIdQueryHandler : IQueryHandler<GetCourseByIdQuery, CourseDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetCourseByIdQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);

			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var course = field.Courses.SingleOrDefault(c=> c.Id == request.Id);
			if (course == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {request.Id}");

			return new CourseDto() 
			{ 
				Id = course.Id, 
				InstituteId = institute.Id, 
				Title = course.Title.Value, 
				FieldId = course.FieldId, 
				AgeRange = course.AgeRange.Value,
				InstitueTitle = institute.Title.Value,
				FieldTitle = field.Title.Value
			};
		}
	}
}
