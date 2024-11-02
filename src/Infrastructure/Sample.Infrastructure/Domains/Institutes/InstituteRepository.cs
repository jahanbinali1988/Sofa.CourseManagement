using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Infrastructure.Persistence;
using System.Linq;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes
{
    internal class InstituteRepository : RepositoryBase<Institute>, IInstituteRepository
    {
        public InstituteRepository(CourseManagementDbContext dbContext) : base(dbContext)
		{
		}

		protected override IQueryable<Institute> ConfigureInclude(IQueryable<Institute> query)
		{
			return query.AsQueryable()
				.Include(x=> x.Fields)
				.ThenInclude(x=> x.Courses)
				.ThenInclude(x=> x.Terms)
				.ThenInclude(x=> x.Sessions)
				.ThenInclude(x=> x.LessonPlan)
				.ThenInclude(x=> x.Posts);
		}
	}
}
