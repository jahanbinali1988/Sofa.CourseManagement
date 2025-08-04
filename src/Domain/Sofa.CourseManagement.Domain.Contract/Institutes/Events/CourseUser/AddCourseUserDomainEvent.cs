using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseUser
{
	public class AddCourseUserDomainEvent : DomainEventBase
	{
		public AddCourseUserDomainEvent()
		{
			
		}
		public AddCourseUserDomainEvent(Guid id, Guid courseId, Guid userId)
		{
			Id = id;
			CourseId = courseId;
			UserId = userId;
		}

		public Guid Id { get; }
		public Guid CourseId { get; }
		public Guid UserId { get; }
	}
}
