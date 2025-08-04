using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Fields
{
	public class UpdateFieldDomainEvent : DomainEventBase
	{
		public UpdateFieldDomainEvent() : base()
		{

		}
		public UpdateFieldDomainEvent(Guid id, string title, Guid instituteId) : this()
		{
			Id = id;
			Title = title;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
        public string Title { get; set; }
		public Guid InstituteId { get; set; }
	}
}
