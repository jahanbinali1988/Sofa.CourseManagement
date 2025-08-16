using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.SeedWork;

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
