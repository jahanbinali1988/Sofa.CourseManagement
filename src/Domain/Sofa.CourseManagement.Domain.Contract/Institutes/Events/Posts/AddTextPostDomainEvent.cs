using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts
{
	public class AddTextPostDomainEvent : DomainEventBase
	{
        public AddTextPostDomainEvent() : base()
        {
            
        }
        public AddTextPostDomainEvent(Guid id, string title, short order, string content, ContentTypeEnum contentType, Guid lessonPlanId) : this()
		{
			Id = id;
			Title = title;
			Order = order;
			Content = content;
			ContentType = contentType;
			LessonPlanId = lessonPlanId;
		}
		public Guid Id { get; set; }
		public string Title { get; set; }
		public short Order { get; set; }
		public string Content { get; set; }
		public ContentTypeEnum ContentType { get; set; }
		public Guid LessonPlanId { get; set; }
	}
}
