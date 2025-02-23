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
				.Include(x=> x.Fields).ThenInclude(x => x.Questions).ThenInclude(x => x.QuestionChoices)
				.Include(x => x.Fields).ThenInclude(x => x.Questions)
				.Include(x => x.Fields).ThenInclude(x=> x.Courses).ThenInclude(x=> x.CourseUsers)
				.Include(x => x.Fields).ThenInclude(x => x.Courses).ThenInclude(x => x.Placements)
				.Include(x => x.Fields).ThenInclude(x => x.Courses).ThenInclude(x => x.CourseLanguages)
				.Include(x => x.Fields).ThenInclude(x => x.Courses).ThenInclude(x=> x.Sessions)
				.Include(x => x.Fields).ThenInclude(x => x.Courses).ThenInclude(x=> x.Sessions).ThenInclude(x=> x.LessonPlans)
				.Include(x => x.Fields).ThenInclude(x => x.Courses).ThenInclude(x => x.Sessions).ThenInclude(x => x.LessonPlans).ThenInclude(x=> x.Posts).ThenInclude(x=> x.Question);
		}
	}
}
