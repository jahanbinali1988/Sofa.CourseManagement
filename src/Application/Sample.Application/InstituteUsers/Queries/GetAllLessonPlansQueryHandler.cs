using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Queries;
using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;
using Sofa.CourseManagement.Application.Contract.Sessions.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.InstituteUsers.Queries
{
	internal class GetAllLessonPlansQueryHandler : IQueryHandler<GetAllLessonPlansQuery, LessonPlanDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllLessonPlansQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public async Task<LessonPlanDto> Handle(GetAllLessonPlansQuery request, CancellationToken cancellationToken)
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

			var term = course.Terms.SingleOrDefault(c => c.Id == request.TermId);
			if (term == null)
				return null;

			var session = term.Sessions.SingleOrDefault(c => c.Id == request.SessionId);
			if (term == null)
				return null;

			var lessonPlan = session.LessonPlan;
			var lessonPlanDto = new LessonPlanDto()
			{
				Id = s.Id,
				Title = s.Title.Value,
				InstituteTitle = institute.Title.Value,
				InstituteId = request.InstituteId,
				FieldId = field.Id,
				FieldTitle = field.Title.Value,
				CourseId = course.Id,
				CourseTitle = course.Title.Value,
				TermId = term.Id,
				TermTitle = term.Title.Value,
				OccurredDate = s.OccurredDate.Value,
			};

			return lessonPlan;
		}
	}
}
