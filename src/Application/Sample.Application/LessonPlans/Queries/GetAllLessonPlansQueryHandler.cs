using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Queries;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.Queries
{
	internal class GetAllLessonPlansQueryHandler : IQueryHandler<GetAllLessonPlansQuery, Pagination<LessonPlanDto>>
	{
		private readonly ILessonPlanRepository _lessonPlanRepository;
		public GetAllLessonPlansQueryHandler(ILessonPlanRepository lessonPlanRepository)
		{
			_lessonPlanRepository = lessonPlanRepository;
		}

		public Task<Pagination<LessonPlanDto>> Handle(GetAllLessonPlansQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
