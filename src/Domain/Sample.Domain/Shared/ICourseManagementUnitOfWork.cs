using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Shared
{
	public interface ICourseManagementUnitOfWork : IUnitOfWork
	{
		IInstituteRepository InstituteRepository { get; }
		IUserRepository UserRepository { get; }
	}
}
