using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Queries;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.Queries
{
	internal class GetLessonPlanByIdQueryHandler : IQueryHandler<GetLessonPlanByIdQuery, LessonPlanDto>
	{
		private readonly ILessonPlanRepository _lessonPlanRepository;
		public GetLessonPlanByIdQueryHandler(ILessonPlanRepository lessonPlanRepository)
		{
			_lessonPlanRepository = lessonPlanRepository;
		}

		public Task<LessonPlanDto> Handle(GetLessonPlanByIdQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
