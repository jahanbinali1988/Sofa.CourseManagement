using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseUser
{
	public class UpdateCourseUserDomainEvent : DomainEventBase
	{
		public UpdateCourseUserDomainEvent()
		{
			
		}
		public UpdateCourseUserDomainEvent(Guid id, Guid courseId, Guid userId)
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
