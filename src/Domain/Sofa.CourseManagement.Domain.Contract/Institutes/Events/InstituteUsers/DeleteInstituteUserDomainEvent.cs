using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.InstituteUsers
{
	public class DeleteInstituteUserDomainEvent : DomainEventBase
	{
        public DeleteInstituteUserDomainEvent() : base()
        {
            
        }

		public DeleteInstituteUserDomainEvent(Guid id, Guid instituteId)
		{
			Id = id;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public Guid InstituteId { get; set; }
	}
}
