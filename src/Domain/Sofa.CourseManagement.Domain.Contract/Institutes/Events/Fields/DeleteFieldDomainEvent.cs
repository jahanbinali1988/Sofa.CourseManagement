using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Fields
{
	public class DeleteFieldDomainEvent : DomainEventBase
	{
		public DeleteFieldDomainEvent() : base()
		{

		}
		public DeleteFieldDomainEvent(Guid id, Guid instituteId) : this()
		{
			Id = id;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public Guid InstituteId { get; set; }
	}
}
