using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestionChoices
{
	public class AddFieldQuestionChoiceDomainEvent : DomainEventBase
	{
		public AddFieldQuestionChoiceDomainEvent() : base()
		{
			
		}
		public AddFieldQuestionChoiceDomainEvent(Guid id, string content, bool isAnswer, Guid fieldQuestionId, Guid fieldId, Guid instituteId) : this()
		{
			this.Id = id;
			this.Content = content;
			this.IsAnswer = isAnswer;
			this.FieldQuestionId = fieldQuestionId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
		public Guid Id { get; set; }
		public string Content { get; set; }
		public bool IsAnswer { get; set; }
		public Guid FieldQuestionId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
