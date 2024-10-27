using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.SharedKernel.SeedWork
{
	[Serializable]
	public abstract class ValueObject : IEquatable<ValueObject>
	{
		protected abstract IEnumerable<object> GetEqualityComponents();

		public static bool operator ==(ValueObject obj1, ValueObject obj2)
		{
			if (ReferenceEquals(obj1, null)) return ReferenceEquals(obj2, null);
			return obj1.Equals(obj2);
		}

		public static bool operator !=(ValueObject obj1, ValueObject obj2)
		{
			return !(obj1 == obj2);
		}

		public override bool Equals(object obj)
		{
			if (obj == null || obj.GetType() != GetType()) return false;

			var valueObject = (ValueObject)obj;

			return GetEqualityComponents()
				.SequenceEqual(valueObject.GetEqualityComponents());
		}

		public override int GetHashCode()
		{
			return GetEqualityComponents()
				.Aggregate(17, (current, obj) =>
				{
					unchecked
					{
						return current * 23 + (obj?.GetHashCode() ?? 0);
					}
				});
		}

		public bool Equals(ValueObject other)
		{
			return Equals(other as object);
		}
	}
}
