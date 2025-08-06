using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacementQuestions
{
	public class AddCoursePlacementQuestionDomainEvent : DomainEventBase
	{
		public AddCoursePlacementQuestionDomainEvent()
		{
			
		}
		public AddCoursePlacementQuestionDomainEvent(Guid id, int order, Guid placementId, Guid questionId, Guid courseId, Guid fieldId, Guid instituteId)
		{
			Id = id;
			Order = order;
			PlacementId = placementId;
			QuestionId = questionId;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public int Order { get; set; }
		public Guid PlacementId { get; set; }
		public Guid QuestionId { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
