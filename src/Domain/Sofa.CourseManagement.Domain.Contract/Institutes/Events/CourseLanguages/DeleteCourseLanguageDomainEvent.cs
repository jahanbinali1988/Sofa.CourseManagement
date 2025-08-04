using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseLanguages
{
	public class DeleteCourseLanguageDomainEvent : DomainEventBase
	{
		public DeleteCourseLanguageDomainEvent()
		{
			
		}
		public DeleteCourseLanguageDomainEvent(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}
}
