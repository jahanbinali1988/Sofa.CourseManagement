using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseUser
{
	public class DeleteCourseUserDomainEvent : DomainEventBase
	{
		public DeleteCourseUserDomainEvent()
		{
			
		}
		public DeleteCourseUserDomainEvent(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}
}
