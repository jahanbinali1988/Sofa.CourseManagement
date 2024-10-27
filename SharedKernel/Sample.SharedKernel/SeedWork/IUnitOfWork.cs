using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.SharedKernel.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
