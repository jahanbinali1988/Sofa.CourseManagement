using System;
using MediatR;

namespace Sofa.CourseManagement.SharedKernel.Application
{
    public interface ICommand : IRequest
    {
        Guid CommandId { get; }
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid CommandId { get; }
    }
}
