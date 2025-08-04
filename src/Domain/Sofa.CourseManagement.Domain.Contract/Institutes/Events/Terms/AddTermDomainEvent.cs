using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Terms
{
	public class AddTermDomainEvent : DomainEventBase
	{
        public AddTermDomainEvent() : base()
        {
            
        }
        public AddTermDomainEvent(Guid id, string title, Guid courseId) : this()
		{
			Id = id;
			Title = title;
			CourseId = courseId;
		}
		public Guid Id { get; set; }
		public string Title { get; set; }
		public Guid CourseId { get; set; }
    }
}
