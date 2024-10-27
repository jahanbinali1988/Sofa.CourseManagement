using Sofa.CourseManagement.SharedKernel.Shared;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Exceptions
{
	public class InvalidCodeValueException : BusinessException
	{
		private readonly string _value;
		public InvalidCodeValueException(string value)
		{
			_value = value;
		}

		public override string Message => String.Format($"The given value {0} is not valid", _value);
		public override string? Code => nameof(ExceptionCodes.InvalidCodeValueException);
	}
	public class InvalidEmailValueException : BusinessException
	{
		private readonly string _value;
		public InvalidEmailValueException(string value)
		{
			_value = value;
		}

		public override string Message => String.Format($"The given value {0} is not valid", _value);
		public override string? Code => nameof(ExceptionCodes.InvalidEmailValueException);
	}
	public class InvalidNameValueException : BusinessException
	{
		private readonly string _value;
		public InvalidNameValueException(string value)
		{
			_value = value;
		}

		public override string Message => String.Format($"The given value {0} is not valid", _value);
		public override string? Code => nameof(ExceptionCodes.InvalidNameValueException);
	}
	public class InvalidPhoneNumberValueException : BusinessException
	{
		private readonly string _value;
		public InvalidPhoneNumberValueException(string value)
		{
			_value = value;
		}

		public override string Message => String.Format($"The given value {0} is not valid", _value);
		public override string? Code => nameof(ExceptionCodes.InvalidPhoneNumberValueException);
	}
	public class InvalidUserNameValueException : BusinessException
	{

		private readonly string _value;
		public InvalidUserNameValueException(string value)
		{
			_value = value;
		}

		public override string Message => String.Format($"The given value {0} is not valid", _value);
		public override string? Code => nameof(ExceptionCodes.InvalidUserNameValueException);
	}
}
