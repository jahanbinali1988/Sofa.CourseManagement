using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Infrastructure.Domains.LessonPlans
{
	public class LessonPlanRepository : RepositoryBase<LessonPlan>, ILessonPlanRepository
    {
        public LessonPlanRepository(CourseManagementDbContext dbContext) : base(dbContext)
		{
		}
	}
}
