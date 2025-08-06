using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts
{
	public class UpdatePostDomainEvent : DomainEventBase
	{
		public UpdatePostDomainEvent() : base()
		{

		}
		public UpdatePostDomainEvent(Guid id, string title, short order, string content, ContentTypeEnum contentType, Guid lessonPlanId, Guid sessionId, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			Title = title;
			Order = order;
			Content = content;
			ContentType = contentType;
			LessonPlanId = lessonPlanId;
			SessionId = sessionId;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
		public Guid Id { get; set; }
		public string Title { get; set; }
		public short Order { get; set; }
		public string Content { get; set; }
		public ContentTypeEnum ContentType { get; set; }
		public Guid LessonPlanId { get; set; }
		public Guid SessionId { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
