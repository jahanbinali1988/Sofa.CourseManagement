using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestionChoices
{
	public class UpdateFieldQuestionChoiceDomainEvent : DomainEventBase
	{
		public UpdateFieldQuestionChoiceDomainEvent() : base()
		{

		}
		public UpdateFieldQuestionChoiceDomainEvent(Guid id, string content, bool isAnswer, Guid fieldQuestionId, Guid fieldId, Guid instituteId) : this()
		{
			this.Id= id;
			this.Content= content;
			this.IsAnswer= isAnswer;
			this.FieldQuestionId= fieldQuestionId;
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
