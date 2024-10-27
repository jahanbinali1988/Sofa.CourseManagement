using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Queries
{
	public class GetAllLessonPlansQuery : GetListQueryBase, IQuery<Pagination<LessonPlanDto>>
	{
		public GetAllLessonPlansQuery(int offset, int count, string keyword) : base(offset, count, keyword)
		{
		}
	}
}
