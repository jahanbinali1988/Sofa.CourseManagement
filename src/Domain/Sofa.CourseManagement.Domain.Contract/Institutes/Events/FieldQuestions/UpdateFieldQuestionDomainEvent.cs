using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestions
{
	public class UpdateFieldQuestionDomainEvent : DomainEventBase
	{
		public UpdateFieldQuestionDomainEvent() : base()
		{
			
		}
		public UpdateFieldQuestionDomainEvent(Guid id, string title, string content, LevelEnum level, QuestionTypeEnum type, Guid fieldId) : this()
		{
			Id = id;
			Title = title;
			Content = content;
			Level = level;
			Type = type;
			FieldId = fieldId;
		}
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public LevelEnum Level { get; set; }
		public QuestionTypeEnum Type { get; set; }

		public Guid FieldId { get; set; }
	}
}
