using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Infrastructure.Persistence;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes
{
    internal class InstituteRepository : RepositoryBase<Institute>, IInstituteRepository
    {
        public InstituteRepository(CourseManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
