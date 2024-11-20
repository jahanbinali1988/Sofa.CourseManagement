using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Terms
{
	public class UpdateTermDomainEvent : DomainEventBase
	{
		public UpdateTermDomainEvent() : base()
		{

		}
		public UpdateTermDomainEvent(Guid id, string title, Guid courseId) : this()
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
