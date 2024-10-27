using System;
using MediatR;

namespace Sofa.CourseManagement.SharedKernel.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTimeOffset OccurredOn { get; }
    }
}
