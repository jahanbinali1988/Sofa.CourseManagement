using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestions
{
	public class AddFieldQuestionDomainEvent : DomainEventBase
	{
		public AddFieldQuestionDomainEvent() : base()
		{
			
		}
		public AddFieldQuestionDomainEvent(Guid id, string title, string content, LevelEnum level, QuestionTypeEnum type, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			Title = title;
			Content = content;
			Level = level;
			Type = type;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public LevelEnum Level { get; set; }
		public QuestionTypeEnum Type { get; set; }

		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
