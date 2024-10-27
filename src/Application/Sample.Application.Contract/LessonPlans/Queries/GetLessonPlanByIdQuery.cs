using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Queries
{
	public class GetLessonPlanByIdQuery : GetByIdQueryBase, IQuery<LessonPlanDto>
	{
		public GetLessonPlanByIdQuery(Guid id) : base(id)
		{
		}
	}
}
