﻿using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions
{
	public class UpdateSessionDomainEvent : DomainEventBase
	{
        public UpdateSessionDomainEvent() : base()
        {
            
        }
        public UpdateSessionDomainEvent(Guid id, string title, DateTimeOffset? occurredDate, Guid termId) : this()
		{

			Id = id;
			Title = title;
			OccurredDate = occurredDate;
			TermId = termId;
		}
        public Guid Id { get; set; }
		public string Title { get; set; }
		public DateTimeOffset? OccurredDate { get; set; }
		public Guid TermId { get; set; }
	}
}
