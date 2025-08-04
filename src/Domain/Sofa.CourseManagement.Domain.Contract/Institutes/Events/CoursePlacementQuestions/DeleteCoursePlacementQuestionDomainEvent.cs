using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacementQuestions
{
	public class DeleteCoursePlacementQuestionDomainEvent : DomainEventBase
	{
		public DeleteCoursePlacementQuestionDomainEvent()
		{
			
		}
		public DeleteCoursePlacementQuestionDomainEvent(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}
}
