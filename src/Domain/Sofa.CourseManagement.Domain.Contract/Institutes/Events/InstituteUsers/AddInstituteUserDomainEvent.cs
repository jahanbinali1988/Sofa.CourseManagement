using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.InstituteUsers
{
	public class AddInstituteUserDomainEvent : DomainEventBase
	{
		public AddInstituteUserDomainEvent() : base()
		{

		}
		public AddInstituteUserDomainEvent(Guid id, Guid userId, Guid instituteId) : this()
		{
			Id = id;
			UserId = userId;
			InstituteId = instituteId;
		}
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
