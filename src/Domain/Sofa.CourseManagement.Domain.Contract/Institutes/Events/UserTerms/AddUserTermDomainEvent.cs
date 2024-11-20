using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.UserTerms
{
	public class AddUserTermDomainEvent : DomainEventBase
	{
        public AddUserTermDomainEvent() : base()
		{

		}
		public AddUserTermDomainEvent(Guid id, Guid userId, Guid termId) : this()
		{
			Id = id;
			UserId = userId;
			TermId = termId;
		}
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid TermId { get; set; }
	}
}
