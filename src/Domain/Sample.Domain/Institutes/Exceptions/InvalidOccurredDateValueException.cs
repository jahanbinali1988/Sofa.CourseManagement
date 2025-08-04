using Sofa.CourseManagement.Domain.Shared.Exceptions;
using Sofa.SharedKernel.Shared;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Exceptions
{
    public class InvalidOccurredDateValueException : BusinessException
    {
        private readonly DateTimeOffset _value;
        public InvalidOccurredDateValueException(DateTimeOffset value)
        {
            _value = value;
        }

        public override string Message => string.Format($"The given value {0} is not valid", _value);
        public override string Code => nameof(ExceptionCodes.InvalidOccurredDateValueException);
    }
}
