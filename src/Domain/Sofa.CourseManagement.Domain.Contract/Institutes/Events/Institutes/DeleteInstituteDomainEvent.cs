using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Institutes
{
	public class DeleteInstituteDomainEvent : DomainEventBase
	{
        public DeleteInstituteDomainEvent() : base()
        {

		}
		public DeleteInstituteDomainEvent(Guid id) : this()
		{
			Id = id;
		}
		public Guid Id { get; set; }

	}
}
