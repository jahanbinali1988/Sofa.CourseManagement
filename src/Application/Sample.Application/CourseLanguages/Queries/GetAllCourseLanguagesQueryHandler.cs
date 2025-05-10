using Sofa.CourseManagement.Application.Contract.CourseLanguages.Dtos;
using Sofa.CourseManagement.Application.Contract.CourseLanguages.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CourseLanguages.Queries
{
	public class GetAllCourseLanguagesQueryHandler : IQueryHandler<GetAllCourseLanguagesQuery, Pagination<CourseLanguageDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllCourseLanguagesQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}
		public async Task<Pagination<CourseLanguageDto>> Handle(GetAllCourseLanguagesQuery request, CancellationToken cancellationToken)
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

			var courseLanguageCount = course.CourseLanguages.Count();
			var courseLanguages = course.CourseLanguages.Where(c => string.IsNullOrEmpty(request.Keyword) || request.Keyword.ToLower().Contains(c.Language.Title.ToLower()));
			var courseLanguageDtos = courseLanguages
				.Skip(request.Offset * request.Count)
				.Take(request.Count)
				.Select(s => new CourseLanguageDto()
				{
					Id = s.Id,
					InstituteId = request.InstituteId,
					FieldId = field.Id,
					CourseId = course.Id,
					CourseTitle = course.Title.Value,
					Language = s.Language.Value
				});

			return new Pagination<CourseLanguageDto>()
			{
				Items = courseLanguageDtos,
				TotalItems = courseLanguageCount
			};
		}
	}
}
