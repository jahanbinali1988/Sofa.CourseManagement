using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent
{
    [Serializable]
    public class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            OccurredOn = DateTime.Now;
        }

        public DateTimeOffset OccurredOn { get; }
	}
}
