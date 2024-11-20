using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans
{
    public class AddLessonPlanDomainEvent : DomainEventBase
	{
		public AddLessonPlanDomainEvent() : base()
		{

		}
		public AddLessonPlanDomainEvent(Guid id, string title, LevelEnum level, Guid sessionId) : this()
		{
			Id = id;
			Title = title;
			Level = level;
			SessionId = sessionId;
		}
		public Guid Id { get; set; }
        public string Title { get; set; }
		public LevelEnum Level { get; set; }
		public Guid SessionId { get; set; }
	}
}
