using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions
{
	public class DeleteSessionDomainEvent : DomainEventBase
	{
        public DeleteSessionDomainEvent() : base()
        {
            
        }
        public DeleteSessionDomainEvent(Guid id, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{

			Id = id;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
        public Guid Id { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
