using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacementQuestions
{
	public class UpdateCoursePlacementQuestionDomainEvent : DomainEventBase
	{
		public UpdateCoursePlacementQuestionDomainEvent()
		{
			
		}
		public UpdateCoursePlacementQuestionDomainEvent(Guid id, int order, Guid placementId, Guid questionId)
		{
			Id = id;
			Order = order;
			PlacementId = placementId;
			QuestionId = questionId;
		}

		public Guid Id { get; }
		public int Order { get; }
		public Guid PlacementId { get; }
		public Guid QuestionId { get; }
	}
}
