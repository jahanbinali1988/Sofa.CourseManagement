using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions
{
	public class UpdateSessionDomainEvent : DomainEventBase
	{
        public UpdateSessionDomainEvent() : base()
        {
            
        }
        public UpdateSessionDomainEvent(Guid id, string title, byte priority, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{

			Id = id;
			Title = title;
			Priority = priority;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
        public Guid Id { get; set; }
		public string Title { get; set; }
		public byte Priority { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
