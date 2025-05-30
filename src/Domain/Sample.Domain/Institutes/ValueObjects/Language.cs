﻿using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class Language : BusinessTypeValueObject<LanguageEnum>
	{
		public static implicit operator Language(LanguageEnum value)
		{
			return new Language(value);
		}

		private Language() : base()
		{
		}

		public Language(LanguageEnum language) : base(value: language)
		{
		}
	}
}
