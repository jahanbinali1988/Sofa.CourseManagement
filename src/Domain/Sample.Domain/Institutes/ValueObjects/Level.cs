using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class Level : BusinessTypeValueObject<LevelEnum>
	{
		public static implicit operator Level(LevelEnum value)
		{
			return new Level(value);
		}

		private Level() : base()
		{
		}

		public Level(LevelEnum level) : base(value: level)
		{
		}
	}
}
