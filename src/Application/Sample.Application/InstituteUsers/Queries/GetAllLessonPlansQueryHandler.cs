using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.SharedKernel.Application;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.InstituteUsers.Queries
{
	internal class GetAllLessonPlansQueryHandler : IQueryHandler<GetAllLessonPlansQuery, Pagination<LessonPlanDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllLessonPlansQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<Pagination<LessonPlanDto>> Handle(GetAllLessonPlansQuery request, CancellationToken cancellationToken)
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

			var session = course.Sessions.SingleOrDefault(c => c.Id == request.SessionId);
			if (session == null)
				return null;

			var lessonPlans = session.LessonPlans
				.Skip(request.Offset * request.Count)
				.Take(request.Count)
				.Select(s=> new LessonPlanDto()
			{
				Id = s.Id,
				Title = s.Title.Value,
				InstituteTitle = institute.Title.Value,
				InstituteId = request.InstituteId,
				FieldId = field.Id,
				FieldTitle = field.Title.Value,
				CourseId = course.Id,
				CourseTitle = course.Title.Value,
				OccurredDate = session.OccurredDate.Value,
			});

			return new Pagination<LessonPlanDto>()
			{
				Items = lessonPlans,
				TotalItems = session.LessonPlans.Count()
			};
		}
	}
}
