using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.Infrastructure.Persistence;
using System.Linq;

namespace Sofa.CourseManagement.Infrastructure.Domains.Users
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(CourseManagementDbContext dbContext) : base(dbContext)
		{
		}

		protected override IQueryable<User> ConfigureInclude(IQueryable<User> query)
		{
			return query.AsQueryable()
				.Include(x => x.UserTerms)
				.Include(x => x.InstituteUsers);
		}
	}
}
