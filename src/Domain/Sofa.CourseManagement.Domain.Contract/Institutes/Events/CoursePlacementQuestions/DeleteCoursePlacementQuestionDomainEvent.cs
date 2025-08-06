using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacementQuestions
{
	public class DeleteCoursePlacementQuestionDomainEvent : DomainEventBase
	{
		public DeleteCoursePlacementQuestionDomainEvent()
		{
			
		}
		public DeleteCoursePlacementQuestionDomainEvent(Guid id, Guid placementId, Guid courseId, Guid fieldId, Guid instituteId)
		{
			Id = id;
			PlacementId = placementId;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public Guid PlacementId { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
