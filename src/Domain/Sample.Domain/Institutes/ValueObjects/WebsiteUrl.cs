using Sofa.CourseManagement.Domain.Institutes.Constants;
using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class WebsiteUrl : ValueObject
	{
		public static implicit operator WebsiteUrl(string? value)
		{
			return new WebsiteUrl(value: value!);
		}

		private WebsiteUrl() : base()
		{
		}

		public WebsiteUrl(string? value) : this()
		{
			Validate(value);
			Value = value;
		}

		public void Validate(string? value)
		{
			if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringWebsiteUrlLength)
				throw new InvalidWebsiteUrlValueException(value);
		}

		public string? Value { get; private set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value!;
		}
	}
}
