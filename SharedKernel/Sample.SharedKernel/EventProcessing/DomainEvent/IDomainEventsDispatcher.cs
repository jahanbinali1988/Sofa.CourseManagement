using System.Threading.Tasks;

namespace Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}
