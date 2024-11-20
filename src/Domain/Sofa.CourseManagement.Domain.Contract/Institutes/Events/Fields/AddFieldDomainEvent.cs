using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Fields
{
	public class AddFieldDomainEvent : DomainEventBase
	{
        public AddFieldDomainEvent() : base()
        {
            
        }
		public AddFieldDomainEvent(Guid id, string title, Guid instituteId) : this()
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
