using Sofa.CourseManagement.SharedKernel.Shared;
using System;

namespace Sofa.CourseManagement.Domain.LessonPlans.Exceptions
{
	public class InvalidContentValueException : BusinessException
	{
		private readonly string _value;
		public InvalidContentValueException(string value)
		{
			_value = value;
		}

		public override string Message => String.Format($"The given value {0} is not valid", _value);
		public override string? Code => nameof(ExceptionCodes.InvalidContentValueException);
	}
}
