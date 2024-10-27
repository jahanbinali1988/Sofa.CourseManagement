using MediatR;

namespace Sofa.CourseManagement.SharedKernel.Application
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
