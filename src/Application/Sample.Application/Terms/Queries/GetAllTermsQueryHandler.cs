using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.Application.Contract.Terms.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Terms.Queries
{
	internal class GetAllTermsQueryHandler : IQueryHandler<GetAllTermsQuery, Pagination<TermDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllTermsQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<Pagination<TermDto>> Handle(GetAllTermsQuery request, CancellationToken cancellationToken)
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

			var terms = course.Terms.Where(c => c.Title.Value.ToLower().Contains(request.Keyword));
			var termDtos = terms
				.Skip(request.Offset - 1 * request.Count)
				.Take(request.Count)
				.Select(s => new TermDto()
				{
					Id = s.Id,
					Title = s.Title.Value,
					InstituteTitle = institute.Title.Value,
					InstituteId = request.InstituteId,
					FieldId = field.Id,
					FieldTitle = field.Title.Value,
					CourseId = course.Id,
					CourseTitle = course.Title.Value
				});

			return new Pagination<TermDto>()
			{
				Items = termDtos,
				TotalItems = terms.Count()
			};
		}
	}
}
